using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitaializer : MonoBehaviour
{
    //�}�b�v�T�C�Y�̒萔
    public const int MAP_SIZE_X = 30;
    public const int MAP_SIZE_Y = 20;
    //�����̍ő吔
    public const int MAX_ROOM_NUMBER = 6;

    //�N���G�C�g����I�u�W�F�N�g(�v���C���[�A�ǁA��)
    public GameObject _player;
    private GameObject _floorPrefab;
    private GameObject _wallPrefab;

    private int[,] map;

    private void Start()
    {
        
    }

    //private void GenerateMap()
    //{
    //    map = new Map
    //}
}
