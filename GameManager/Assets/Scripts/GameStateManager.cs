using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public List<MapState> mapStates;
    public Transform mapParent;
    private Spawner spawner;

    public void InitializeMap(int mapID_)
    {
        MapState targetMap = null;
        foreach(MapState mapState in mapStates)
        {
            if(mapState.mapID == targetMap.mapID)
            {
                targetMap = mapState;
            }
        }

        BeginEnemySpawn(targetMap);
    }

    public void BeginEnemySpawn(MapState map)
    {
        spawner = mapParent.GetComponentInChildren<Spawner>();
        foreach(EnemyState enemy in map.enemies)
        {
            spawner.Spawn(enemy.enemyData, enemy.currentHP);
        }
    }
}

[Serializable]
public class MapState
{
    public int mapID;
    
    public List<EnemyState> enemies;
}

[Serializable]
public class EnemyState
{
    public int enemyID;
    public EnemySO enemyData;
    public int currentHP;
}