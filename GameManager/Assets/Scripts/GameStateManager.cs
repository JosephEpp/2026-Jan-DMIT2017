using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public List<MapState> mapStates;
    public Transform mapParent;
    private Spawner spawner;
    private MapState currentMap;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach(MapState map in mapStates)
        {
            map.InitializeEnemyDictionary();
        }
        InitializeMap(0);
    }

    public void InitializeMap(int mapID_)
    {
        foreach(MapState mapState in mapStates)
        {
            if(mapState.mapData.mapID == mapID_)
            {
                currentMap = mapState;
            }
        }

        BeginEnemySpawn(currentMap);
    }

    public void SaveMapState()
    {
        if(spawner == null) return;

        List<Enemy> activeEnemies = spawner.activeEnemies;

        foreach(Enemy enemy in activeEnemies)
        {
            currentMap.enemyDictionary[enemy.enemyID].currentHP = enemy.HP;
        }
    }

    public void BeginEnemySpawn(MapState map)
    {
        spawner = mapParent.GetComponentInChildren<Spawner>();
        foreach(EnemyState enemy in map.enemies)
        {
            if(enemy.currentHP > 0)
            {
                spawner.Spawn(enemy);
            }
        }
    }
}

[Serializable]
public class MapState
{
    public MapSO mapData;
    public List<EnemyState> enemies;
    public Dictionary<int, EnemyState> enemyDictionary;

    public void InitializeEnemyDictionary()
    {
        foreach(EnemyState enemy in enemies)
        {
            enemyDictionary.Add(enemy.enemyID, enemy);
        }
    }
}

[Serializable]
public class EnemyState
{
    public int enemyID;
    public EnemySO enemyData;
    public int currentHP;
}