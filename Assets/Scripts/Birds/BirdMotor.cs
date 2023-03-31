using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

namespace Birds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMotor : UnifyBehaviour
    {
        private Bird _bird;
        private Rigidbody2D _rb;
        private BirdController _springController;
        
        [Inject]
        public void Inject(Bird bird, Rigidbody2D attachedRb)
        {
            _rb = attachedRb;
            _bird = bird;
        }

        public void Fly()
        {
            _rb.AddForce(transform.right * _bird.FlyForce);
        }

        private void FixedUpdate()
        {
            Fly();
        }
    }
}