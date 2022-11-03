using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour, IDamagable
{
    [Header("Player Status")] 
    public int baseHealth;
    public int damage;

    [HideInInspector] public int curHealth;
    
    [Header("Layer Check")]
    public LayerMask enemyMask;

    [Header("Hit Effect")] 
    public GameObject hitEffect;
    private AudioSource _audioSource;
    public AudioClip[] clip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        curHealth = baseHealth;
    }

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;
        
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, enemyMask);

            if (hit.collider != null)
            {
                HitEffect(hit);

                int rand = Random.Range(0, clip.Length);
                _audioSource.PlayOneShot(clip[rand]);
                
                hit.collider.GetComponent<Enemy>().UpdateHealthBar();
                IDamagable damageDealer = hit.collider.GetComponent<IDamagable>();
                damageDealer.TakeDamage(damage);
            }
        }
    }

    public void HitEffect(RaycastHit2D col)
    {
        GameObject effect = Instantiate(hitEffect, col.collider.transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
