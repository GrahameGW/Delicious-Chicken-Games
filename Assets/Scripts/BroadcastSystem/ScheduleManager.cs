using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    [SerializeField] BroadcastSchedule schedule = default;
    public MusicSlot selectedMusic;
    public InterviewSlot selectedInterview;

    public void Save()
    {
        schedule.interviewSlot = selectedInterview;
        schedule.musicSlot = selectedMusic;

        Debug.Log("Saved " + selectedMusic?.name + " and " + selectedInterview?.name);
    }
}
