using System;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{

    public bool WireFrame;
    public GizmoType Type;
    
    [HideInInspector]
    public float Radius;
    [HideInInspector]
    public Vector3 Size;
    public Color Color = UnityEngine.Color.cyan;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color;

        if (WireFrame) { DrawWireFrameGizmo(); return;}
        DrawNormalGizmo();
    }

    private void DrawNormalGizmo()
    {
        switch (Type)
        {
            case GizmoType.Sphere:
                Gizmos.DrawSphere(transform.position, Radius);
                break;
            case GizmoType.Cube:
                Gizmos.DrawCube(transform.position, Size);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DrawWireFrameGizmo()
    {
        switch (Type)
        {
            case GizmoType.Sphere:
                Gizmos.DrawWireSphere(transform.position, Radius);
                break;
            case GizmoType.Cube:
                Gizmos.DrawWireCube(transform.position, Size);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public enum GizmoType
    {
        Sphere,
        Cube
    }
}
