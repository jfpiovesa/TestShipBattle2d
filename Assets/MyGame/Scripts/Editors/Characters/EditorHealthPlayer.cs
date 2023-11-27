#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;



[CustomEditor(typeof(HealthShip))]
public class EditorHealthPlayer : Editor
{
    public bool isOpenHealth;

    public override void OnInspectorGUI()
    {
        HealthShip shipHealth = (HealthShip)target;
     

        GUIStyle groupStyle = new GUIStyle(GUI.skin.box);
 
        EditorGUILayout.Space(10);


        this.isOpenHealth = EditorGUILayout.BeginFoldoutHeaderGroup(this.isOpenHealth, "Health Settings");

        GUILayout.BeginVertical(groupStyle);
        if (this.isOpenHealth)
            if (Selection.activeTransform)
            {

                shipHealth.currenthealth = EditorGUILayout.IntSlider("Current heath ", shipHealth.currenthealth,0, shipHealth.maxHealth);
                ProgressBar(shipHealth.currenthealth / (float)shipHealth.maxHealth, "Health");
                shipHealth.maxHealth = EditorGUILayout.IntField("Max heath", shipHealth.maxHealth, GUILayout.Width(200));
                EditorGUILayout.Space(2);
                shipHealth.isDead = EditorGUILayout.ToggleLeft("Dead", shipHealth.isDead);
            }

        if (!Selection.activeTransform)
        {

            this.isOpenHealth = false;
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        GUILayout.EndVertical();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }

    // Custom GUILayout progress bar.
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
 
}
#endif