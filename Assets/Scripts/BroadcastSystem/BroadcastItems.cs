using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Broadcast Items")]
public class BroadcastItems : ScriptableObject
{
    public List<MusicSlot> music = new List<MusicSlot>();
    public List<InterviewSlot> interviews = new List<InterviewSlot>();
}
