﻿namespace _exerciceFigure.Classes;

public class Point
{
    public double PosX { get; set; }
    public double PosY { get; set; }

    public Point(double posX, double posY)
    {
        PosX = posX;
        PosY = posY;
    }

    public override string ToString() => $"{PosX}, {PosY}";
}