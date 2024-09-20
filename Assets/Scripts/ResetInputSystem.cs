using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
[UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
public partial struct ResetInputSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
        foreach (var (tag, entity) in SystemAPI.Query<PlayerAuthoring.FireProjectileTag>().WithEntityAccess())
        {
            ecb.SetComponentEnabled<PlayerAuthoring.FireProjectileTag>(entity, false);            
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
