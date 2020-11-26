using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpeechController))]
public class TestLastPhrase : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SpeechController listeningEvent = (SpeechController)target;

        if (GUILayout.Button("StartListening()"))
        {
            listeningEvent.ReceiveLatestSpeech();
        }
    }
}
