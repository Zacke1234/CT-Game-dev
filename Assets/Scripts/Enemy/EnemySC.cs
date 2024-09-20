using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemySC : ScriptableObject
{
    public GameObject Prefab;
    public float Health;
    public float Damage;
    public float MoveSpeed;
    public int Enemy;
}
