using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [Header("List Enemy")] 
    public EnemySO[] enemies;
    
    public Transform[] spawnPosition;
    public Vector2 rangeSpawn = Vector2.zero;

    private float _spawnTime = 1f;

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;
        
        if (_spawnTime <= Time.time)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)].enemyPrefab, spawnPosition[Random.Range(0, spawnPosition.Length)].position,
                Quaternion.identity);
            _spawnTime = Random.Range(rangeSpawn.x, rangeSpawn.y) + Time.time;
        }
    }
}
