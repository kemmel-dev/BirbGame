using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(DrawGizmo))]
    public class DrawGizmoEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var drawGizmo = target as DrawGizmo;

            if (drawGizmo!.Type == DrawGizmo.GizmoType.Cube)
            {
                drawGizmo.Size = EditorGUILayout.Vector3Field("Size", drawGizmo.Size);
            }
            else
            {
                drawGizmo.Radius = EditorGUILayout.FloatField("Radius", drawGizmo.Radius);
            }
        }
    }
}
