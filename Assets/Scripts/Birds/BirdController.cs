using Helpers;
using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

namespace Birds
{
    public class BirdController : UnifyBehaviour
    {
        private BirdMotor _birdMotor;
        private SpringOrientationHelper _helper;
        
        [Inject]
        public void Inject(BirdMotor birdMotor, SpringOrientationHelper helper)
        {
            _birdMotor = birdMotor;
            _helper = helper;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _birdMotor.Fly();
                Debug.Log(_helper.AttachOrientation);
            }
            
        }
    }
}