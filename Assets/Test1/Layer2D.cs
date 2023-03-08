using System.Collections;
using UnityEngine;

public class Layer2D
{
    int _width;
    int _height;
    int _outOfRange = -1;
    int[] _values = null;

    public int Wigth { get => _width; }
    public int Height { get => _height; }

    public Layer2D(int width = 0, int height = 0)
    {
        if(width > 0 && height > 0)
        {
            Create(width, height);
        }
    }

    public void Create(int width, int height)
    {
        _width = width;
        _height = height;
        _values = new int[Wigth * Height];
    }

    //座標をインデックスに変換
    public int ToIndex(int x, int y)
    {
        return x + (y * Wigth);
    }

    //座標が範囲外嘩判定する
    public bool IsOutOfRange(int x, int y)
    {
        if(x < 0 || y >= Wigth)
        {
            return true;
        }
        if(y < 0 || y >= Height)
        {
            return true;
        }

        return false;
    }

    public int Get(int x, int y)
    {
        if(IsOutOfRange(x, y))
        {
            return _outOfRange;
        }
        return _values[y * Wigth + x];
    }

    public void Set(int x, int y, int v)
    {
        //Setしようとした座標が範囲外か判定
        if(IsOutOfRange(x, y))
        {
            return;
        }
        _values[y * Wigth + x] = v;
    }

    public void Fill(int value)
    {
        for(int y = 0; y < Height; y++)
        {
            for(int x = 0; x < Wigth; x++)
            {
                Set(x, y, value);
            }
        }
    }

    public void FillRect(int x, int y, int w, int h, int value)
    {
        for(int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                int px = x + j;
                int py = y + j;
                Set(px, py, value);
            }
        }
    }

    public void FillRectLTRB(int left, int top, int right, int bottom, int value)
    {
        FillRect(left, top, right - left, bottom - top, value);
    }

    public void Dump()
    {
        Debug.Log($"[Layer2D](w,h) = ({Wigth},{Height})");
        for(int y = 0; y < Height; y++)
        {
            string s = "";
            for(int x = 0; x < Wigth; x++)
            {
                s += Get(x, y) + ",";
            }
            Debug.Log(s);
        }
    }
}
