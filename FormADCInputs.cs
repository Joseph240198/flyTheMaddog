using MadDogLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MaddogSimGUI
{
    public partial class FormADCInputs : Form
    {

        private bool RaspberryConnected;
        private PrimaryFlightControl PrimaryFlightControl;
        private SecondaryFlightControl SecondaryFlightControl;
        private Systems Systems;
        private CountdownEvent countdownEvent = new CountdownEvent(4);
       

       
        public FormADCInputs()
        {
            InitializeComponent();
            
        }
     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewPrimaryFlightControls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #region Event to get data from FormPrincipal
        
        private void EventSubscription()
        { 
            FormPrincipal formPrincipal = Application.OpenForms.OfType<FormPrincipal>().FirstOrDefault();
            formPrincipal.IsRaspberryConnected += FormPrincipal_IsRaspberryConnected;
            formPrincipal.TransferPrimaryFlightControl += FormPrincipal_TransferPrimaryFlightControl;
            formPrincipal.TransferSecondaryFlightControl += FormPrincipal_TransferSecondaryFlightControl;
            formPrincipal.TransferSystems += FormPrincipal_TransferSystems;
            
        }
        #endregion
        private void FormADCInputs_Load(object sender, EventArgs e)
        {
            try
            {
                
                
                dataGridViewPrimaryFlightControls.Rows.Add();
                dataGridViewPrimaryFlightControls.Rows.Add();
                dataGridViewPrimaryFlightControls.Rows.Add();
                dataGridViewPrimaryFlightControls.Rows[0].HeaderCell.Value = "IN0";
                dataGridViewPrimaryFlightControls.Rows[1].HeaderCell.Value = "IN1";
                dataGridViewPrimaryFlightControls.Rows[2].HeaderCell.Value = "IN2";
                dataGridViewPrimaryFlightControls.Rows[0].Cells[0].Value = "ELEVATOR";
                dataGridViewPrimaryFlightControls.Rows[1].Cells[0].Value = "AILERON";
                dataGridViewPrimaryFlightControls.Rows[2].Cells[0].Value = "RUDDER";

                dataGridViewSecondaryFlightControls.Rows.Add();
                dataGridViewSecondaryFlightControls.Rows.Add();
                dataGridViewSecondaryFlightControls.Rows.Add();
                dataGridViewSecondaryFlightControls.Rows.Add();
                dataGridViewSecondaryFlightControls.Rows.Add();
                dataGridViewSecondaryFlightControls.Rows[0].HeaderCell.Value = "IN5";
                dataGridViewSecondaryFlightControls.Rows[1].HeaderCell.Value = "IN6";
                dataGridViewSecondaryFlightControls.Rows[2].HeaderCell.Value = "IN7";
                dataGridViewSecondaryFlightControls.Rows[3].HeaderCell.Value = "IN8";
                dataGridViewSecondaryFlightControls.Rows[4].HeaderCell.Value = "IN9";
                dataGridViewSecondaryFlightControls.Rows[0].Cells[0].Value = "FLAP";
                dataGridViewSecondaryFlightControls.Rows[1].Cells[0].Value = "SLAT";
                dataGridViewSecondaryFlightControls.Rows[2].Cells[0].Value = "SPEEDBRAKE";
                dataGridViewSecondaryFlightControls.Rows[3].Cells[0].Value = "TRIM LH";
                dataGridViewSecondaryFlightControls.Rows[4].Cells[0].Value = "TRIM RH";

                dataGridViewOtherSystems.Rows.Add();
                dataGridViewOtherSystems.Rows.Add();
                dataGridViewOtherSystems.Rows.Add();
                dataGridViewOtherSystems.Rows[0].HeaderCell.Value = "IN3";
                dataGridViewOtherSystems.Rows[1].HeaderCell.Value = "IN4";
                dataGridViewOtherSystems.Rows[2].HeaderCell.Value = "SW1";
                dataGridViewOtherSystems.Rows[0].Cells[0].Value = "THROTTLE LH";
                dataGridViewOtherSystems.Rows[1].Cells[0].Value = "THROTTLE RH";
                dataGridViewOtherSystems.Rows[2].Cells[0].Value = "LAND.GEAR";
                EventSubscription();
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
       
       
        private void FormPrincipal_IsRaspberryConnected(object sender, bool RaspberryCon)
        {
            countdownEvent = new CountdownEvent(4);
            RaspberryConnected = RaspberryCon;
            countdownEvent.Signal();
            

        }
        private void FormPrincipal_TransferPrimaryFlightControl(object sender, PrimaryFlightControl PrimaryFlightControlToReceive)
        {
            try
            {
                PrimaryFlightControl = PrimaryFlightControlToReceive;
                if(dataGridViewPrimaryFlightControls.Rows.Count > 0) 
                {
                    AppendToPrimaryDataGridView(PrimaryFlightControl);
                    countdownEvent.Signal();
                }
                
            }
            catch (Exception ex)
            {
                //string errorMessage = $"An error occurred: {ex.Message}\n\n Line: {ex.StackTrace}";
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }
        private void AppendToPrimaryDataGridView(PrimaryFlightControl PrimaryFlightControl)
        {
           

               // this.Invoke((MethodInvoker)(() =>
               // {
                    if (IsDisposed)
                    {
                        return;
                    }
                    // Acceder al objeto dataGridViewPrimaryFlightControls solo si el formulario sigue siendo válido
                    if (dataGridViewPrimaryFlightControls != null && !dataGridViewPrimaryFlightControls.IsDisposed)
                    {
                        dataGridViewPrimaryFlightControls.Rows[0].Cells[1].Value = PrimaryFlightControl.Elevator.Voltage.ToString("F3");
                        dataGridViewPrimaryFlightControls.Rows[1].Cells[1].Value = PrimaryFlightControl.Aileron.Voltage.ToString("F3");
                        dataGridViewPrimaryFlightControls.Rows[2].Cells[1].Value = PrimaryFlightControl.Rudder.Voltage.ToString("F3");
                        dataGridViewPrimaryFlightControls.Rows[0].Cells[2].Value = (100 * PrimaryFlightControl.Elevator.Voltage / PrimaryFlightControl.Elevator.MaxVoltage).ToString("F0");
                        dataGridViewPrimaryFlightControls.Rows[1].Cells[2].Value = (100 * PrimaryFlightControl.Aileron.Voltage / PrimaryFlightControl.Aileron.MaxVoltage).ToString("F0");
                        dataGridViewPrimaryFlightControls.Rows[2].Cells[2].Value = (100 * PrimaryFlightControl.Rudder.Voltage / PrimaryFlightControl.Rudder.MaxVoltage).ToString("F0");
                        dataGridViewPrimaryFlightControls.Rows[0].Cells[3].Value = PrimaryFlightControl.Elevator.Position.ToString();
                        dataGridViewPrimaryFlightControls.Rows[1].Cells[3].Value = PrimaryFlightControl.Aileron.Position.ToString();
                        dataGridViewPrimaryFlightControls.Rows[2].Cells[3].Value = PrimaryFlightControl.Rudder.Position.ToString();
                    }


               // }));
            
        }
        private void FormPrincipal_TransferSecondaryFlightControl(object sender, SecondaryFlightControl SecondaryFlightControlToReceive)
        {
            try
            {
                SecondaryFlightControl = SecondaryFlightControlToReceive;
                if(dataGridViewSecondaryFlightControls.Rows.Count > 0)
                {
                    AppendToSecondaryDataGridView(SecondaryFlightControl);
                    countdownEvent.Signal();
                }
                
            }
            catch (Exception ex)
            {
                //string errorMessage = $"An error occurred: {ex.Message}\n\n Line: {ex.StackTrace}";
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }
        private void AppendToSecondaryDataGridView(SecondaryFlightControl SecondaryFlightControl)
        {
            


               // this.Invoke((MethodInvoker)(() =>
               // {
                    if (IsDisposed)
                    {
                        return;
                    }
                    // Acceder al objeto dataGridViewPrimaryFlightControls solo si el formulario sigue siendo válido
                    if (dataGridViewSecondaryFlightControls != null && !dataGridViewSecondaryFlightControls.IsDisposed)
                    {
                        dataGridViewSecondaryFlightControls.Rows[0].Cells[1].Value = SecondaryFlightControl.Flap.Voltage.ToString("F3");
                        dataGridViewSecondaryFlightControls.Rows[1].Cells[1].Value = SecondaryFlightControl.Slat.Voltage.ToString("F3");
                        dataGridViewSecondaryFlightControls.Rows[2].Cells[1].Value = SecondaryFlightControl.Spoiler.Voltage.ToString("F3");
                        dataGridViewSecondaryFlightControls.Rows[3].Cells[1].Value = SecondaryFlightControl.ElevatorTrimLeft.Voltage.ToString("F3");
                        dataGridViewSecondaryFlightControls.Rows[4].Cells[1].Value = SecondaryFlightControl.ElevatorTrimRight.Voltage.ToString("F3");
                        dataGridViewSecondaryFlightControls.Rows[0].Cells[2].Value = (100 * SecondaryFlightControl.Flap.Voltage / SecondaryFlightControl.Flap.MaxVoltage).ToString("F0");
                        dataGridViewSecondaryFlightControls.Rows[1].Cells[2].Value = (100 * SecondaryFlightControl.Slat.Voltage / SecondaryFlightControl.Slat.MaxVoltage).ToString("F0");
                        dataGridViewSecondaryFlightControls.Rows[2].Cells[2].Value = (100 * SecondaryFlightControl.Spoiler.Voltage / SecondaryFlightControl.Spoiler.MaxVoltage).ToString("F0");
                        dataGridViewSecondaryFlightControls.Rows[3].Cells[2].Value = (100 * SecondaryFlightControl.ElevatorTrimLeft.Voltage / SecondaryFlightControl.ElevatorTrimLeft.MaxVoltage).ToString("F0");
                        dataGridViewSecondaryFlightControls.Rows[4].Cells[2].Value = (100 * SecondaryFlightControl.ElevatorTrimRight.Voltage / SecondaryFlightControl.ElevatorTrimRight.MaxVoltage).ToString("F0");
                        dataGridViewSecondaryFlightControls.Rows[0].Cells[3].Value = SecondaryFlightControl.Flap.Position.ToString();
                        dataGridViewSecondaryFlightControls.Rows[1].Cells[3].Value = SecondaryFlightControl.Slat.Position.ToString();
                        dataGridViewSecondaryFlightControls.Rows[2].Cells[3].Value = SecondaryFlightControl.Spoiler.Position.ToString();
                        dataGridViewSecondaryFlightControls.Rows[3].Cells[3].Value = SecondaryFlightControl.ElevatorTrimLeft.Position.ToString();
                        dataGridViewSecondaryFlightControls.Rows[4].Cells[3].Value = SecondaryFlightControl.ElevatorTrimRight.Position.ToString();
                     }


               // }));
            
        }
        private void FormPrincipal_TransferSystems(object sender, Systems SystemsToReceive)
        {
            try
            {
                Systems = SystemsToReceive;
                if(dataGridViewOtherSystems.Rows.Count > 0)
                {
                    AppendToSystemsDataGridView(Systems);
                    countdownEvent.Signal();
                }    
                
            }
            catch (Exception ex)
            {
                //string errorMessage = $"An error occurred: {ex.Message}\n\n Line: {ex.StackTrace}";
                //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
        }
        private void AppendToSystemsDataGridView(Systems Systems)
        {
            

               // this.Invoke((MethodInvoker)(() =>
               // {

                    if (IsDisposed)
                {
                    return;
                }
                // Acceder al objeto dataGridViewPrimaryFlightControls solo si el formulario sigue siendo válido
                if (dataGridViewOtherSystems != null && !dataGridViewOtherSystems.IsDisposed)
                {
                    dataGridViewOtherSystems.Rows[0].Cells[1].Value = Systems.Throttle1.Voltage.ToString("F3");
                    dataGridViewOtherSystems.Rows[1].Cells[1].Value = Systems.Throttle2.Voltage.ToString("F3");
                    dataGridViewOtherSystems.Rows[2].Cells[1].Value = Systems.LandingGear.State.ToString();
                    dataGridViewOtherSystems.Rows[0].Cells[2].Value = (100 * Systems.Throttle1.Voltage / Systems.Throttle1.MaxVoltage).ToString("F0");
                    dataGridViewOtherSystems.Rows[1].Cells[2].Value = (100 * Systems.Throttle2.Voltage / Systems.Throttle2.MaxVoltage).ToString("F0");
                    //dataGridViewOtherSystems.Rows[2].Cells[2].Value = (100 * Systems.LandingGear.Voltage / Systems.LandingGear.MaxVoltage).ToString();

                    dataGridViewOtherSystems.Rows[0].Cells[3].Value = Systems.Throttle1.Position.ToString();
                    dataGridViewOtherSystems.Rows[1].Cells[3].Value = Systems.Throttle2.Position.ToString();
                }


              //  }));
            
        }
      
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panelPrimaryFlightControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormADCInputs_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        
        

       
        private void FormADCInputs_FormClosing(object sender, FormClosingEventArgs e)
        {

            
            
        }
    }
}
