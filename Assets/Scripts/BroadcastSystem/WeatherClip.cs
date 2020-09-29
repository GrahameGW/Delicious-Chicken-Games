using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weather")]
public class WeatherClip : BroadcastClip
{
    public WeatherClip(BroadcastClip b)
    {
        this.clip = b.clip;
        this.name = b.name;
        this.dialog = b.dialog;
    }
}
