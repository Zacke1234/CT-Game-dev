using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Diagnostics;


public partial struct EnemyMoveSystem : ISystem
{
    private EntityManager entityManager;
    private Entity playerEntity;

    //Vector3 target;
    
    [BurstCompile]
    public void OnStartRunning(ref SystemState state)
    {
        //target = new Vector2 (5, 5);
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltatime = SystemAPI.Time.DeltaTime;
        entityManager = state.EntityManager;
        playerEntity = SystemAPI.GetSingletonEntity<PlayerAuthoring.PlayerPrefab>();

        foreach (var (enemyComponent, transformComponent) in SystemAPI.Query<EnemyComponent, RefRW<LocalTransform>>())
        {
            //transform.ValueRW.Position += transform.ValueRO.Up() * moveSpeed.Value * deltatime;
            //Debug.Log("move!");
            //transform.ValueRW.Position = Vector3.MoveTowards(transform.ValueRW.Position, target , moveSpeed.Value * deltatime); ;
            //transform.ValueRW.Position += transform.ValueRO.Up() * moveSpeed.Value * deltatime;

            float3 direction = entityManager.GetComponentData<LocalTransform>(playerEntity).Position - transformComponent.ValueRO.Position;
            float angle = math.atan2(direction.y, direction.x) + math.radians(90);
            transformComponent.ValueRW.Rotation = quaternion.Euler(new float3(0,0, angle));

            transformComponent.ValueRW.Position += math.normalize(direction) * SystemAPI.Time.DeltaTime;

        }
    }
}
