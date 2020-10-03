using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Global State")]
public class GlobalState : ScriptableObject
{
    public int currentDay = 0;
    public TimeOfDay currentTime = TimeOfDay.Morning;
    public float communityApproval = 0.0f;
    [Range(0, 1)]
    public float communityReached = 0.0f;
    public float money = 0;
    public static bool isInDialog = false;
    public bool playedAMDialog = false;
    public bool playedPMDialog = false;

    // NPCs
    public int leraScore = 0;
    public float luisScore = 0;
    public int buckScore = 0;
    public int carlaScore = 0;

    public void ChangeMoney(int change)
    {
        money += change;
    }

    private void OnDialogStarted()
    {
        isInDialog = true;
    }

    private void OnDialogStopped()
    {
        isInDialog = false;
    }

    private void OnEnable()
    {
        DialogManager.DialogStarted += OnDialogStarted;
        DialogManager.DialogStopped += OnDialogStopped;
    }

    private void OnDisable()
    {
        DialogManager.DialogStarted -= OnDialogStarted;
        DialogManager.DialogStopped -= OnDialogStopped;
    }

}

public enum TimeOfDay {
    Morning,
    Broadcast,
    Evening,
    Night
}

