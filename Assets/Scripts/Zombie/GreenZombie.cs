using UnityEngine;

public class GreenZombie : Enemy
{
    [Header("Ability")] 
    public float speedMultiplier = 1.5f;

    public override void Start()
    {
        base.Start();
        _curSpeed += speedMultiplier;
    }
}
