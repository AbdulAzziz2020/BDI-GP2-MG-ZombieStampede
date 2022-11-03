using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Zombie")]
public class EnemySO : ScriptableObject
{
    public int baseHealth;
    public float baseSpeed;
    public int damage;
    public GameObject enemyPrefab;

    public AudioClip[] clip;
}
