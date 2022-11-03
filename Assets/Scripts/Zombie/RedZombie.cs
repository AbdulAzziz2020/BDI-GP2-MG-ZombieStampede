using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZombie : Enemy
{
    [Header("Ability")]
    public int healthMultiplier;

    public override void Start()
    {
        base.Start();
        _curHealth += healthMultiplier;
    }
    
}
