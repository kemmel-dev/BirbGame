using System.Collections;
using System.Collections.Generic;
using Plugins.Unify.Core;
using Plugins.Unify.Core.Attributes;
using UnityEngine;

public class CameraZoom : UnifyBehaviour
{

    private Camera _camera;

    public float ZoomMin;
    public float ZoomMax;
    
    [Inject]
    public void Inject(Camera mainCamera)
    {
        _camera = mainCamera;
    }

    public void ChangeZoom(float zoomPercentage)
    {
        var zoomDelta = ZoomMax - ZoomMin;
        _camera.orthographicSize = ZoomMin + zoomDelta * zoomPercentage;
    }
}
