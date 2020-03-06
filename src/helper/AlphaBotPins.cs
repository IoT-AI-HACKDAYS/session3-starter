namespace controller
{
    public static class AlphaBotPins
    {
        /// <summary>
        /// Left motor forward controll
        /// </summary>
        public const int MotorDirectionA1 = 12;
        /// <summary>
        /// Left motor reverse controll
        /// </summary>
        public const int MotorDirectionA2 = 13;
        /// <summary>
        /// Left motor speed
        /// </summary>
        public const int MotorSpeedA = 6;

        /// <summary>
        /// Right motor forward controll
        /// </summary>
        public const int MotorDirectionB1 = 20;
        /// <summary>
        /// Right motor reverse controll
        /// </summary>
        public const int MotorDirectionB2 = 21;
        /// <summary>
        /// Right motor speed
        /// </summary>
        public const int MotorSpeedB = 26;

        /// <summary>
        /// Needs a PinMode of InputPullUp, goes low or 0 if collision is detected
        /// </summary>
        public const int CollisionSensorPinLeft = 16;

        /// <summary>
        /// Needs a PinMode of InputPullUp, goes low or 0 if collision is detected
        /// </summary>
        public const int CollisionSensorPinRight = 19;

        /// <summary>
        /// Joystick button
        /// </summary>
        public const int JoystickCenter = 7;

        /// <summary>
        /// The buzzer
        /// </summary>
        public const int Buzzer = 4;
    }
}