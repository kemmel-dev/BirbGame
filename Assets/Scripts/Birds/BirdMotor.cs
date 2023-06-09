﻿using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

namespace Birds
{
    public class BirdMotor : UnifyBehaviour
    {
        private Rigidbody2D _rb;
        private SpringController _springController;
        
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _maxVelocity;
        
        private bool _springIsAttached;

        [Inject]
        public void Inject(Rigidbody2D birdBody, SpringController springController)
        {
            _rb = birdBody;
            _springController = springController;
        }

        private void FixedUpdate()
        {
            if (_springController.SpringIsAttached)
            {
                _rb.transform.up = _springController.AttachOrientation;
            }
            MoveForward();
        }

        private void MoveForward()
        {
            _rb.AddForce(_rb.transform.up * (_movementSpeed * Time.deltaTime));
            if (!_springIsAttached && _rb.velocity.magnitude >= _maxVelocity)
            {
                _rb.velocity = _rb.velocity.normalized * _maxVelocity;
            }
        }
    }
}