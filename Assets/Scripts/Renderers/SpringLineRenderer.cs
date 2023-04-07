using System;
using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

namespace Renderers
{
    [RequireComponent(typeof(LineRenderer))]
    public class SpringLineRenderer : UnifyBehaviour
    {
        private LineRenderer _lineRenderer;
        private SpringJoint2D _spring;

        [Inject]
        private void Inject(LineRenderer lineRenderer, SpringJoint2D spring)
        {
            _lineRenderer = lineRenderer;
            _spring = spring;
        }

        private void Start()
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.enabled = false;
        }

        private void Update()
        {
            _lineRenderer.enabled = _spring.enabled;

            if (!_lineRenderer.enabled) return;
            
            _lineRenderer.SetPosition(0, _spring.transform.position);
            _lineRenderer.SetPosition(1, _spring.connectedBody.position);
        }
    }
}
