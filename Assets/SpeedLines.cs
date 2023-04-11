using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLines : MonoBehaviour
{

    private ParticleSystem _particleSystem;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        var trails = _particleSystem.trails;
        trails.lifetime = _rigidbody2D.velocity.magnitude / 30f;
    }
}
