using System.Collections;
using System.Collections.Generic;
using Random = Unity.Mathematics.Random;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial class EnemySpawnerSystem : SystemBase
{
    private EnemySpawnerComp enemySpawnerComp;
    private EnemyDTCONT enemyDTCONT;
    private Entity enemySpawnerEntity;
    private float nextSpawnTime;
    private Random random;
    

    protected override void OnCreate()
    {
        random = Random.CreateFromIndex((uint)enemySpawnerComp.GetHashCode());
    }

    //public void OnUpdate(ref SystemState state)
    //{
    //    var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);
    //    foreach (var (enemyPrefab, transform) in SystemAPI.Query<EnemyAuthoring.EnemyPrefab, LocalTransform>().WithAll<EnemyAuthoring.FireEnemyTag>())
    //    {
    //        var newEnemy = ecb.Instantiate(enemyPrefab.Value);
    //        var enemyTransform = LocalTransform.FromPositionRotation(transform.Position, transform.Rotation);
    //        ecb.SetComponent(newEnemy, enemyTransform);
    //    }
    //    ecb.Playback(state.EntityManager);
    //    ecb.Dispose();
    //}
    protected override void OnUpdate()
    {
        
        if (!SystemAPI.TryGetSingletonEntity<EnemySpawnerComp>(out enemySpawnerEntity))
        {
            return;
        }

        enemySpawnerComp = EntityManager.GetComponentData<EnemySpawnerComp>(enemySpawnerEntity);
        enemyDTCONT = EntityManager.GetComponentObject<EnemyDTCONT>(enemySpawnerEntity);

        if (SystemAPI.Time.ElapsedTime > nextSpawnTime) 
        {
            SpawnEnemy();
        }

    }

    private void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy");
        int level = 2;
        List<EnemyData> availableEnemies = new List<EnemyData>();
        foreach (EnemyData enemyData in enemyDTCONT.enemies) 
        {
            if (enemyData.level <= level)
            {
                availableEnemies.Add(enemyData);
            }
        }

        int index = random.NextInt(availableEnemies.Count);
        Entity newEnemy = EntityManager.Instantiate(availableEnemies[index].prefab);

        EntityManager.SetComponentData(newEnemy, new LocalTransform
        {
            Position = GetPoisitonOutsideOfCameraRange(),
            Rotation = quaternion.identity,
            Scale = 1
        });

        EntityManager.AddComponentData(newEnemy, new EnemyComponent { currentHealth = availableEnemies[index].health });

        nextSpawnTime = (float)SystemAPI.Time.ElapsedTime + enemySpawnerComp.SpawnCooldown;
    }

    private float3 GetPoisitonOutsideOfCameraRange()
    {
        float3 position = new float3(random.NextFloat2(-enemySpawnerComp.camerasize * 2, enemySpawnerComp.camerasize * 2), 0);
        while (position.x < enemySpawnerComp.camerasize.x && position.x > -enemySpawnerComp.camerasize.x &&
            position.y < enemySpawnerComp.camerasize.y && position.y > -enemySpawnerComp.camerasize.y)
        {
            position = new float3(random.NextFloat2(-enemySpawnerComp.camerasize * 2, enemySpawnerComp.camerasize * 2), 0);
        }

        position += new float3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        return position;
    }
}
