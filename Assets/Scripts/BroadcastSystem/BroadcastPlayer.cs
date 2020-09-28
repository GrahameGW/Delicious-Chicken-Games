using UnityEngine;

public class BroadcastPlayer : MonoBehaviour
{
    [SerializeField] BroadcastSchedule schedule = default;
    [SerializeField] GlobalState globalState = default;

    private void Start()
    {
        Debug.Log("Play " + schedule.musicSlot.name);
        Debug.Log("Play " + schedule.interviewSlot.name);
    }
    private void OnDestroy()
    {
        globalState.currentTime = TimeOfDay.Evening;
    }
}
