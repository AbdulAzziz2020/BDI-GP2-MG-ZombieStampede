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
    [SerializeField] private HitEffect _hitEffect;
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
                HitEffect();

                hit.collider.GetComponent<Enemy>().UpdateHealthBar();
                IDamagable damageDealer = hit.collider.GetComponent<IDamagable>();
                damageDealer.TakeDamage(damage);
            }
        }
    }

    public void HitEffect()
    {
        _hitEffect.Invoke("SpawnEffect", 0.1f);

        int rand = Random.Range(0, clip.Length);
        _audioSource.PlayOneShot(clip[rand]);
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
