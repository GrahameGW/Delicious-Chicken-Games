using System;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    /// <summary>
    /// These events have been linked to the DialogueUI script to trigger on dialog start and stop.
    /// </summary>
    #region Dialog_UI_Events
    public static event Action DialogStarted;
    public static event Action DialogStopped;

    public void StartDialog()
    {
        DialogStarted?.Invoke();
    }

    public void StopDialog()
    {
        DialogStopped?.Invoke();
    }

    #endregion

}
