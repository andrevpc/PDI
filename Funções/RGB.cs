using System;
using System.Collections.Generic;

class RGB
{
    public byte R;
    public byte G;
    public byte B;

    public RGB()
    {

    }

    public RGB(byte r, byte g, byte b)
    {
        this.R = r;
        this.G = g;
        this.B = b;
    }

    public float Distance(RGB point) => (
        (this.R - point.R) * (this.R - point.R) + 
        (this.B - point.B) * (this.B - point.B) + 
        (this.G - point.G) * (this.G - point.G));
}

class RandomRGB : RGB
{
    public List<RGB> Cluster;

    public RandomRGB()
    {
        Random rnd = new Random();
        this.R = (byte)rnd.Next(255);
        this.G = (byte)rnd.Next(255);
        this.B = (byte)rnd.Next(255);

        this.Cluster = new List<RGB>();
    }
}