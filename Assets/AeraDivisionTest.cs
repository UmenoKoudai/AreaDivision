using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class AeraDivisionTest : MonoBehaviour
{
    [SerializeField] int _mapSizeX;
    [SerializeField] int _mapSizeY;
    List<int> rangeList = new List<int>();

    //範囲を設定(最初はマップ全体で分割するごとに変更される)
    public void CreateRange(int maxRange)
    {
        //rangeList.Add(new Range(0, 0, _mapSizeX - 1, _mapSizeY - 1));
    }

    //区域を追加したり追加しないかを判定
    public bool DevideRange(bool isVertcal)
    {
        bool isDevided = false;
        return isDevided;
    }

    //リストに入れた区域を参考に部屋を作成
    public void CreateRoom()
    {

    }

    //出入口を作成
    public void CreatePass(Range range, Range room)
    {

    }

    //出入口から壁までの余分な部分を削除
    public void TrimPassList(ref int[,] map)
    {

    }
}
