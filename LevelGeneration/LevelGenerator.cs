using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    public Vector3Int StartPoint = Vector3Int.zero;
    public int IslandCount = 20;
    public int MinimumGap = 2;
    public int MaximumGap = 5;
    [Range(0,100)]
    public int EvenRatio = 50;
    [Range(0, 100)]
    public int UpRatio = 50;
    public int MaximumUp = 2;
    public int MaximumDown = -5;
    public int MinimumIslandSize = 2;
    public int MaximumIslandSize = 20;
    public int MinimumIslandHeight = 2;
    public int MaximumIslandHeight = 5;
    public int BackgroundOffset = -1;
    public List<Island> Islands;
    public RuleTile FloorTile;
    public RuleTile BackgroundTile;
    public Vector3 GroundClutterOffset = Vector3.up;
    public GameObject[] GroundClutter;
    [Range(0, 100)]
    public int GroundClutterFill = 50;
    public Tilemap BackgroundMap;
    public GameObject[] Enemies;
    [Range(0, 100)]
    public float EnemySpawnRatio = 10;
    public Vector3 EnemySpawnOffset = Vector3.up;
    public GameObject EndCity;

    public GameObject ZipLinePrefab;
    public int ZipLineCount = 0;
    public float ZipLineLength = 15f;

    public GameObject CannonPrefab;
    public int CannonCount = 0;
    public float CannonFiringDistance = 25f;

    private Tilemap _tileMap;
    private Vector3Int _islandCursor;

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnRatio = PlayerStats.Instance.EnemySpawnRatio;
        CannonCount = PlayerStats.Instance.CannonCount;
        CannonFiringDistance = PlayerStats.Instance.CannonFiringDistance;
        ZipLineCount = PlayerStats.Instance.ZipLineCount;
        ZipLineLength = PlayerStats.Instance.ZipLineLength;
        _tileMap = GetComponent<Tilemap>();
        GetLevelOptions();
        BuildLevel();
    }

    private void GetLevelOptions()
    {
        var options = PlayerStats.Instance.UpcomingArea;
        IslandCount = options.IslandCount;
        MinimumGap = options.MinimumGap;
        MaximumGap = options.MaximumGap;
        EvenRatio = options.EvenRatio;
        UpRatio = options.UpRatio;
        MaximumUp = options.MaximumUp;
        MaximumDown = options.MaximumDown;
        MinimumIslandSize = options.MinimumIslandSize;
        MaximumIslandSize = options.MaximumIslandSize;
        MinimumIslandHeight = options.MinimumIslandHeight;
        MaximumIslandHeight = options.MaximumIslandHeight;
        FloorTile = options.FloorTile;
        _tileMap.color = options.FGColor;
        BackgroundTile = options.BackgroundTile;
        BackgroundOffset = options.BackgroundOffset;
        BackgroundMap.color = options.BGColor;
        GroundClutterOffset = options.GroundClutterOffset;
        GroundClutter = options.GroundClutter;
        GroundClutterFill = options.GroundClutterFill;
        Enemies = options.Enemies;
    }

    private void BuildLevel()
    {
        ClearTiles();
        _islandCursor = StartPoint;

        for (var i = 0; i < IslandCount; i++)
        {
            Islands.Add(BuildIsland());
            JumpCursor();
        }

        SpawnEndIsland();

        foreach (var island in Islands)
        {
            InstantiateIsland(island);
        }

        SpawnZipLines();
        SpawnCannons();
    }

    private void SpawnZipLines()
    {
        var F = Islands.SelectMany(o => o.FloorLine).ToList();
        for (var i = 0; i < ZipLineCount; i++)
        {
            var start = (int)UnityEngine.Random.Range(0, (int)(F.Count - ZipLineLength));
            var end = (int)(start + ZipLineLength);
            var zipline = Instantiate(ZipLinePrefab, F[start]+GroundClutterOffset, Quaternion.identity);
            zipline.GetComponent<ZipLine>().Setup(F[start] + GroundClutterOffset, F[end] + GroundClutterOffset);
        }
    }

    private void SpawnCannons()
    {
        var F = Islands.SelectMany(o => o.FloorLine).ToList();
        for (var i = 0; i < CannonCount; i++)
        {
            var start = (int)UnityEngine.Random.Range(0, (int)(F.Count - CannonFiringDistance));
            var end = (int)(start + CannonFiringDistance);
            var zipline = Instantiate(CannonPrefab, F[start] + GroundClutterOffset, Quaternion.identity);
        }
    }

    private void SpawnEndIsland()
    {
        Instantiate(EndCity, _islandCursor, Quaternion.identity);
    }

    public void ClearTiles()
    {
        foreach (var pos in _tileMap.cellBounds.allPositionsWithin)
        {
            _tileMap.SetTile(pos, null);
        }
    }

    public Tile RandomTile(Tile[] tiles)
    {
        return tiles[UnityEngine.Random.Range(0, tiles.Length)];
    }

    private void InstantiateIsland(Island island)
    {
        var floorTile = FloorTile;
        foreach (var tilePosition in island.FloorLine)
        {
            _tileMap.SetTile(tilePosition, floorTile);
            DoGroundClutter(tilePosition);
        }

        var L = island.FloorLine.Length;
        var H = UnityEngine.Random.Range(MinimumIslandHeight, MaximumIslandHeight);
        var C = H;

        for(var i = L/2; i < L; i++)
        {
            InstantiateIslandDepth(island.FloorLine[i], C);
            InstantiateIslandHeight(island.FloorLine[i], C+BackgroundOffset);
            C -= UnityEngine.Random.Range(0, 2);
            InstantiateEnemy(island.FloorLine[i]);
        }

        C = H;

        for (var i = L / 2; i >= 0; i--)
        {
            InstantiateIslandDepth(island.FloorLine[i], C);
            InstantiateIslandHeight(island.FloorLine[i], C + BackgroundOffset);
            C -= UnityEngine.Random.Range(0, 2);
        }
    }

    private void InstantiateEnemy(Vector3Int vector3Int)
    {
        if (UnityEngine.Random.Range(0, 100) > EnemySpawnRatio)
            return;
        Instantiate(Enemies.Random(), vector3Int + EnemySpawnOffset, Quaternion.identity);
    }

    private void DoGroundClutter(Vector3Int tilePosition)
    {
        if (GroundClutter == null || GroundClutter.Length == 0)
            return;
        if(UnityEngine.Random.Range(0, 100)<= GroundClutterFill)
        {
            Instantiate(GroundClutter.Random(), tilePosition+GroundClutterOffset, Quaternion.identity);
        }
    }

    private void InstantiateIslandDepth(Vector3Int v, int c)
    {
        var D = v;
        for(var i = 0; i < c; i++)
        {
            D.y--;
            _tileMap.SetTile(D, FloorTile);
        }
    }

    private void InstantiateIslandHeight(Vector3Int v, int c)
    {
        var D = v;
        D.y -= 1;
        for (var i = -1; i < c; i++)
        {
            D.y++;
            BackgroundMap.SetTile(D, BackgroundTile);
        }
    }

    private void JumpCursor()
    {
        var gap = UnityEngine.Random.Range(MinimumGap, MaximumGap);
        _islandCursor.x += gap;
    }

    private Island BuildIsland()
    {
        var islandSize = UnityEngine.Random.Range(MinimumIslandSize, MaximumIslandSize);
        
        var line = new List<Vector3Int>();
        for (var i = 0; i < islandSize; i++)
        {
            line.Add(_islandCursor);
            MoveCursor();
        }

        return new Island
        {
            FloorLine = line.ToArray()
        };
    }

    private void MoveCursor()
    {
        _islandCursor.x += 1;
        if (UnityEngine.Random.Range(0, 100) <= EvenRatio)
            return;
        bool Up = UnityEngine.Random.Range(0, 100) <= UpRatio;
        _islandCursor.y += UnityEngine.Random.Range(Up ? 0 : MaximumDown, Up ? MaximumUp : 0);
    }
}

[Serializable]
public class Island
{ 
    public Vector3Int[] FloorLine;
    public int Size { 
        get
        {
            if (FloorLine == null)
                return 0;
            return FloorLine.Length;
        } 
    }
}
