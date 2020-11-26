using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    void CheckPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

}
