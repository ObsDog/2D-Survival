using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class Buildable
{
    [field: SerializeField]
    public Tilemap ParentTilemap { get; private set; }

    [field: SerializeField]
    public Item BuildableType { get; private set; }

    [field: SerializeField]
    public GameObject GameObject { get; private set; }

    [field: SerializeField]
    public Vector3Int Coordinates { get; private set; }

    public Buildable(Item type, Vector3Int coords, Tilemap tilemap, GameObject gameObject = null)
    {
        ParentTilemap = tilemap;
        BuildableType = type;
        Coordinates = coords;
        GameObject = gameObject;
    }

    public void Destroy()
    {
        if(GameObject != null)
        {
            UnityEngine.Object.Destroy(GameObject);
        }
    }
}
