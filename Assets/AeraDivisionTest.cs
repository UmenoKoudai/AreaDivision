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

    //�͈͂�ݒ�(�ŏ��̓}�b�v�S�̂ŕ������邲�ƂɕύX�����)
    public void CreateRange(int maxRange)
    {
        //rangeList.Add(new Range(0, 0, _mapSizeX - 1, _mapSizeY - 1));
    }

    //����ǉ�������ǉ����Ȃ����𔻒�
    public bool DevideRange(bool isVertcal)
    {
        bool isDevided = false;
        return isDevided;
    }

    //���X�g�ɓ��ꂽ�����Q�l�ɕ������쐬
    public void CreateRoom()
    {

    }

    //�o�������쐬
    public void CreatePass(Range range, Range room)
    {

    }

    //�o��������ǂ܂ł̗]���ȕ������폜
    public void TrimPassList(ref int[,] map)
    {

    }
}
