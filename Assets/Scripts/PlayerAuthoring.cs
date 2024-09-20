using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAuthoring : MonoBehaviour
{
    public float MoveSpeed;

    public GameObject ProjectilePrefab1;
    
    public GameObject PlayerPrefab1;

    class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        

        public override void Bake(PlayerAuthoring authoring)
        {
            Entity playerEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<PlayerTag>(playerEntity);
            AddComponent<PlayerMoveInput>(playerEntity);
            
            AddComponent(playerEntity, new PlayerMoveSpeed
                {
                    Value = authoring.MoveSpeed
                });
            AddComponent<FireProjectileTag>(playerEntity);
            SetComponentEnabled<FireProjectileTag>(playerEntity, false);
            
            AddComponent(playerEntity, new ProjectilePrefab
            {
                Value = GetEntity(authoring.ProjectilePrefab1, TransformUsageFlags.Dynamic)
            });

            AddComponent(playerEntity, new PlayerPrefab
            {
                Value = GetEntity(authoring.PlayerPrefab1, TransformUsageFlags.Dynamic)
            });
            
        }
    }

    public struct PlayerMoveInput : IComponentData
    {
        public float2 Value;
    }
    
    public struct PlayerMoveSpeed : IComponentData
    {
        public float Value;
    }
    public struct PlayerTag : IComponentData
    {
        
    }

    public struct ProjectilePrefab : IComponentData
    {
        public Entity Value;
    }
    
    public struct ProjectileMoveSpeed : IComponentData
    {
        public float Value;
    }
    public struct FireProjectileTag : IComponentData, IEnableableComponent
    {
        
    }
    public struct PlayerPrefab : IComponentData 
    {
        public Entity Value;
    }

}