using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType type;
    public ActionType action;
    public float hungerAmount;
    public float thirstAmount;
    public float attackDamage;
    public Vector2Int range = new Vector2Int(5, 4);
    public GameObject dropPrefab;

    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public TileBase Tile { get; private set; }

    [field: SerializeField]
    public Vector3 TileOffset { get; private set; }

    [field: SerializeField]
    public Sprite PreviewSprite { get; private set; }

    [field: SerializeField]
    public GameObject GameObject { get; private set; }


    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    public enum ItemType
    {
        Item,
        Tool,
        Weapon,
    }

    public enum ActionType
    {
        defend,
        dig,
        mine,
        chop,
        craft,
        feed,
        drink,
        build
    }
}
