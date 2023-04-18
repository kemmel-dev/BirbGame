using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CircleOfObjects))]
    public class CircleOfObjectsEditor : UnityEditor.Editor
    {

        private Transform _objectParent;
        
        public override void OnInspectorGUI()
        {
            var circleOfObjects = target as CircleOfObjects;
            if (circleOfObjects == null) return;


            if (circleOfObjects.Partway)
            {
                DrawDefaultInspector();
            }
            else
            {
                GUI.enabled = false;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"), true, Array.Empty<GUILayoutOption>());

                GUI.enabled = true;
                circleOfObjects.Prefab = (GameObject) EditorGUILayout.ObjectField("Prefab", circleOfObjects.Prefab, typeof(GameObject), true);
                circleOfObjects.Partway = EditorGUILayout.Toggle("Partway", circleOfObjects.Partway);
                circleOfObjects.NumObjectsOnCircle = EditorGUILayout.IntField("Num Objects On Circle", circleOfObjects.NumObjectsOnCircle);
            }

            if (circleOfObjects.Partway)
            {
                circleOfObjects.AngleMin = EditorGUILayout.Slider("Angle Min", circleOfObjects.AngleMin, 0, 360);
                circleOfObjects.AngleMax = EditorGUILayout.Slider("Angle Max", circleOfObjects.AngleMax, 0, 360);
                
                if (circleOfObjects.DeltaAngle <= 0)
                {
                    EditorGUILayout.HelpBox("Minimum Angle set higher than Maximum Angle!", MessageType.Error);
                }
            }
            
            if (GUILayout.Button("Update"))
            {
                ClearChild(circleOfObjects);
                UpdateChildren(circleOfObjects);
            }

        }

        private static void ClearChild(Component component)
        {
            if (component.transform.childCount > 0)
                DestroyImmediate(component.transform.GetChild(0).gameObject);
        }
 
        private void UpdateChildren(CircleOfObjects o)
        {
            var circleOfObjects = target as CircleOfObjects;

            if (circleOfObjects == null) return;

            SpawnObjectsAlongCircle(circleOfObjects);

        }

        private void SpawnObjectsAlongCircle(CircleOfObjects circleOfObjects)
        {

            _objectParent = new GameObject("Object Parent").transform;
            _objectParent.parent = circleOfObjects.transform;

            foreach (var point in PointsAlongCircle(circleOfObjects))
            {
                var go = Instantiate(circleOfObjects.Prefab, point, Quaternion.identity);
                go.transform.parent = _objectParent;
            }
        }

        private static List<Vector3> PointsAlongCircle(CircleOfObjects circleOfObjects)
        {

            var points = new List<Vector3>();
            
            var degreesPerStep = circleOfObjects.Partway
            ? circleOfObjects.DeltaAngle / (circleOfObjects.NumObjectsOnCircle - 1)
            : 360f / circleOfObjects.NumObjectsOnCircle;
            
            for (var i = 0; i < circleOfObjects.NumObjectsOnCircle; i++)
            {
                var currentAngle = circleOfObjects.AngleMin + degreesPerStep * (i);
                points.Add(circleOfObjects.transform.position +
                           CircleOfObjects.GetNormalizedDirectionTowardsAngle(currentAngle) *
                           circleOfObjects.Radius);
            }
            return points;
        }

    }
}
