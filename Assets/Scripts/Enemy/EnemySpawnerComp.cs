using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct EnemySpawnerComp : IComponentData
{
    public float SpawnCooldown;
    public float2 camerasize;
}
