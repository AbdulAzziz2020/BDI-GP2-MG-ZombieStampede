using System;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class EnemyDetector : MonoBehaviour
{
    public Player player;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.isGameOver) return;
        
        if (other.gameObject.tag == "Zombie")
        {
            Debug.Log("Zombie Detection!");
            EnemySO enemySO = other.GetComponent<Enemy>().enemySO;
            
            if(enemySO != null) Debug.Log("Take damage : " + enemySO.damage);
            
            player.TakeDamage(enemySO.damage);
            
            GameManager.Instance.UpdateHealthBar(player.baseHealth, player.curHealth);
        }
    }
}
