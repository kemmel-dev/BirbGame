using System;
using UnityEditor;
using UnityEngine;

public class CircleOfObjects : MonoBehaviour
{
    public GameObject Prefab;

    public bool Partway;
    public int NumObjectsOnCircle;
    public float Radius;
    public float DeltaAngle => AngleMax - AngleMin;

    
    [HideInInspector] [Range(0, 360)] public float AngleMin = 0;
    [HideInInspector] [Range(0,360)] public float AngleMax = 360;

    private void OnDrawGizmos()
    {
        var position = this.transform.position;
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(position, Vector3.forward, Radius);


        var minRotation = GetNormalizedDirectionTowardsAngle(AngleMin);
        var maxRotation = GetNormalizedDirectionTowardsAngle(AngleMax);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(position, position + minRotation * Radius);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, position + maxRotation * Radius);
    }

    public static Vector3 GetNormalizedDirectionTowardsAngle(float angleDeg)
    {
        return new Vector3(Mathf.Cos(Mathf.Deg2Rad * (-angleDeg + 90)), Mathf.Sin(Mathf.Deg2Rad * (-angleDeg + 90)), 0).normalized;
    }
}
