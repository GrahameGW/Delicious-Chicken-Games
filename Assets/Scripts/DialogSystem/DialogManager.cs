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
        speakerPortrait.gameObject.SetActive(true);
        if (speakerNames.IndexOf(parameters[0]) == -1)
        {
            Debug.LogError("Could not find portrait for " + parameters[0]);
        }
        speakerPortrait.sprite = speakerSprites[speakerNames.IndexOf(parameters[0])];
    }

    #endregion

}
