using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Advertisement")]
public class AdvertClip : BroadcastClip
{
    public AdvertClip(BroadcastClip b)
    {
        this.clip = b.clip;
        this.name = b.name;
        this.dialog = b.dialog;
    }
}
