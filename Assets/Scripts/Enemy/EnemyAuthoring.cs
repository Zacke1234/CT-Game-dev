using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class EnemyAuthoring : MonoBehaviour
{
    

    public float SpawnCooldown = 0.5f;
    public List<EnemySC> EnemiesSC;
    public Vector2 CameraSize;

    public class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {

            Entity enemyEntity = GetEntity(TransformUsageFlags.None);


            AddComponent(enemyEntity, new EnemySpawnerComp
            {
                SpawnCooldown = authoring.SpawnCooldown,
                camerasize = authoring.CameraSize
            });

            List<EnemyData> enemyData = new List<EnemyData>();

            foreach (EnemySC e in authoring.EnemiesSC) 
            {
                enemyData.Add(new EnemyData
                {
                    damage = e.Damage,
                    health = e.Health,
                    moveSpeed = e.MoveSpeed,
                    level = e.Enemy,
                    prefab = GetEntity(e.Prefab, TransformUsageFlags.None)
                });
            }

            AddComponentObject(enemyEntity, new EnemyDTCONT {  enemies = enemyData });

            
        }
    }

    
}
