using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

namespace Helpers
{
    public class SpringOrientationHelper : UnifyBehaviour
    {
        private SpringJoint2D _springJoint2D;
        private Rigidbody2D _rigidbody2D;

        [Inject]
        public void Inject(Rigidbody2D orbiterBody, SpringJoint2D springJoint2D)
        {
            _rigidbody2D = orbiterBody;
            _springJoint2D = springJoint2D;
        }
    
        public Vector2 AttachOrientation
        {
            get
            {
                var swingPoint = _springJoint2D.connectedBody.transform.position;
                var posNow = transform.position;
                var posNext = (Vector2) posNow + (_rigidbody2D.velocity);
                // Clockwise if dot product is not negative
                var clockwise = IsClockwise(posNow, swingPoint, posNext); 
                return Vector2.Perpendicular(posNow - swingPoint) * (clockwise ? 1 : - 1);
            }
        }

        private static bool IsClockwise(Vector3 posHere,  Vector2 posNext, Vector3 swingPoint)
        {
            return ((posHere.x - swingPoint.x) * (posNext.y - swingPoint.y) - (posHere.y - swingPoint.y) * (posNext.x - swingPoint.x)) >= 0;
        }
    }
}
