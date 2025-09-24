using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class UnitSpawnerController : MonoBehaviour
{
    [SerializeField] private List<UnitSpawnData> spawnDatas = new List<UnitSpawnData>();
    [SerializeField] private float startingSpawnInterval;
    [SerializeField] private float minSpawnInterval;
    [SerializeField, ReadOnly] private float spawnInterval;
    [SerializeField, ReadOnly] private float spawnTimer;
    [SerializeField] private Transform unitParent;
    [SerializeField] private Vector2 minSpawnPoint;
    [SerializeField] private Vector2 maxSpawnPoint; 

    private void Start()
    {
        AdjustSpawnInterval(startingSpawnInterval);
        spawnTimer = 0f;
    }

    private void Update()
    {
        TickSpawner(Time.deltaTime);
    }

    private void TickSpawner(float delta)
    {
        if (spawnTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnInterval;
            Spawn();
        }
    }

    private void AdjustSpawnInterval(float value)
    {
        spawnInterval += value;
        if (spawnInterval < minSpawnInterval) 
        { 
            spawnInterval = minSpawnInterval;
        }
    }

    private void Spawn()
    {
        GameObject unitPrefab = GetRandomUnitPrefab();

        if (unitPrefab != null)
        {
            Vector2 spawnPoint = GetSpawnPos();
            GameObject newUnit = Instantiate(unitPrefab, unitParent);
            newUnit.transform.position = spawnPoint;
        }
    }

    private Vector2 GetSpawnPos()
    {
        float x = Random.Range(minSpawnPoint.x, maxSpawnPoint.x);
        float y = Random.Range(minSpawnPoint.y, maxSpawnPoint.y);

        return new Vector2(x, y);
    }

    private GameObject GetRandomUnitPrefab()
    {
        GameObject unitPrefab = null;

        float totalWeight = 0f;
        foreach (var spawnData in spawnDatas)
        {
            totalWeight += spawnData.ChanceWeight;
        }

        float chance = Random.Range(0f, totalWeight);
        totalWeight = 0f;
        foreach (var spawnData in spawnDatas)
        {
            totalWeight += spawnData.ChanceWeight;
            if (totalWeight >= chance)
            {
                unitPrefab = spawnData.UnitPrefab;
                break;
            }
        }

        return unitPrefab;
    }
}
