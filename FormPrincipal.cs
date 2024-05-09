using MadDogLibrary;
using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaddogSimGUI
{
    public partial class FormPrincipal : Form
    {
        #region Raspberry com variables
        private Socket serverSocket;
        byte[] buffer;
        int numPort;
        bool calibrationFlag;
        bool calibrationGetValues;
        int calibrationCounter;
        float[,] calibrationVoltages = new float[11, 1000];
        float[,] calibratedVoltages = new float[11, 2];
        bool formADCInputsCanBeClosed;
        bool formCalibrationCanBeClosed;

        #endregion
        #region Simulator com variables
        //SimConnect object
        SimConnect simconnect = null;
        //User-defined win32 event
        const int WM_USER_SIMCONNECT = 0x0402;
        string filePath = @"F:\MaddogSimGUI\calibrationFile.txt";
        PrimaryFlightControl PrimaryFlightControl = new PrimaryFlightControl();
        SecondaryFlightControl SecondaryFlightControl = new SecondaryFlightControl();
        Systems Systems = new Systems();
        Functions functions = new Functions();

        bool loadCalibratedVoltages = true;

        #region SetOnDataSimObject structs and IDs
        [Serializable]
        struct ElevatorDataStruct
        {
            public float Position;
        }
        struct AileronDataStruct
        {
            public float Position;
        }
        struct RudderDataStruct
        {
            public float Position;
        }
        struct FlapLeftDataStruct
        {
            public float Position;
        }
        struct FlapRightDataStruct
        {
            public float Position;
        }
        struct SlatDataStruct
        {
            public float Position;
        }
        struct SpoilerDataStruct
        {
            public float Position;
        }
        struct EngineLeftDataStruct
        {
            public float Position;
        }
        struct EngineRightDataStruct
        {
            public float Position;
        }
        static bool engineLeftStarted = false;
        static bool engineRightStarted = false;
        enum DefinitionId
        {
            ElevatorData,
            AileronData,
            RudderData,
            FlapLeftData,
            FlapRightData,
            SlatData,
            SpoilerData,
            EngineLeftData,
            EngineRightData,
            EngineLeftStarted,
            EngineRightStarted,
        }
        #endregion
        public enum GROUP
        {
            GROUP1
        }
        public enum EventEnum
        {
            ELEVATOR_SET,           //POTENTIOMETER
            GEAR_SET,               //GPIO
            THROTTLE1_SET,          //POTENTIOMETER
            THROTTLE2_SET,          //POTENTIOMETER
            AILERON_SET,            //POTENTIOMETER
            RUDDER_SET,             //POTENTIOMETER
            SPOILERS_SET,           //POTENTIOMETER?
            AXIS_FLAPS_SET,
            FLAPS_SET,              //POTENTIOMETER
            AXIS_ELEV_TRIM_SET,
            ELEVATOR_TRIM_SET,      //POTENTIOMETER?
            RUDDER_TRIM_SET,        //POTENTIOMETER?
            AILERON_TRIM_SET,        //POTENTIOMETER?
            AXIS_STEERING_SET,
            NOSE_WHEEL_STEERING_LIMIT_SET

        }
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simconnect != null)
                {
                    simconnect.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        #endregion

        public FormPrincipal()
        {
            InitializeComponent();

        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            labelIP.Text = "xxx.xxx.xxx.xxx";
            labelIP.TextAlign = ContentAlignment.MiddleCenter;
            calibratedVoltages = functions.ReadCalibrationFile(filePath);
            if (calibratedVoltages != null)
            {
                OpenFormWelcome();
                buttonWelcome.BackColor = Color.FromArgb(55, 168, 219);
                buttonWelcome.Enabled = false;
                buttonADCInputs.Enabled = true;
                buttonCalibration.Enabled = true;
                PrimaryFlightControl.SetPrimaryCalibratedVoltages(calibratedVoltages);
                SecondaryFlightControl.SetSecondaryCalibratedVoltages(calibratedVoltages);
                Systems.SetSystemsCalibratedVoltages(calibratedVoltages);
            }
            else
            {
                OpenFormCalibration();
                buttonCalibration.BackColor = Color.FromArgb(55, 168, 219);
                buttonWelcome.Enabled = true;
                buttonADCInputs.Enabled = true;
                buttonCalibration.Enabled = false;
            }
        }


        #region Form Functionalities
        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {


        }
        /*
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        */

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (simconnect != null)
            {
                Disconnect();
            }
            Application.Exit();
        }

        int lx, ly, buttonRspbConnectlx, buttonRspbConnectly;
        int sw, sh;
        private void btnMaxi_Click(object sender, EventArgs e)
        {
            /*
            lx = this.Location.X; ly = this.Location.Y;
            sw = this.Size.Width; sh = this.Size.Height;
            buttonRspbConnectlx = buttonRspbConnect.Location.X ; buttonRspbConnectly = buttonRspbConnect.Location.Y;
            btnMaxi.Visible = false;
            btnRes.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            buttonRspbConnect.Location = Screen.PrimaryScreen.WorkingArea.Location;
            */
        }

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            /*
            btnMaxi.Visible = true;
            btnRes.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            buttonRspbConnect.Location = new Point(buttonRspbConnectlx, buttonRspbConnectly);
            */
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //METODO PARA ARRASTRAR EL FORMULARIO
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void buttonWelcome_Click(object sender, EventArgs e)
        {
            OpenFormWelcome();
            buttonWelcome.BackColor = Color.FromArgb(55, 168, 219);
            buttonWelcome.Enabled = false;
            buttonADCInputs.Enabled = true;
            buttonCalibration.Enabled = true;
        }


        private void buttonADCInputs_Click(object sender, EventArgs e)
        {
            OpenFormADCInputs();
            buttonADCInputs.BackColor = Color.FromArgb(55, 168, 219);
            buttonADCInputs.Enabled = false;
            buttonWelcome.Enabled = true;
            buttonCalibration.Enabled = true;
        }
        private void buttonCalibration_Click(object sender, EventArgs e)
        {

            OpenFormCalibration();
            buttonCalibration.BackColor = Color.FromArgb(55, 168, 219);
            buttonWelcome.Enabled = true;
            buttonADCInputs.Enabled = true;
            buttonCalibration.Enabled = false;

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
        public void OpenFormADCInputs()
        {

            FormADCInputs formADCInputs = new FormADCInputs();
            if (Application.OpenForms["FormCalibration"] != null)
            {
                FormCalibration formCalibration = Application.OpenForms.OfType<FormCalibration>().FirstOrDefault();
                formCalibration.Close();
            }
            if (Application.OpenForms["FormWelcome"] != null)
            {
                FormWelcome formWelcome = Application.OpenForms.OfType<FormWelcome>().FirstOrDefault();
                formWelcome.Close();
            }
            formADCInputs.TopLevel = false;
            formADCInputs.FormBorderStyle = FormBorderStyle.None;
            formADCInputs.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formADCInputs);
            panelFormularios.Tag = formADCInputs;
            formADCInputs.Show();
            formADCInputs.FormClosed += CloseForms;



        }
        public void OpenFormWelcome()
        {

            FormWelcome formWelcome = new FormWelcome();
            if (Application.OpenForms["FormCalibration"] != null)
            {
                FormCalibration formCalibration = Application.OpenForms.OfType<FormCalibration>().FirstOrDefault();
                formCalibration.Close();
            }
            if (Application.OpenForms["FormADCInputs"] != null)
            {
                FormADCInputs formADCInputs = Application.OpenForms.OfType<FormADCInputs>().FirstOrDefault();
                formADCInputs.Close();
            }
            formWelcome.TopLevel = false;
            formWelcome.FormBorderStyle = FormBorderStyle.None;
            formWelcome.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formWelcome);
            panelFormularios.Tag = formWelcome;
            formWelcome.Show();
            formWelcome.FormClosed += CloseForms;

        }

        public void OpenFormCalibration()
        {

            FormCalibration formCalibration = new FormCalibration();
            if (Application.OpenForms["FormWelcome"] != null)
            {
                FormWelcome formWelcome = Application.OpenForms.OfType<FormWelcome>().FirstOrDefault();
                formWelcome.Close();
            }
            if (Application.OpenForms["FormADCInputs"] != null)
            {
                FormADCInputs formADCInputs = Application.OpenForms.OfType<FormADCInputs>().FirstOrDefault();
                formADCInputs.Close();
            }
            formCalibration.TopLevel = false;
            formCalibration.FormBorderStyle = FormBorderStyle.None;
            formCalibration.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formCalibration);
            panelFormularios.Tag = formCalibration;
            formCalibration.Show();
            formCalibration.FormClosed += CloseForms;


        }
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //METHOD TO RETURN TO PREVIOUS COLOR WHEN FORMS ARE CLOSED
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FormADCInputs"] == null)
            {
                buttonADCInputs.BackColor = Color.FromArgb(46, 46, 46);
            }
            if (Application.OpenForms["FormCalibration"] == null)
            {
                buttonCalibration.BackColor = Color.FromArgb(46, 46, 46);
            }
            if (Application.OpenForms["FormWelcome"] == null)
            {
                buttonWelcome.BackColor = Color.FromArgb(46, 46, 46);
            }
        }
        #endregion

        #region Events to send data to other forms
        public event EventHandler<bool> IsRaspberryConnected;
        public event EventHandler<PrimaryFlightControl> TransferPrimaryFlightControl;
        public event EventHandler<SecondaryFlightControl> TransferSecondaryFlightControl;
        public event EventHandler<Systems> TransferSystems;

        private void SendRaspberryConnection(bool RaspberryConnect)
        {

            IsRaspberryConnected?.Invoke(this, RaspberryConnect);

        }
        private void SendPrimaryFlightControl(PrimaryFlightControl PrimaryFlightControlToSend)
        {

            TransferPrimaryFlightControl?.Invoke(this, PrimaryFlightControlToSend);
        }
        private void SendSecondaryFlightControl(SecondaryFlightControl SecondaryFlightControlToSend)
        {

            TransferSecondaryFlightControl?.Invoke(this, SecondaryFlightControlToSend);
        }
        private void SendSystems(Systems SystemsToSend)
        {

            TransferSystems?.Invoke(this, SystemsToSend);
        }

        #endregion

        #region Events to receive data from other forms
        private void EventSuscription()
        {
            FormCalibration formCalibration = Application.OpenForms.OfType<FormCalibration>().FirstOrDefault();
            formCalibration.UpdatePrimaryFlightControl += FormCalibration_UpdatePrimaryFlightControl;
            formCalibration.UpdateSecondaryFlightControl += FormCalibration_UpdateSecondaryFlightControl;
            formCalibration.UpdateSystems += FormCalibration_UpdateSystems;
        }
        private void FormCalibration_UpdatePrimaryFlightControl(object sender, PrimaryFlightControl PrimaryFlightControlToUpdate)
        {
            PrimaryFlightControl.Elevator.MaxVoltage = PrimaryFlightControlToUpdate.Elevator.MaxVoltage;
            PrimaryFlightControl.Elevator.MinVoltage = PrimaryFlightControlToUpdate.Elevator.MinVoltage;
            PrimaryFlightControl.Aileron.MaxVoltage = PrimaryFlightControlToUpdate.Aileron.MaxVoltage;
            PrimaryFlightControl.Aileron.MinVoltage = PrimaryFlightControlToUpdate.Aileron.MinVoltage;
            PrimaryFlightControl.Rudder.MaxVoltage = PrimaryFlightControlToUpdate.Rudder.MaxVoltage;
            PrimaryFlightControl.Rudder.MinVoltage = PrimaryFlightControlToUpdate.Rudder.MinVoltage;
        }
        private void FormCalibration_UpdateSecondaryFlightControl(object sender, SecondaryFlightControl SecondaryFlightControlToUpdate)
        {
            SecondaryFlightControl.Flap.MaxVoltage = SecondaryFlightControlToUpdate.Flap.MaxVoltage;
            SecondaryFlightControl.Flap.MinVoltage = SecondaryFlightControlToUpdate.Flap.MinVoltage;
            SecondaryFlightControl.Spoiler.MaxVoltage = SecondaryFlightControlToUpdate.Spoiler.MaxVoltage;
            SecondaryFlightControl.Spoiler.MinVoltage = SecondaryFlightControlToUpdate.Spoiler.MinVoltage;
        }
        private void FormCalibration_UpdateSystems(object sender, Systems SystemsToUpdate)
        {
            Systems.Throttle1.MaxVoltage = SystemsToUpdate.Throttle1.MaxVoltage;
            Systems.Throttle1.MinVoltage = SystemsToUpdate.Throttle1.MinVoltage;
            Systems.Throttle2.MaxVoltage = SystemsToUpdate.Throttle2.MaxVoltage;
            Systems.Throttle2.MinVoltage = SystemsToUpdate.Throttle2.MinVoltage;
        }
        #endregion

        #region raspberry communication
        bool RspbConnected;

        public static object RequestId { get; private set; }

        private void StartServer(int numPort, IPAddress ipAddr)
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, numPort);
                serverSocket.Bind(localEndPoint);

                IPAddress clientAddr = IPAddress.Parse("169.254.99.177");
                IPEndPoint clientEndPoint = new IPEndPoint(clientAddr, numPort);
                EndPoint tempRemoteEP = (EndPoint)clientEndPoint;
                buffer = new byte[100];//clientSocket.ReceiveBufferSize

                serverSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref tempRemoteEP, new AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                IPAddress clientAddr = IPAddress.Parse("169.254.99.177");
                IPEndPoint clientEndPoint = new IPEndPoint(clientAddr, numPort);
                EndPoint tempRemoteEP = (EndPoint)clientEndPoint;
                string[] voltages = new string[11];
                int received = serverSocket.EndReceiveFrom(AR, ref tempRemoteEP);
                stopwatch.Stop();
                TimeSpan receiveTime = stopwatch.Elapsed;
                string receiveTimeMilliseconds = receiveTime.TotalMilliseconds.ToString("F1");
                AppendToLatencyLabel(receiveTimeMilliseconds);
                string text = Encoding.UTF8.GetString(buffer);
                string r = received.ToString();
                FormADCInputs formADCInputs = Application.OpenForms.OfType<FormADCInputs>().FirstOrDefault();

                if (received == 0)
                {
                    text = "nothing received";
                    RspbConnected = false;

                }
                RspbConnected = true;
                voltages = text.Split('$');

                PrimaryFlightControl.Elevator.Voltage = (float)Math.Round(float.Parse(voltages[0], System.Globalization.CultureInfo.InvariantCulture), 2);
                PrimaryFlightControl.Aileron.Voltage = (float)Math.Round(float.Parse(voltages[1], System.Globalization.CultureInfo.InvariantCulture), 2);
                PrimaryFlightControl.Rudder.Voltage = (float)Math.Round(float.Parse(voltages[2], System.Globalization.CultureInfo.InvariantCulture), 2);
                Systems.Throttle1.Voltage = (float)Math.Round(float.Parse(voltages[3], System.Globalization.CultureInfo.InvariantCulture), 2);
                Systems.Throttle2.Voltage = (float)Math.Round(float.Parse(voltages[4], System.Globalization.CultureInfo.InvariantCulture), 2);
                SecondaryFlightControl.Flap.Voltage = (float)Math.Round(float.Parse(voltages[5], System.Globalization.CultureInfo.InvariantCulture), 1);
                SecondaryFlightControl.Slat.Voltage = (float)Math.Round(float.Parse(voltages[6], System.Globalization.CultureInfo.InvariantCulture), 2);
                SecondaryFlightControl.Spoiler.Voltage = (float)Math.Round(float.Parse(voltages[7], System.Globalization.CultureInfo.InvariantCulture), 3);
                SecondaryFlightControl.ElevatorTrimLeft.Voltage = (float)Math.Round(float.Parse(voltages[8], System.Globalization.CultureInfo.InvariantCulture), 2);
                SecondaryFlightControl.ElevatorTrimRight.Voltage = (float)Math.Round(float.Parse(voltages[9], System.Globalization.CultureInfo.InvariantCulture), 2);
                Systems.LandingGear.State = int.Parse(voltages[10]);

                //Systems.LandingGear.State = Convert.ToInt32(voltages[10]);

                PrimaryFlightControl.Elevator.Position = functions.Map(PrimaryFlightControl.Elevator.Voltage, PrimaryFlightControl.Elevator.MinVoltage, PrimaryFlightControl.Elevator.MaxVoltage, 16383.00f, -16383.00f, true);
                PrimaryFlightControl.Aileron.Position = functions.Map(PrimaryFlightControl.Aileron.Voltage, PrimaryFlightControl.Aileron.MinVoltage, PrimaryFlightControl.Aileron.MaxVoltage, -16383.00f, 16383.00f, true);
                PrimaryFlightControl.Rudder.Position = functions.Map(PrimaryFlightControl.Rudder.Voltage, PrimaryFlightControl.Rudder.MinVoltage, PrimaryFlightControl.Rudder.MaxVoltage, -16383.00f, 16383.00f, true);
                Systems.Throttle1.Position = functions.Map(Systems.Throttle1.Voltage, Systems.Throttle1.MinVoltage, Systems.Throttle1.MaxVoltage, -16383.00f, 16383.00f, true);
                Systems.Throttle2.Position = functions.Map(Systems.Throttle2.Voltage, Systems.Throttle2.MinVoltage, Systems.Throttle2.MaxVoltage, -16383.00f, 16383.00f, true);
                SecondaryFlightControl.Flap.Position = functions.Map(SecondaryFlightControl.Flap.Voltage, SecondaryFlightControl.Flap.MinVoltage, SecondaryFlightControl.Flap.MaxVoltage, 16383.00f, 0.00f, false);
                SecondaryFlightControl.Slat.Position = functions.Map(SecondaryFlightControl.Slat.Voltage, SecondaryFlightControl.Slat.MinVoltage, SecondaryFlightControl.Slat.MaxVoltage, 16383.00f, 0.00f, false);
                SecondaryFlightControl.Spoiler.Position = functions.Map(SecondaryFlightControl.Spoiler.Voltage, SecondaryFlightControl.Spoiler.MinVoltage, SecondaryFlightControl.Spoiler.MaxVoltage, 0.00f, 16383.00f, false);
                SecondaryFlightControl.ElevatorTrimLeft.Position = functions.Map(SecondaryFlightControl.ElevatorTrimLeft.Voltage, SecondaryFlightControl.ElevatorTrimLeft.MinVoltage, SecondaryFlightControl.ElevatorTrimLeft.MaxVoltage, 16383.00f, -16383.00f, true);
                SecondaryFlightControl.ElevatorTrimRight.Position = functions.Map(SecondaryFlightControl.ElevatorTrimRight.Voltage, SecondaryFlightControl.ElevatorTrimRight.MinVoltage, SecondaryFlightControl.ElevatorTrimRight.MaxVoltage, 16383.00f, -16383.00f, true);
                if (simconnect != null && !calibrationFlag)
                {
                    /*
                    simconnect.ReceiveMessage();
                    simconnect.SetDataOnSimObject(DefinitionId.ElevatorData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, new ElevatorDataStruct { Position = PrimaryFlightControl.Elevator.Position});
                    simconnect.SetDataOnSimObject(DefinitionId.AileronData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, new AileronDataStruct { Position = PrimaryFlightControl.Aileron.Position });
                    simconnect.SetDataOnSimObject(DefinitionId.RudderData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, new RudderDataStruct { Position = PrimaryFlightControl.Rudder.Position });
                    simconnect.SetDataOnSimObject(DefinitionId.FlapLeftData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, new FlapLeftDataStruct { Position = SecondaryFlightControl.Flap.Position });
                    simconnect.SetDataOnSimObject(DefinitionId.FlapRightData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, new FlapRightDataStruct { Position = SecondaryFlightControl.Flap.Position });
                    simconnect.SetDataOnSimObject(DefinitionId.SlatData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, new SlatDataStruct { Position = SecondaryFlightControl.Slat.Position });
                    simconnect.SetDataOnSimObject(DefinitionId.EngineLeftData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, new EngineLeftDataStruct { Position = Systems.Throttle1.Position  });
                    simconnect.SetDataOnSimObject(DefinitionId.EngineRightData, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, new EngineRightDataStruct { Position = Systems.Throttle2.Position });
                    */

                    TransmitEvent(EventEnum.ELEVATOR_SET, ((int)PrimaryFlightControl.Elevator.Position).ToString());
                    TransmitEvent(EventEnum.AILERON_SET, ((int)PrimaryFlightControl.Aileron.Position).ToString());
                    TransmitEvent(EventEnum.RUDDER_SET, ((int)PrimaryFlightControl.Rudder.Position).ToString());
                    TransmitEvent(EventEnum.THROTTLE1_SET, ((int)Systems.Throttle1.Position).ToString());
                    TransmitEvent(EventEnum.THROTTLE2_SET, ((int)Systems.Throttle1.Position).ToString());
                    TransmitEvent(EventEnum.FLAPS_SET, ((int)SecondaryFlightControl.Slat.Position).ToString());
                    TransmitEvent(EventEnum.AXIS_FLAPS_SET, ((int)SecondaryFlightControl.Slat.Position).ToString());
                    TransmitEvent(EventEnum.SPOILERS_SET, ((int)SecondaryFlightControl.Spoiler.Position).ToString());
                    TransmitEvent(EventEnum.GEAR_SET, Systems.LandingGear.State.ToString());
                    TransmitEvent(EventEnum.ELEVATOR_TRIM_SET, (-16383.00).ToString());
                    TransmitEvent(EventEnum.AXIS_ELEV_TRIM_SET, (-16383.00f).ToString());
                    if (Systems.LandingGear.State == 1)
                    {
                        TransmitEvent(EventEnum.NOSE_WHEEL_STEERING_LIMIT_SET, "500");
                        TransmitEvent(EventEnum.AXIS_STEERING_SET, ((int)PrimaryFlightControl.Rudder.Position).ToString());
                    }

                }
                if (Application.OpenForms.OfType<FormADCInputs>().Any())
                {
                    SendRaspberryConnection(RspbConnected);
                    SendPrimaryFlightControl(PrimaryFlightControl);
                    SendSecondaryFlightControl(SecondaryFlightControl);
                    SendSystems(Systems);
                }

                if (simconnect == null && Application.OpenForms.OfType<FormCalibration>().Any())
                {

                    SendRaspberryConnection(RspbConnected);
                    SendPrimaryFlightControl(PrimaryFlightControl);
                    SendSecondaryFlightControl(SecondaryFlightControl);
                    SendSystems(Systems);

                }
                //Array.Resize(ref buffer, clientSocket.ReceiveBufferSize);
                serverSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception ex)
            {
                if (ex is ObjectDisposedException)
                {
                    serverSocket.Close();
                }
                else
                {
                    string errorMessage = $"An error occurred: {ex.Message}\n\n Line: {ex.StackTrace}";
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AppendToLatencyLabel(string latency)
        {
            Task.Run(() =>
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    labelLatency.Text = latency + " ms";
                }));
                System.Threading.Thread.Sleep(500);
            });

        }

        private void buttonRspbDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                serverSocket.Close();
                serverSocket.Dispose();
                buttonRspbConnect.Visible = true;
                buttonRspbDisconnect.Visible = false;
                labelIP.Text = "xxx.xxx.xxx.xxx";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        #endregion

        #region Simulator communication
        /*
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simconnect != null)
                {
                    simconnect.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }
        */
        // Set up the SimConnect event handlers
        public void Connect()
        {
            try
            {
                /// The constructor is similar to SimConnect_Open in the native API
                simconnect = new SimConnect("MaddogSimGUI", this.Handle, WM_USER_SIMCONNECT, null, 0);
                simconnect.OnRecvOpen += SimConnect_OnRecvOpen;
                simconnect.OnRecvQuit += SimConnect_OnRecvQuit;
                simconnect.OnRecvException += SimConnect_OnRecvException;
                buttonSimConnect.Visible = false;
                buttonSimDisconnect.Visible = true;

            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Disconnect()
        {
            try
            {
                if (simconnect != null)
                {
                    // Dispose serves the same purpose as SimConnect_Close()
                    simconnect.Dispose();
                    simconnect = null;
                    buttonSimConnect.Visible = true;
                    buttonSimDisconnect.Visible = false;
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSimConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Connect();
                //simconnect.ReceiveMessage();
                //simconnect.SetDataOnSimObject(DefinitionId.EngineLeftStarted, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 1);
                //simconnect.SetDataOnSimObject(DefinitionId.EngineRightStarted, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, 1);
                if (simconnect != null)
                {
                    foreach (EventEnum item in Enum.GetValues(typeof(EventEnum)))
                    {
                        simconnect.MapClientEventToSimEvent(item, item.ToString());
                        simconnect.AddClientEventToNotificationGroup(GROUP.GROUP1, item, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSimDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                Disconnect();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRspbConnect_Click(object sender, EventArgs e)
        {
            try
            {
                numPort = Convert.ToInt32(textBoxNumPort.Text);
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                List<IPAddress> localAddresses = new List<IPAddress>();

                foreach (IPAddress ipAddress in ipHost.AddressList)
                {
                    if (ipAddress.AddressFamily == AddressFamily.InterNetwork) // filter out ipv4
                    {
                        localAddresses.Add(ipAddress);
                    }
                }
                IPAddress ipAddr = localAddresses[0];
                labelIP.Text = ipAddr.ToString();
                
                StartServer(numPort, ipAddr);
                buttonRspbConnect.Visible = false;
                buttonRspbDisconnect.Visible = true;
                MessageBox.Show("Socket created succesfully");
            }
            catch (Exception error)//SocketException
            {
                MessageBox.Show(error.ToString());
            }
        }

        public void TransmitEvent(EventEnum cmd, string data)
        {
            Byte[] Bytes = BitConverter.GetBytes(Convert.ToInt32(data));
            UInt32 Param = BitConverter.ToUInt32(Bytes, 0);
            try
            {
                if (simconnect != null)
                {
                    simconnect.TransmitClientEvent(0, cmd, Param, GROUP.GROUP1, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                }
            }
            catch(Exception e)
            {
                if(e.HResult == unchecked((int)0xC00000B0))
                {
                    Disconnect();
                }
                else
                {
                    MessageBox.Show("The Transmit Request Failed: " + e.Message);
                }
            }
        }

        private void panelFormularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelIP_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNumPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelBarraTitulo2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void SimConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            // Register pending requests
            /*
            simconnect.AddToDataDefinition(DefinitionId.ElevatorData, "ELEVATOR POSITION", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DefinitionId.AileronData, "AILERON POSITION", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DefinitionId.RudderData, "RUDDER POSITION", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DefinitionId.FlapLeftData, "TRAILING EDGE FLAPS LEFT PERCENT", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DefinitionId.FlapRightData, "TRAILING EDGE FLAPS RIGHT PERCENT", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DefinitionId.SlatData, "SLAT POSITION SET", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DefinitionId.SpoilerData, "SPOILER POSITION SET", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DefinitionId.EngineLeftData, "GENERAL ENG THROTTLE LEVER POSITION:1", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            simconnect.AddToDataDefinition(DefinitionId.EngineRightData, "GENERAL ENG THROTTLE LEVER POSITION:2", "Position", SIMCONNECT_DATATYPE.FLOAT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            */
            //simconnect.AddToDataDefinition(DefinitionId.EngineLeftStarted, "GENERAL ENG STARTER:1", null, SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            //simconnect.AddToDataDefinition(DefinitionId.EngineRightStarted, "GENERAL ENG STARTER:2", null, SIMCONNECT_DATATYPE.INT32, 0.0f, SimConnect.SIMCONNECT_UNUSED);
        }
        
        
        /// The case where the user closes game
        private void SimConnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            Disconnect();
        }
        private static void SimConnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            MessageBox.Show($"Excepción recibida: {data.dwException}");
            
        }
        #endregion

    }
}
