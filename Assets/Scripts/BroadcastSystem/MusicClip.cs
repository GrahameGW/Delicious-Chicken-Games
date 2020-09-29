using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Music")]
public class MusicClip : BroadcastClip
{
    public MusicClip(BroadcastClip b)
    {
        this.clip = b.clip;
        this.name = b.name;
        this.dialog = b.dialog;
    }
}
