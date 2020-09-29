using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Broadcast Schedule")]
public class BroadcastSchedule : ScriptableObject
{
    public BroadcastClip weatherSlot;
    public BroadcastClip musicSlot;
    public BroadcastClip interviewSlot;
}
