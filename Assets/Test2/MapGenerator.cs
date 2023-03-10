using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator
{
    private const int MINIMUM_RANGE_WIDTH = 6;

    private int _mapSizeX;
    private int _mapSizeY;
    private int _maxRoom;

    private List<Range> roomList = new List<Range>();
    private List<Range> rangeList = new List<Range>();
    private List<Range> passList = new List<Range>();
    private List<Range> roomPassList = new List<Range>();

    private bool isGenerated = false;

    public int[,] GenerateMap(int mapSizeX, int mapSizeY, int maxRoom)
    {
        this._mapSizeX = mapSizeX;
        this._mapSizeY = mapSizeY;

        int[,] map = new int[mapSizeX, mapSizeY];

        CreateRange(maxRoom);
        CreateRoom();

        foreach (Range pass in passList)
        {
            for(int x = pass.Start._x; x < pass.End._x; x++)
            {
                for(int y = pass.Start._y; y < pass.End._y; y++)
                {
                    map[x, y] = 1;
                }
            }
        }

        foreach (Range roomPass in roomPassList)
        {
            for (int x = roomPass.Start._x; x < roomPass.End._y; x++)
            {
                for (int y = roomPass.Start._y; y < roomPass.End._y; y++)
                {
                    map[x, y] = 1;
                }
            }
        }

        foreach (Range room in roomList)
        {
            for (int x = room.Start._x; x < room.End._x; x++)
            {
                for (int y = room.Start._y; y < room.End._y; y++)
                {
                    map[x, y] = 1;
                }
            }
        }
        TrimPassList(ref map);
        return map;
    }

    public void CreateRange(int maxRoom)
    {
        rangeList.Add(new Range(0, 0, _mapSizeX - 1, _mapSizeY - 1));

        bool isDevided;
        do
        {
            isDevided = DevideRange(false);
            isDevided = DevideRange(true) || isDevided;
            if (rangeList.Count >= maxRoom)
            {
                break;
            }
        } while (isDevided);
    }

    public bool DevideRange(bool isVertical)
    {
        bool isDevided = false;

        List<Range> newRangeList = new List<Range>();
        foreach(Range range in rangeList)
        {
            if(isVertical && range.GetWidthY() < MINIMUM_RANGE_WIDTH * 2 + 1)
            {
                continue;
            }
            else if(!isVertical && range.GetWidthX() < MINIMUM_RANGE_WIDTH * 2 + 1)
            {
                continue;
            }

            System.Threading.Thread.Sleep(1);

            if (rangeList.Count > 1 && RogueUtils.RandomJadge(0.4f))
            {
                continue;
            }

            int length = isVertical ? range.GetWidthY() : range.GetWidthX();
            int margin = length - MINIMUM_RANGE_WIDTH * 2;
            int baseIndex = isVertical ? range.Start._y : range.Start._x;
            int devideIndex = baseIndex + MINIMUM_RANGE_WIDTH + RogueUtils.GetRandomInt(1, margin) - 1;

            Range newRange = new Range();
            if(isVertical)
            {
                passList.Add(new Range(range.Start._x, devideIndex, range.End._x, devideIndex));
                newRange = new Range(range.Start._x, devideIndex + 1, range.End._x, range.End._y);
                range.End._y = devideIndex - 1;
            }
            else
            {
                passList.Add(new Range(devideIndex, range.Start._y, devideIndex, range.End._y));
                newRange = new Range(devideIndex, range.Start._y, range.End._x, range.End._y);
                range.End._x = devideIndex - 1;
            }
            newRangeList.Add(newRange);
            isDevided = true;
        }
        rangeList.AddRange(newRangeList);
        return isDevided;
    }

    private void CreateRoom()
    {
        rangeList.Sort((a, b) => RogueUtils.GetRandomInt(0, 1) - 1);

        foreach(Range range in rangeList)
        {
            System.Threading.Thread.Sleep(1);
            if(roomList.Count > _maxRoom / 2 && RogueUtils.RandomJadge(0.3f))
            {
                continue;
            }
            int marginX = range.GetWidthX() - MINIMUM_RANGE_WIDTH + 1;
            int marginY = range.GetWidthY() - MINIMUM_RANGE_WIDTH + 1;

            int randomX = RogueUtils.GetRandomInt(1, marginX);
            int randomY = RogueUtils.GetRandomInt(1, marginY);

            int startX = range.Start._x + randomX;
            int endX = range.End._x - RogueUtils.GetRandomInt(0, (marginX - randomX)) - 1;
            int startY = range.Start._y + randomY;
            int endY = range.End._y - RogueUtils.GetRandomInt(0, (marginY - randomY)) - 1;

            Range room = new Range(startX, startY, endX, endY);
            roomList.Add(room);

            CreatePass(range, room);
        }
    }

    private void CreatePass(Range range, Range room)
    {
        List<int> directionList = new List<int>();
        if(range.End._x != 0)
        {
            directionList.Add(0);
        }
        if(range.End._x != _mapSizeX - 1)
        {
            directionList.Add(1);
        }
        if(range.Start._y != 0)
        {
            directionList.Add(2);
        }
        if(range.End._y != _mapSizeY - 1)
        {
            directionList.Add(3);
        }

        directionList.Sort((a, b) => RogueUtils.GetRandomInt(0, 1) - 1);

        bool isFirst = true;
        foreach(int direction in directionList)
        {
            System.Threading.Thread.Sleep(1);
            if(!isFirst && RogueUtils.RandomJadge(0.8f))
            {
                continue;
            }
            else
            {
                isFirst = false;
            }

            int random;
            switch(direction)
            {
                case 0:
                    random = room.Start._y + RogueUtils.GetRandomInt(1, room.GetWidthY()) - 1;
                    roomPassList.Add(new Range(room.Start._x, random, room.Start._x - 1, random));
                    break;

                case 1:
                    random = room.Start._y + RogueUtils.GetRandomInt(1, room.GetWidthY()) - 1;
                    roomPassList.Add(new Range(room.End._x + 1, random, range.End._x, random));
                    break;

                case 2:
                    random = room.Start._x + RogueUtils.GetRandomInt(1, room.GetWidthX()) - 1;
                    roomPassList.Add(new Range(random, range.Start._y, random, room.Start._y - 1));
                    break;

                case 3:
                    random = room.Start._x + RogueUtils.GetRandomInt(1, room.GetWidthX()) - 1;
                    roomPassList.Add(new Range(random, room.End._y + 1, random, room.End._y));
                    break;
            }
        }
    }

    private void TrimPassList(ref int[,] map)
    {
        for(int i = passList.Count - 1; i >= 0; i--)
        {
            Range pass = passList[i];
            bool isVertical = pass.GetWidthY() > 1;

            bool isTrimTarget = true;
            if(isVertical)
            {
                int x = pass.Start._x;
                for(int y = pass.Start._y; y < pass.End._y; y++)
                {
                    if(map[x - 1, y] == 1 || map[x + 1, y] == 1)
                    {
                        isTrimTarget = false;
                        break;
                    }
                }
            }
            else
            {
                int y = pass.Start._y;
                for(int x = pass.Start._x; x < pass.End._x; x++)
                {
                    if(map[x, y - 1] == 1 || map[x, y + 1] == 1)
                    {
                        isTrimTarget = false;
                        break;
                    }
                }
            }

            if(isTrimTarget)
            {
                passList.Remove(pass);

                if(isVertical)
                {
                    int x = pass.Start._x;
                    for(int y = pass.Start._y; y < pass.End._y; y++)
                    {
                        map[x, y] = 0;
                    }
                }
                else
                {
                    int y = pass.Start._y;
                    for(int x = pass.Start._x; x < pass.End._x; x++)
                    {
                        map[x, y] = 0;
                    }
                }
            }
        }

        for(int x = 0; x < _mapSizeX - 1; x++)
        {
            if(map[x, 0] == 1)
            {
                for(int y = 0; y < _mapSizeY; y++)
                {
                    if(map[x - 1, y] == 1 || map[x + 1, y] == 1)
                    {
                        break;
                    }
                    map[x, y] = 0;
                }
            }
            if(map[x, _mapSizeY - 1] == 1)
            {
                for(int y = _mapSizeY - 1; y >= 0; y--)
                {
                    if(map[x - 1, y] == 1 || map[x + 1, y] == 1)
                    {
                        break;
                    }
                    map[x, y] = 0;
                }
            }
        }

        for(int y = 0; y < _mapSizeY - 1; y++)
        {
            if(map[0, y] == 1)
            {
                for(int x = 0; x < _mapSizeY; x++)
                {
                    if(map[x, y - 1] == 1 || map[x, y + 1] == 1)
                    {
                        break;
                    }
                    map[x, y] = 0;
                }
            }
            if(map[_mapSizeX - 1, y] == 1)
            {
                for(int x = _mapSizeX - 1; x >= 0; x++)
                {
                    if(map[x, y - 1] == 1 || map[x, y + 1] == 1)
                    {
                        break;
                    }
                    map[x, y] = 0;
                }
            }
        }
    }
}
