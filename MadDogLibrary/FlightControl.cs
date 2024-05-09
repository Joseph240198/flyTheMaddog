using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MadDogLibrary.PrimaryFlightControl;

namespace MadDogLibrary
{
    #region PrimaryFlightControl class
    public class PrimaryFlightControl
    {
        public ElevatorControl Elevator { get; private set; }
        public AileronControl Aileron { get; private set; }
        public RudderControl Rudder { get; private set; }

        public PrimaryFlightControl()
        {
            Elevator = new ElevatorControl();
            Aileron = new AileronControl();
            Rudder = new RudderControl();
        }
        public void SetPrimaryCalibratedVoltages(float[,] calibratedVoltages)
        {
            this.Elevator.MaxVoltage = calibratedVoltages[0, 1];
            this.Elevator.MinVoltage = calibratedVoltages[0, 0];
            this.Aileron.MaxVoltage = calibratedVoltages[1, 1];
            this.Aileron.MinVoltage = calibratedVoltages[1, 0];
            this.Rudder.MaxVoltage = calibratedVoltages[2, 1];
            this.Rudder.MinVoltage = calibratedVoltages[2, 0];
        }
        public class ElevatorControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }

        public class AileronControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }

        public class RudderControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }
    }
    #endregion

    #region SecondaryFlightControl class
    public class SecondaryFlightControl
    {
        public FlapControl Flap { get; private set; }
        public SlatControl Slat { get; private set; }
        public SpoilerControl Spoiler { get; private set; }
        public ElevatorTrimLeftControl ElevatorTrimLeft { get; private set; }
        public ElevatorTrimRightControl ElevatorTrimRight { get; private set; }
        public RudderTrimControl RudderTrim { get; private set; }
        public AileronTrimControl AileronTrim { get; private set; }

        public SecondaryFlightControl()
        {
            Flap = new FlapControl();
            Slat = new SlatControl();
            Spoiler = new SpoilerControl();
            ElevatorTrimLeft = new ElevatorTrimLeftControl();
            ElevatorTrimRight = new ElevatorTrimRightControl();
            RudderTrim = new RudderTrimControl();
            AileronTrim = new AileronTrimControl();
        }
        public void SetSecondaryCalibratedVoltages(float[,] calibratedVoltages)
        {
            this.Flap.MaxVoltage = calibratedVoltages[5, 1];
            this.Flap.MinVoltage = calibratedVoltages[5, 0];
            this.Slat.MaxVoltage = calibratedVoltages[6, 1];
            this.Slat.MinVoltage = calibratedVoltages[6, 0];
            this.Spoiler.MaxVoltage = calibratedVoltages[7, 1];
            this.Spoiler.MinVoltage = calibratedVoltages[7, 0];
            this.ElevatorTrimLeft.MaxVoltage = calibratedVoltages[8, 1];
            this.ElevatorTrimLeft.MinVoltage = calibratedVoltages[8, 0];
            this.ElevatorTrimRight.MaxVoltage = calibratedVoltages[9, 1];
            this.ElevatorTrimRight.MinVoltage = calibratedVoltages[9, 0];
        }
        public class FlapControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }
        public class SlatControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }
        public class SpoilerControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }

        public class ElevatorTrimLeftControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }
        public class ElevatorTrimRightControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }

        public class RudderTrimControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
        }

        public class AileronTrimControl
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
        }
    }
    #endregion

    #region Systems class
    public class Systems
    {
        public Throttle1Control Throttle1 { get; private set; }
        public Throttle2Control Throttle2 { get; private set; }
        public LandingGearControl LandingGear { get; private set; }

        public Systems()
        {
            Throttle1 = new Throttle1Control();
            Throttle2 = new Throttle2Control();
            LandingGear = new LandingGearControl();
        }
        public void SetSystemsCalibratedVoltages(float[,] calibratedVoltages)
        {
            this.Throttle1.MinVoltage = calibratedVoltages[3, 0];
            this.Throttle1.MaxVoltage = calibratedVoltages[3, 1];
            this.Throttle2.MinVoltage = calibratedVoltages[4, 0];
            this.Throttle2.MaxVoltage = calibratedVoltages[4, 1];
            
        }
        public class Throttle1Control
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }

        public class Throttle2Control
        {
            public float Voltage { get; set; }
            public float Position { get; set; }
            public float MaxVoltage { get; set; }
            public float MinVoltage { get; set; }
        }

        public class LandingGearControl
        {
            public int State { get; set; }
            public int Position { get; set; }
            
        }
    }
    #endregion

    #region Functions class
    public class Functions
    {
        public object MessageBox { get; private set; }

        public float Map(float p, float x1, float x2, float y1, float y2, bool intervalFlag)
        {
            float m = (y2 - y1) / (x2 - x1);
            float n = y1 - m * x1;
            float result = (m * p + n);
            // intervalFlag = true -> [-16383.00,16383.00]
            //intervalFlag = false -> [0.00,16383.00]
            if(intervalFlag)
            {
                if (result < -16383.00f || result > 16383.00f)
                {
                    if(result < 0.00f)
                    {
                        return -16383.00f;
                    }
                    else
                    {
                        return 16383.00f;
                    }
                }
                else 
                {
                    return result;
                }
            }
            else
            {
                if (result < 0.00f || result > 16383.00f)
                {
                    if (result < 0.00f)
                    {
                        return 0.00f;
                    }
                    else
                    {
                        return 16383.00f;
                    }
                }
                else
                {
                    return result;
                }
            }
        }
        public float[,] CalibrationFunction(float[,] calibrationVoltages)
        {
            
            float[,] minsMaxsVoltages = new float[calibrationVoltages.GetLength(0),2];
            float[] auxArray = new float[1000];
            for (int i = 0; i < calibrationVoltages.GetLength(0); i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    auxArray[j] = calibrationVoltages[i, j];

                }
                minsMaxsVoltages[i, 0] = auxArray.Min();
                minsMaxsVoltages[i, 1] = auxArray.Max();
                Array.Clear(auxArray, 0, auxArray.Length);
            }

            return minsMaxsVoltages;
        }
        public float[,] ReadCalibrationFile(string filePath)
        {
            float[,] minAndMaxVoltages = new float[11, 2];
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    string minValue;
                    string maxValue;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        minValue = line.Split(';')[0];
                        maxValue = line.Split(';')[1];
                        minAndMaxVoltages[i, 0] = float.Parse(minValue);
                        minAndMaxVoltages[i, 1] = float.Parse(maxValue);
                        i++;
                    }
                }
                return minAndMaxVoltages;
            }
            catch (Exception)
            {
                minAndMaxVoltages = null;
                return minAndMaxVoltages;
            }

        }
        public int WriteLineToCalibrationFile(int lineNumber, string lineToWrite, string filePath)
        {
            // Read file
            string[] lineas = File.ReadAllLines(filePath);
            try
            {
                // Check if line number is valid
                if (lineNumber >= 0 && lineNumber <= (lineas.Length -1))
                {
                    // Write line in specified position
                    lineas[lineNumber] = lineToWrite;

                    // Overwrite file content with modified line
                    File.WriteAllLines(filePath, lineas);
                    return lineToWrite.Length;
                }
                else
                {
                    //if line number is not valid
                   return 1;
                }
            }
            catch(Exception)
            { return 0; }

        }
    }
    #endregion
}
