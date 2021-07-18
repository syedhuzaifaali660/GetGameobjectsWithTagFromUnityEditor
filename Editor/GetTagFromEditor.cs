using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GetTag))]
public class GetTagFromEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GetTag myTagGetter = (GetTag)target;

        if(myTagGetter.tagName.Length <= 0)
        {
            EditorGUILayout.HelpBox("Enter Tag Name", MessageType.Error);
            return;
        }
        if(GUILayout.Button("Get Gameobjects with Tag"))
        {
            myTagGetter.GetTagFunc();
        }

        EditorGUILayout.HelpBox("Custome Editor Script \n Made By Syed Huzaifa Ali",MessageType.Info);
    }
}
