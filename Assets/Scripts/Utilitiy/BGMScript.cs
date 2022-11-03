using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    public static BGMScript Instance;

    public AudioClip audioClip;
    private AudioSource _source;
    
    private void Awake()
    {
       if(Instance != null && Instance != this) Destroy(this.gameObject);
       else
       {
           Instance = this;
           DontDestroyOnLoad(this.gameObject);
       }
       

       _source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _source.clip = audioClip;
        _source.Play();
    }
}
