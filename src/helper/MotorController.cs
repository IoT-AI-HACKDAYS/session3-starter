using Iot.Device.DCMotor;
using System;
using System.Device.Gpio;
using System.Device.Pwm.Drivers;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace controller
{

    public class MotorController : IDisposable
    {
        

        public DCMotor LeftMotor { get; private set; }
        public DCMotor RightMotor { get; private set; }

        private GpioController Controller { get; set; }
        public bool IsStopped { get; private set; } = false;

        public MotorController(GpioController controller) : this(controller, DCMotor.Create(new SoftwarePwmChannel(AlphaBotPins.MotorSpeedA, frequency: 50), AlphaBotPins.MotorDirectionA1, AlphaBotPins.MotorDirectionA2), DCMotor.Create(new SoftwarePwmChannel(AlphaBotPins.MotorSpeedB, frequency: 50), AlphaBotPins.MotorDirectionB1, AlphaBotPins.MotorDirectionB2))
        { }

        public MotorController(GpioController controller, DCMotor leftMotor, DCMotor rightMotor)
        {
            Contract.Requires(controller != null);
            Contract.Requires(leftMotor != null);
            Contract.Requires(rightMotor != null);
            Controller = controller;
            LeftMotor = leftMotor;
            RightMotor = rightMotor;

        }


        public void MoveForward(double milliSeconds)
        {
            IsStopped = false;

            Stopwatch sw = Stopwatch.StartNew();
            RightMotor.Speed = LeftMotor.Speed = 0.5;
            
            while ((milliSeconds > sw.ElapsedMilliseconds) && !IsStopped)
            {
                Thread.Sleep(2);
            }

            Console.WriteLine("Stop");

            Stop();
        }

        public Task MoveForwardAsync(double milliSeconds)
        {
            return Task.Run(() => { MoveForward(milliSeconds); });

        }

        public void TurnLeft()
        {
            Turn(-90);
        }

        public void Turn(int angleIndegrees)
        {
            var timePerDegree = 9; //ms
            int milliSeconds = timePerDegree * Math.Abs(angleIndegrees);

            RightMotor.Speed = -0.1 * Math.Sign(angleIndegrees);
            LeftMotor.Speed = 0.1 * Math.Sign(angleIndegrees);

            Thread.Sleep(milliSeconds);

            Stop();
        }




        public void TurnRight()
        {
            Turn(90);
        }

        public void Stop()
        {
            IsStopped = true;
            RightMotor.Speed = LeftMotor.Speed = 0;
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    LeftMotor.Dispose();
                    RightMotor.Dispose();

                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MotorControl()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}


