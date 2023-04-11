using System;
using UnityEngine;

public class CameraTargetRelativeToVelocity : MonoBehaviour
{
    public float VelocityForMaxDistance;
    public Transform min;
    public Transform max;
    public Transform target;

    private Rigidbody2D _attachedRb;

    private void Awake()
    {
        _attachedRb = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        var positionMax = max.position;
        var positionMin = min.position;
        var dir = (positionMax - positionMin).normalized;
        var distanceMinMax = Vector3.Distance(positionMin, positionMax);
        var distancePercentageBasedOnVelocity = Mathf.Clamp01(_attachedRb.velocity.magnitude / VelocityForMaxDistance);
        
        target.position = positionMin + dir * (distanceMinMax * distancePercentageBasedOnVelocity);
    }
}
