using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapSO", menuName = "Scriptable Objects/MapSO")]
public class MapSO : ScriptableObject
{
    public GameObject prefab;
    public int mapID;
    public string mapName;
    public List<MapEntryPoint> mapEntryPoints;
}

[Serializable]
public class MapEntryPoint
{
    public int entryPointID;
    public Vector3Int cell;
    public PlayerAnimationState targetState;
}