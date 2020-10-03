using UnityEngine;
using UnityEditor;

public class BroadcastPlayer : MonoBehaviour
{
    public BroadcastSchedule schedule = default;
    public GlobalState globalState = default;
    [SerializeField] BroadcastItems musicList = default;
    [SerializeField] BroadcastItems interviewList = default;
    [SerializeField] BroadcastItems advertList = default;
    [SerializeField] YarnProgram weatherYarn = default;

    private void Start()
    {
        if (schedule.musicSlot != null) musicList.UseClip(schedule.musicSlot);
        if (schedule.interviewSlot != null) musicList.UseClip(schedule.interviewSlot);
        if (schedule.advertSlot != null) advertList.UseClip(schedule.advertSlot);

        musicList.ResetClips();
        EditorUtility.SetDirty(interviewList);
        EditorUtility.SetDirty(advertList);

        schedule.Reset();

    }
    private void OnDestroy()
    {
        globalState.currentTime = TimeOfDay.Evening;
    }
}
