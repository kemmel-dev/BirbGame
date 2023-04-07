using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

public class CameraFollow : UnifyBehaviour
{

    private Camera _camera;
    private Transform _target;

    [SerializeField]
    [Range(0,1)]
    private float SmoothSpeed;
    
    private Vector3 _velocity = Vector3.zero;

    [Inject]
    public void Inject(Camera mainCamera)
    {
        _camera = mainCamera;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        var cameraTransform = _camera.transform;
        var targetPosition = _target.position;
        var desiredPosition = new Vector3(targetPosition.x, targetPosition.y, -10);

        var newPos = Vector3.SmoothDamp(cameraTransform.position, desiredPosition, ref _velocity, SmoothSpeed);
        newPos.z = -10;
        cameraTransform.position = newPos;
    }
}
