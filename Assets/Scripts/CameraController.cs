using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

public class CameraController : UnifyBehaviour
{
    private CameraFollow _cameraFollow;
    private Transform _bird;
    private Transform _swingPoint;

    [Inject]
    public void Inject(
            CameraFollow cameraFollow, 
            [InjectWithId(UnifyID.BirdCameraTarget)] Transform bird,
            [InjectWithId(UnifyID.SwingPoint)] Transform swingPoint
        )
    {
        _cameraFollow = cameraFollow;
        _bird = bird;
        _swingPoint = swingPoint;
    }

    private void Start()
    {
        _cameraFollow.SetTarget(_bird);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _cameraFollow.SetTarget(_bird);
        }
        if (Input.GetMouseButtonDown(0))
        {
            _cameraFollow.SetTarget(_swingPoint);
        }
        
    }
}
