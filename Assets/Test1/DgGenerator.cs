using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DgGenerator : MonoBehaviour
{
    Layer2D _layer;
    List<DgDivision> _divList;

    void Start()
    {
        _layer = new Layer2D(10,10);
        _divList = new List<DgDivision>();
        _layer.Fill(1);
    }

    void CreateDivision(int left, int top, int right, int bottom)
    {
        DgDivision div = new DgDivision();
        div.Outer.Set(left, top, right, bottom);
        _divList.Add(div);
    }

    void SplitDivision(bool bVertical)
    {
        DgDivision parent = _divList[_divList.Count - 1];
        _divList.Remove(parent);
    }
}
