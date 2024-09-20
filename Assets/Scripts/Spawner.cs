using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public float2 SpawnPosition; // better vector2
    public float NextSpawnTime;
    public float SpawnRate;
    
}
