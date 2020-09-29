using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Interviews")]
public class InterviewClip : BroadcastClip
{
    public InterviewClip(BroadcastClip b)
    {
        this.clip = b.clip;
        this.name = b.name;
        this.dialog = b.dialog;
    }
}
