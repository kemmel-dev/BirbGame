using System;
using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

namespace Birds
{
    public class BirdZoomTrigger : UnifyBehaviour
    {
        private Rigidbody2D _birdBody;
        private CameraZoom _cameraZoom;

        public float VelocityForMaxZoom;

        [Inject]
        public void Inject(Rigidbody2D birdBody, CameraZoom cameraZoom)
        {
            _birdBody = birdBody;
            _cameraZoom = cameraZoom;
        }

        private void Update()
        {
            //Debug.Log(_birdBody.velocity.magnitude);
            _cameraZoom.ChangeZoom(Mathf.Clamp01(_birdBody.velocity.magnitude / VelocityForMaxZoom));
        }
    }
}