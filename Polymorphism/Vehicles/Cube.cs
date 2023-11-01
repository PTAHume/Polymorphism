using System;

namespace PolymorphismC
{
    class Cube : Shape
    {
        public double Length { get; set; }

        public Cube(int length)
        {
            Name = "Cube";
            Length = length;
        }

        public override double Volume()
        {
            return Math.Pow(Length, 3);
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"The Cube has a length of {Length}");
        }

    }
}
