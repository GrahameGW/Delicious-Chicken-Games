using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogManager : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner = default;
    [SerializeField] List<Sprite> speakerSprites = default;
    [SerializeField] List<string> speakerNames = default;
    [SerializeField] Image speakerPortrait = default;
    [SerializeField] Image speakerPortrait2 = default;

    /// <summary>
    /// These events have been linked to the DialogueUI script to trigger on dialog start and stop.
    /// </summary>
    #region Dialog_UI_Events
    public static event Action DialogStarted;
    public static event Action DialogStopped;

    private void Awake()
    {
        dialogueRunner.AddCommandHandler("SetSpeaker", SetSpeakerName);
    }

    public void StartDialog()
    {
        DialogStarted?.Invoke();
    }

    public void StopDialog()
    {
        DialogStopped?.Invoke();
    }

    void SetSpeakerName(string[] parameters)
    {
        int index = speakerNames.IndexOf(parameters[0]);
        if (index == -1)
        {
            Debug.LogError("Could not find portrait for " + parameters[0]);
        }
        if (parameters[0] == "Khalid")
        {
            speakerPortrait.sprite = speakerSprites[index];
            speakerPortrait.gameObject.SetActive(true);
        }
        else
        {
            speakerPortrait2.sprite = speakerSprites[index];
            speakerPortrait2.gameObject.SetActive(true);
        }
    }

    #endregion

}
