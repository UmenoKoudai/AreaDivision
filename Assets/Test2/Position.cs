using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    public int _x { get; set; }
    public int _y { get; set; }

    public Position(int x, int y)
    {
        this._x = x;
        this._y = y;
    }

    public Position() : this(0, 0) { }

    public override string ToString()
    {
        return string.Format("{0}, {1}", _x, _y);
    }
}
