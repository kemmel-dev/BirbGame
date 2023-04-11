using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

public class CameraController : UnifyBehaviour
{
    private CameraFollow _cameraFollow;
    private Transform _birdCameraTarget;
    private Transform _swingPoint;

    [Inject]
    public void Inject(
            CameraFollow cameraFollow, 
            [InjectWithId(UnifyID.BirdCameraTarget)] Transform birdCameraTarget,
            [InjectWithId(UnifyID.SwingPoint)] Transform swingPoint
        )
    {
        _cameraFollow = cameraFollow;
        _birdCameraTarget = birdCameraTarget;
        _swingPoint = swingPoint;
    }

    private void Start()
    {
        _cameraFollow.SetTarget(_birdCameraTarget);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _cameraFollow.SetTarget(_birdCameraTarget);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _cameraFollow.SetTarget(_swingPoint);
        }
        
    }
}
