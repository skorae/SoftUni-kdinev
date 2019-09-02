
    public class UltrasoftTyre : Tyre
    {
        private const string name = "Ultrasoft";

        public UltrasoftTyre(double hardness,double grip)
            : base(name, hardness)
        {
            Grip = grip;
        }

        public double Grip { get;private set; }
    }
