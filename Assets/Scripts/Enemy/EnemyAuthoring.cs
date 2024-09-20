using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class EnemyAuthoring : MonoBehaviour
{
    //public GameObject prefab;
    //public float speed;
    //public float health;
    //public float damageOutput;
    //static public Vector3 target;
    //public GameObject Player;

    public float SpawnCooldown = 0.5f;
    public List<EnemySC> EnemiesSC;
    public Vector2 CameraSize;

    public class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {

            Entity enemyEntity = GetEntity(TransformUsageFlags.None);

            //AddComponent<FireEnemyTag>(enemyEntity);
            //SetComponentEnabled<FireEnemyTag>(enemyEntity, false);
            //AddComponent<EnemyTag>(enemyEntity);

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

            //AddComponent(enemyEntity, new EnemyPrefab 
            //{
            //    Value = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic) }
            //);

            ////AddComponent(enemyEntity, new EnemySpeed
            ////{
            ////    Value = authoring.speed
            ////}) ;

            ////AddComponent(enemyEntity, new EnemyHealth
            ////{
            ////    Value = authoring.health
            ////});

            ////AddComponent(enemyEntity, new EnemyDamageOutput
            ////{
            ////    Value = authoring.damageOutput
            ////});
        }
    }

    //public struct EnemyDTContainer : IComponentData
    //{
    //    public float value;
    //}

    //public struct EnemySpeed : IComponentData
    //{
    //    public float Value;
    //}

    //public struct EnemyHealth : IComponentData 
    //{
    //    public float Value;
    //}

    //public struct EnemyDamageOutput : IComponentData 
    //{
    //    public float Value;
    //}
    //public struct EnemyPrefab : IComponentData
    //{
    //    public Entity Value;
    //}

    //public struct FireEnemyTag : IComponentData, IEnableableComponent
    //{

    //}
    //public struct EnemyTag : IComponentData 
    //{ }
}
