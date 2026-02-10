using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapNavigation : MonoBehaviour
{
    [SerializeField] private MapLibrary mapLibrary;
    [SerializeField] private Transform player;
    [SerializeField] private Transform mapParent;

    private Dictionary<int, MapData> mapDictionary = new Dictionary<int, MapData>();
    public static MapNavigation instance;
    public event Action<PlayerAnimationState> OnEnterMap;
    public GameObject currentMap;

    public UnityEvent OnNavigate;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InitializeMapLibrary();
    }

    public void InitializeMapLibrary()
    {
        foreach(MapSO map in mapLibrary.mapLibrary)
        {
            mapDictionary.Add(map.mapID, new MapData(map));
            Debug.Log(map.mapName + " Initalized");
        }
    }

    public void GoToMap(int mapID, int entryPointID)
    {
        Destroy(currentMap);
        currentMap = Instantiate(mapDictionary[mapID].prefab, mapParent);

        Grid g = currentMap.GetComponent<Grid>();

        Vector3 newPosition = g.GetCellCenterWorld(mapDictionary[mapID].entryPoints[entryPointID].cell);
        player.position = newPosition;

        GameStateManager.instance.SaveMapState();

        OnNavigate?.Invoke();
    }
}

public class MapData
{
    public GameObject prefab;
    public int mapID;
    public string mapName;
    public Dictionary<int, MapEntryPoint> entryPoints = new Dictionary<int, MapEntryPoint>();

    public MapData(MapSO config)
    {
        this.prefab = config.prefab;
        this.mapID = config.mapID;
        this.mapName = config.mapName;

        foreach(MapEntryPoint mapEntryPoint in config.mapEntryPoints)
        {
            entryPoints.Add(mapEntryPoint.entryPointID, mapEntryPoint);
        }
    }
}