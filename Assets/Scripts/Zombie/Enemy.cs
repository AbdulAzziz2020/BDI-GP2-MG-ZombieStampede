using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, IDamagable
{
    protected int _curHealth;
    protected float _curSpeed;
    public EnemySO enemySO;
    public Image healthFill;

    private bool isDeath = false;
    private Animator _anim;

    public AudioSource audioSource;
    public float playRate = 1f;
    private float _rate;
    public void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public virtual void Start()
    {
        _curHealth = enemySO.baseHealth;
        _curSpeed = enemySO.baseSpeed;
        
        UpdateHealthBar();
    }

    public void Update()
    {
        if (GameManager.Instance.isGameOver) return;

        if (!isDeath)
        {
            if (_rate <= Time.time)
            {
                int rand = Random.Range(0, enemySO.clip.Length);
                audioSource.PlayOneShot(enemySO.clip[rand]);
                _rate = Time.time + playRate;
            }
            transform.position += Vector3.down * _curSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(int amount)
    {
        _curHealth -= amount;
        if (_curHealth <= 0)
        {
            _anim.SetTrigger("Die");
            isDeath = true;
            
            Destroy(this.gameObject, 1f);
        }
    }

    public void AddKill()
    {
        DataCounter.score++;
        GameManager.Instance.ScoreUpdating();
    }

    public void UpdateHealthBar()
    {
        healthFill.fillAmount = (float)_curHealth / (float)enemySO.baseHealth;
    }
}
