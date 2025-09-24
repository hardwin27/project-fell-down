using System;
using UnityEngine;

[System.Serializable]
public class UnitSpawnData
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private float chanceWeight;

    public GameObject UnitPrefab { get => unitPrefab; }
    public float ChanceWeight { get => chanceWeight; }
}
