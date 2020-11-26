using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpeechRecognition))]
public class TestStartContinuous : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SpeechRecognition listeningEvent = (SpeechRecognition)target;

        if (GUILayout.Button("StartListening()"))
        {
            listeningEvent.StartContinuous();
        }
    }
}
