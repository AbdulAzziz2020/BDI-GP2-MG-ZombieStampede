using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public GameObject hitEffect;
    
    public void SpawnEffect()
    {
        GameObject _effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        _effect.transform.SetParent(this.transform);
        Destroy(_effect, 1f);
    }
}
