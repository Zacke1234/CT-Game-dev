using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private float m_SpawnRate;
    private float m_SpawnTime;

    private void Update()
    {
        if (m_SpawnTime < Time.time)
        {
            
        }
    }
}
