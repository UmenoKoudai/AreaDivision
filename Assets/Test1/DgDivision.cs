using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgDivision
{
    public class DgRect
    {
        public int Left = 0;
        public int Top = 0;
        public int Right = 0;
        public int Bottom = 0;

        public DgRect()
        {

        }

        public void Set(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public int Width { get => Right - Left; }
        public int Height { get => Bottom - Top; }
        public int Measure { get => Width * Height; }

        public void Copy(DgRect rect)
        {
            Left = rect.Left;
            Top = rect.Top;
            Right = rect.Right;
            Bottom = rect.Bottom;
        }

        public void Dump()
        {
            Debug.Log(string.Format("<Rect l,t,r,b = {0},{1},{2},{3}> w,h = {4},{5}", Left, Top, Right, Bottom, Width, Height));
        }
    }

    public DgRect Outer;
    public DgRect Room;

    public DgDivision()
    {
        Outer = new DgRect();
        Room = new DgRect();
    }

    public void Dump()
    {
        Outer.Dump();
        Room.Dump();
    }
}
