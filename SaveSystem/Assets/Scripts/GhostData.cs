using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GhostData
{
    public List<GhostDataFrame> ghostDataFrames = new List<GhostDataFrame>();
}

[Serializable]
public class GhostDataFrame
{
    Vector3 position;
    Vector3 rotation;

    public GhostDataFrame(Vector3 position_, Vector3 rotation_)
    {
        position = position_;
        rotation = rotation_;
    }
}