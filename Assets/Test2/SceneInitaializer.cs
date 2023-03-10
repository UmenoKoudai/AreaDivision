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

    [Header("マップの情報")]
    [SerializeField, Tooltip("マップのサイズX")] int _mapSizeX;
    [SerializeField, Tooltip("マップのサイズY")] int _mapSizeY;
    [SerializeField, Tooltip("部屋の数")] int _maxRoom;
    //クリエイトするオブジェクト(プレイヤー、壁、床)
    public GameObject _player;
    private GameObject _floorPrefab;
    private GameObject _wallPrefab;

    private int[,] map;

    private void Awake()
    {
        if(!_player)
        {
            _player = (GameObject)Resources.Load("Player");
            Instantiate(_player, transform.position, transform.rotation);
        }
    }
    public void CreateMapButton()
    {
        GenerateMap();
        SponePlayer();
    }

    private void GenerateMap()
    {
        map = new MapGenerator().GenerateMap(_mapSizeX, _mapSizeY, _maxRoom);
        string log = "";
        for(int y = 0; y < _mapSizeY; y++)
        {
            for(int x = 0; x < _mapSizeX; x++)
            {
                log += map[x, y] == 0 ? " " : "1";
            }
            log += "\n";
        }
        Debug.Log(log);

        _floorPrefab = (GameObject)Resources.Load("Floor");
        _wallPrefab = (GameObject)Resources.Load("Wall");

        var floorList = new List<Vector3>();
        var wallList = new List<Vector3>();

        for(int y = 0; y < _mapSizeY; y++)
        {
            for(int x = 0; x < _mapSizeX; x++)
            {
                if(map[x, y] == 1)
                {
                    Instantiate(_floorPrefab, new Vector3(x, y, 0), new Quaternion());
                }
                else
                {
                    Instantiate(_wallPrefab, new Vector3(x, y, 0), new Quaternion());
                }
            }
        }
    }

    private void SponePlayer()
    {
        Debug.Log("実行");
        if(!_player)
        {
            return;
        }

        Position position;
        do
        {
            var x = RogueUtils.GetRandomInt(0, _mapSizeX - 1);
            var y = RogueUtils.GetRandomInt(0, _mapSizeY - 1);
            position = new Position(x, y);
        } while (map[position._x, position._y] != 1);

        _player.transform.position = new Vector3(position._x, position._y, 0);
    }
}
