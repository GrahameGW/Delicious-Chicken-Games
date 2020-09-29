using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    [SerializeField] BroadcastSchedule schedule = default;
    [SerializeField] ClipsList musicList = default;
    [SerializeField] ClipsList interviewList = default;

    public void Save()
    {
        schedule.interviewSlot = interviewList.selected.clip;
        schedule.musicSlot = musicList.selected.clip;

        Debug.Log("Saved " + schedule.interviewSlot?.name + " and " + schedule.musicSlot?.name);
    }
}
