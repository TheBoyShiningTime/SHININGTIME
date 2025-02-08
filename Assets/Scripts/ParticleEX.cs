using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEX : MonoBehaviour
{
    ParticleSystem _particleSystem;
    List<ParticleSystem.Particle> _particles = new List<ParticleSystem.Particle>();

    private void Awake()
    {
        _particleSystem=GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        Debug.Log("effect");
        
    }
}
