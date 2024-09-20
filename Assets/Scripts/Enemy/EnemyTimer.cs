using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


//[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
//public partial class EnemyTimer : SystemBase
//{
//    public float TimeRemaining = 1;
//    private Entity Enemy;
//    // Update is called once per frame
//    protected override void OnCreate()
//    {
//        RequireForUpdate<EnemyAuthoring.FireEnemyTag>();
//    }

//    protected override void OnStartRunning()
//    {
//        Enemy = SystemAPI.GetSingletonEntity<EnemyAuthoring.EnemyTag>();
//    }
//    protected override void OnUpdate()
//    {
//        if (TimeRemaining > 0)
//        {
//            TimeRemaining -= SystemAPI.Time.DeltaTime;
            
//        }
//        else 
//        {
//            if (!SystemAPI.Exists(Enemy)) return;
//            Debug.Log("spawn!");
//            SystemAPI.SetComponentEnabled<EnemyAuthoring.FireEnemyTag>(Enemy, true);
//            TimeRemaining = 1;
//        }
//    }

//    protected override void OnStopRunning() 
//    {
//        Enemy = Entity.Null;
//    }
//}
