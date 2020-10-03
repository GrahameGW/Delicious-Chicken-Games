using UnityEngine;

public abstract class Arc : ScriptableObject
{
    public abstract void OnBroadcast(BroadcastClip clip, int day);
}

