using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public GameState gameState;
    //public Transform mapParent;
    public GameObject mapParent;
    private Spawner spawner;
    public MapState currentMapState;
    private PlayerCombatController player;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach(MapState map in gameState.mapStates)
        {
            map.InitializeEnemyDictionary();
        }
        InitializeMap(0);

        LoadPlayerStats();
    }

    public void InitializeMap(int mapID_)
    {
        foreach(MapState mapState in gameState.mapStates)
        {
            if(mapState.mapID == mapID_)
            {
                currentMapState = mapState;
                BeginEnemySpawn(currentMapState);
                break;
            }
        }
    }

    public void LoadPlayerStats()
    {
        player = FindFirstObjectByType<PlayerCombatController>();

        player.currentHP = gameState.currentHP;
        player.maxHP = gameState.maxHP;
        player.ATK = gameState.ATK;
        player.DEF = gameState.DEF;
    }

    public void BeginEnemySpawn(MapState map)
    {
        spawner = mapParent.GetComponentInChildren<Spawner>();
        foreach(EnemyState enemy in map.enemyStates)
        {
            if(enemy.currentHP > 0)
            {
                spawner.Spawn(enemy.enemyID, enemy.currentHP);
            }
        }
    }

    public void ResetEnemies()
    {
        foreach (MapState m in gameState.mapStates)
        {
            foreach (EnemyState e in m.enemyStates)
            {
                e.currentHP = e.maxHP;
            }
        }
    }

    public void CollectTreasure()
    {
        if(currentMapState.hasTreasure && !currentMapState.treasureCollected)
        {
            currentMapState.treasureCollected = true;
            gameState.treasure++;
        }
    }

    [ContextMenu("Try Save")]
    public void SaveGameState()
    {
        if (spawner != null)
        {
            List<Enemy> enemies = spawner.activeEnemies;
            if(enemies.Count <= 0)
            {
                foreach (Enemy enemy in enemies)
                {
                    currentMapState.enemyDictionary[enemy.enemyID].currentHP = enemy.HP;
                    Debug.Log(currentMapState.enemyDictionary[enemy.enemyID].currentHP);
                }
            }
        }
    }
}

[Serializable]
public class MapState
{
    public int mapID;
    public List<EnemyState> enemyStates;
    [NonSerialized] public Dictionary<int, EnemyState> enemyDictionary;
    public bool hasTreasure, treasureCollected;

    public void InitializeEnemyDictionary()
    {
        enemyDictionary = new Dictionary<int, EnemyState>();
        foreach(EnemyState enemy in enemyStates)
        {
            enemyDictionary.Add(enemy.enemyID, enemy);
        }
    }
}

[Serializable]
public class EnemyState
{
    public int enemyID;
    public int currentHP;
    public int maxHP;
}

[Serializable]
public class GameState
{
    [Header("Player Stats")]
    public int currentHP;
    public int maxHP;
    public int ATK;
    public int DEF;
    public int treasure = 0;

    [Header("Map Data")]
    public List<MapState> mapStates;
}