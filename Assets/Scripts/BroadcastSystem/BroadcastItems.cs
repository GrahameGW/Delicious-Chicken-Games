using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Broadcast Items")]
public class BroadcastItems : ScriptableObject
{
    public List<BroadcastClip> clips = new List<BroadcastClip>();
    public List<BroadcastClip> usedClips = new List<BroadcastClip>();

    public void UseClip(BroadcastClip clip)
    {
        if (clips.Contains(clip))
        {
            clips.Remove(clip);
            usedClips.Add(clip);
            
            Debug.Log("Play " + clip.name);
        }
        else
        {
            Debug.LogError("Tried to use clip that isn't in clips list.");
        }
    }

    public void ResetClips()
    {
        foreach (BroadcastClip clip in usedClips)
        {
            clips.Add(clip);
        }
        usedClips = new List<BroadcastClip>();
    }
}
