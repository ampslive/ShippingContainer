using System;

namespace ShippingContainer
{
    public class Crate
    {
        public int Volume { get; set; }

        public Crate(int volume)
        {
            Volume = volume;
        }
    }
}