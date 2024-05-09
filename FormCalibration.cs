using MadDogLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaddogSimGUI
{
    public partial class FormCalibration : Form
    {
        string filePath = @"F:\MaddogSimGUI\calibrationFile.txt";
        private bool RaspberryConnected;
        private PrimaryFlightControl PrimaryFlightControl;
        private SecondaryFlightControl SecondaryFlightControl;
        private Systems Systems;
        Functions functions = new Functions();
        float[,] calibrationVoltages = new float[11, 1000];
        float[,] calibratedVoltages = new float[11, 2];
        int calibrationCounter;
        bool calibrationFlagPrimary;
        bool calibrationFlagSecondary;
        bool calibrationFlagSystems;
        bool calibrationFlagAll;
        string line;
        public FormCalibration()
        {
            InitializeComponent();
        }

        public event EventHandler<PrimaryFlightControl> UpdatePrimaryFlightControl;
        public event EventHandler<SecondaryFlightControl> UpdateSecondaryFlightControl;
        public event EventHandler<Systems> UpdateSystems;

        private void SendUpdatePrimaryFlightControl(PrimaryFlightControl PrimaryFlightControlToUpdate)
        {
            UpdatePrimaryFlightControl?.Invoke(this, PrimaryFlightControlToUpdate);
        }
        private void SendUpdateSecondaryFlightControl(SecondaryFlightControl SecondaryFlightControlToUpdate)
        {
            UpdateSecondaryFlightControl?.Invoke(this, SecondaryFlightControlToUpdate);
        }
        private void SendUpdateSystems(Systems SystemsToUpdate)
        {
            UpdateSystems?.Invoke(this, SystemsToUpdate);
        }
        private void EventSubscription()
        {
            
            FormPrincipal formPrincipal = Application.OpenForms.OfType<FormPrincipal>().FirstOrDefault();
            formPrincipal.IsRaspberryConnected += FormPrincipal_IsRaspberryConnected;
            formPrincipal.TransferPrimaryFlightControl += FormPrincipal_TransferPrimaryFlightControl;
            formPrincipal.TransferSecondaryFlightControl += FormPrincipal_TransferSecondaryFlightControl;
            formPrincipal.TransferSystems += FormPrincipal_TransferSystems;
            
        }
        private void FormPrincipal_IsRaspberryConnected(object sender, bool RaspberryCon)
        {
            RaspberryConnected = RaspberryCon;
        }
        private void FormPrincipal_TransferPrimaryFlightControl(object sender, PrimaryFlightControl PrimaryFlightControlToReceive)
        {
            try
            {
                PrimaryFlightControl = PrimaryFlightControlToReceive;

                if (calibrationCounter < 1000 && calibrationFlagPrimary == true)
                {
                    calibrationVoltages[0, calibrationCounter] = PrimaryFlightControl.Elevator.Voltage;
                    calibrationVoltages[1, calibrationCounter] = PrimaryFlightControl.Aileron.Voltage;
                    calibrationVoltages[2, calibrationCounter] = PrimaryFlightControl.Rudder.Voltage;
                    //progressBar1.Value = calibrationCounter;
                    calibrationCounter++;

                }
                if (calibrationCounter == 1000 && calibrationFlagPrimary == true)
                {
                    calibratedVoltages = functions.CalibrationFunction(calibrationVoltages);

                    for (int i = 0; i < 3; i++)
                    {
                        line = calibratedVoltages[i, 0].ToString() + ';' + calibratedVoltages[i, 1].ToString();
                        functions.WriteLineToCalibrationFile(i, line, filePath);
                    }
                    PrimaryFlightControl.Elevator.MinVoltage = calibratedVoltages[0, 0];
                    PrimaryFlightControl.Aileron.MinVoltage = calibratedVoltages[1, 0];
                    PrimaryFlightControl.Rudder.MinVoltage = calibratedVoltages[2, 0];
                    PrimaryFlightControl.Elevator.MaxVoltage = calibratedVoltages[0, 1];
                    PrimaryFlightControl.Aileron.MaxVoltage = calibratedVoltages[1, 1];
                    PrimaryFlightControl.Rudder.MaxVoltage = calibratedVoltages[2, 1];

                    Array.Clear(calibrationVoltages, 0, calibrationVoltages.Length);
                    Array.Clear(calibratedVoltages, 0, calibratedVoltages.Length);
                    MessageBox.Show("Calibration finished.");
                    SendUpdatePrimaryFlightControl(PrimaryFlightControl);
                    calibrationFlagPrimary = false;
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"An error occurred: {ex.Message}\n\n Line: {ex.StackTrace}";
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPrincipal_TransferSecondaryFlightControl(object sender, SecondaryFlightControl SecondaryFlightControlToReceive)
        {
            SecondaryFlightControl = SecondaryFlightControlToReceive;
            if (calibrationCounter < 1000 && calibrationFlagSecondary == true)
            {
                calibrationVoltages[5, calibrationCounter] = SecondaryFlightControl.Flap.Voltage;
                calibrationVoltages[6, calibrationCounter] = SecondaryFlightControl.Slat.Voltage;
                calibrationVoltages[7, calibrationCounter] = SecondaryFlightControl.Spoiler.Voltage;
                calibrationVoltages[8, calibrationCounter] = SecondaryFlightControl.ElevatorTrimLeft.Voltage;
                //calibrationVoltages[7, i] = (float)landingGear;
                //progressBar1.Value = calibrationCounter;
                calibrationCounter++;

            }
            if (calibrationCounter == 1000 && calibrationFlagSecondary == true)
            {
                calibratedVoltages = functions.CalibrationFunction(calibrationVoltages);

                for (int i = 5; i < 10; i++)
                {
                    line = calibratedVoltages[i, 0].ToString() + ';' + calibratedVoltages[i, 1].ToString();
                    functions.WriteLineToCalibrationFile(i, line, filePath);
                }
                SecondaryFlightControl.Flap.MinVoltage = calibratedVoltages[5, 0];
                SecondaryFlightControl.Slat.MinVoltage = calibratedVoltages[6, 0];
                SecondaryFlightControl.Spoiler.MinVoltage = calibratedVoltages[7, 0];
                SecondaryFlightControl.ElevatorTrimLeft.MinVoltage = calibratedVoltages[8, 0];
                SecondaryFlightControl.ElevatorTrimRight.MinVoltage = calibratedVoltages[9, 0];
                SecondaryFlightControl.Flap.MaxVoltage = calibratedVoltages[5, 1];
                SecondaryFlightControl.Slat.MaxVoltage = calibratedVoltages[6, 1];
                SecondaryFlightControl.Spoiler.MaxVoltage = calibratedVoltages[7, 1];
                SecondaryFlightControl.ElevatorTrimLeft.MaxVoltage = calibratedVoltages[8, 1];
                SecondaryFlightControl.ElevatorTrimRight.MinVoltage = calibratedVoltages[9, 1];

                Array.Clear(calibrationVoltages, 0, calibrationVoltages.Length);
                Array.Clear(calibratedVoltages, 0, calibratedVoltages.Length);
                MessageBox.Show("Calibration finished.");
                SendUpdatePrimaryFlightControl(PrimaryFlightControl);
                calibrationFlagSecondary = false;

            }
        }
        private void FormPrincipal_TransferSystems(object sender, Systems SystemsToReceive)
        {
            Systems = SystemsToReceive;
            if (calibrationCounter < 1000 && calibrationFlagSystems  == true)
            {
                calibrationVoltages[3, calibrationCounter] = Systems.Throttle1.Voltage;
                calibrationVoltages[4, calibrationCounter] = Systems.Throttle2.Voltage;
                calibrationCounter++;

            }
            if (calibrationCounter == 1000 && calibrationFlagSystems == true)
            {
                calibratedVoltages = functions.CalibrationFunction(calibrationVoltages);

                for (int i = 3; i < 5; i++)
                {
                    line = calibratedVoltages[i, 0].ToString() + ';' + calibratedVoltages[i, 1].ToString();
                    functions.WriteLineToCalibrationFile(i, line, filePath);
                }
                line = calibratedVoltages[9, 0].ToString() + ';' + calibratedVoltages[9, 1].ToString();
                functions.WriteLineToCalibrationFile(9, line, filePath);

                Systems.Throttle1.MinVoltage = calibratedVoltages[3, 0];
                Systems.Throttle2.MinVoltage = calibratedVoltages[4, 0];
                //Systems.LandingGear.MinVoltage = calibratedVoltages[9, 0];
                Systems.Throttle1.MaxVoltage = calibratedVoltages[3, 1];
                Systems.Throttle2.MaxVoltage = calibratedVoltages[4, 1];
                //Systems.LandingGear.MaxVoltage = calibratedVoltages[9, 1];

                Array.Clear(calibrationVoltages, 0, calibrationVoltages.Length);
                Array.Clear(calibratedVoltages, 0, calibratedVoltages.Length);
                MessageBox.Show("Calibration finished.");
                SendUpdatePrimaryFlightControl(PrimaryFlightControl);
                calibrationFlagSystems = false;

            }
        }
        private void buttonPrimaryFlightControlCalibration_Click(object sender, EventArgs e)
        {
            calibrationCounter = 0;
            calibrationFlagPrimary = true;

        }

        private void panelCalibration_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormCalibration_Load(object sender, EventArgs e)
        {
            EventSubscription();
        }

        private void buttonSecondaryFlightControlCalibration_Click(object sender, EventArgs e)
        {
            calibrationCounter = 0;
            calibrationFlagSecondary = true;
        }

        private void buttonOtherSystemsCalibration_Click(object sender, EventArgs e)
        {
            calibrationCounter = 0;
            calibrationFlagSystems = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
