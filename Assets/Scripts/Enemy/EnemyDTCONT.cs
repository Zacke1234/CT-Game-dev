using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class EnemyDTCONT : IComponentData
{
    public List<EnemyData> enemies;
}

public struct EnemyData
{
    public int level;
    public Entity prefab;
    public float health;
    public float damage;
    public float moveSpeed;
}
