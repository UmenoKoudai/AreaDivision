using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitaializer : MonoBehaviour
{
    //マップサイズの定数
    public const int MAP_SIZE_X = 30;
    public const int MAP_SIZE_Y = 20;
    //部屋の最大数
    public const int MAX_ROOM_NUMBER = 6;

    //クリエイトするオブジェクト(プレイヤー、壁、床)
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
