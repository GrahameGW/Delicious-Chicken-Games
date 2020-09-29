using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Scriptable Objects/Broadcast Schedule")]
public class BroadcastSchedule : ScriptableObject
{
    public BroadcastClip weatherSlot = default;
    public BroadcastClip musicSlot = default;
    public BroadcastClip interviewSlot = default;
    public BroadcastClip advertSlot = default;

    public void Reset()
    {
        interviewSlot = null;
        musicSlot = null;
        advertSlot = null;
        weatherSlot = null;

        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
