using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


[StructLayout(LayoutKind.Sequential)]
public struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

   
}
