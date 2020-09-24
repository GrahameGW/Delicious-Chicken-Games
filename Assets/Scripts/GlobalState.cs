using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Global State")]
public class GlobalState : ScriptableObject
{
    public int currentDay = 0;
    public TimeOfDay currentTime = TimeOfDay.Morning;
    public float communityApproval = 0.0f;
    [Range(0, 1)]
    public float communityReached = 0.0f;
}

public enum TimeOfDay {
    Morning,
    Broadcast,
    Evening,
    Night
}

