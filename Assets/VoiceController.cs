using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using TMPro;
using UnityEngine.Android;


public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    [SerializeField]
    private TMP_Text uiText;

    public GameObject cube;
    private Color OriginalcubeCol;

    public static VoiceController _instance;

    private void Awake()
    {
        _instance = this;
    }

    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }

    void Start()
    {
        OriginalcubeCol = cube.GetComponent<Renderer>().material.color;
        Setup(LANG_CODE);

#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;

        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        CheckPermission();

    }

    void CheckPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    #region Text to Speech

    public void StartSpeaking(string message)
    {
        TextToSpeech.instance.StartSpeak(message);
    }

    public void StopSpeaking()
    {
        TextToSpeech.instance.StopSpeak();
    }

    void OnSpeakStart()
    {
        Debug.Log("Talking started");
    }
    void OnSpeakStop()
    {
        Debug.Log("Talking stopped");
    }



    #endregion

    #region Speech To Text
    public void StartListening()
    {
        cube.GetComponent<Renderer>().material.color = Color.red;

        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        cube.GetComponent<Renderer>().material.color = OriginalcubeCol;
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        uiText.text = result;
    }

    void OnPartialSpeechResult(string result)
    {
        uiText.text = result;
    }

    #endregion
}
