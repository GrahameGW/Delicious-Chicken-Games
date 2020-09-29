using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Broadcast Items")]
public class BroadcastItems : ScriptableObject
{
    public List<BroadcastClip> clips = new List<BroadcastClip>();
}
