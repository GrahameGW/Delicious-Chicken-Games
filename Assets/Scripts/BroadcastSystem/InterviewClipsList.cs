using UnityEngine;

public class InterviewClipsList : MonoBehaviour
{
    [SerializeField] BroadcastItems availableClips = default;
    [SerializeField] InterviewSlotUIButton interviewSlotPrefab = default;
    [SerializeField] ScheduleManager scheduleManager = default;
    [SerializeField] RectTransform listContent = default;
    public InterviewSlotUIButton selected;

    private void Start()
    {
        for (int i = 0; i < availableClips.interviews.Count; i++) {
            InterviewSlotUIButton item = Instantiate(interviewSlotPrefab);
            item.menu = this;
            item.interview = availableClips.interviews[i];
            item.Name = item.interview.name;
            item.transform.SetParent(listContent, false);
        }
    }

    public void SetInterview(InterviewSlotUIButton item)
    {
        scheduleManager.selectedInterview = item.interview;
        selected?.Deselect();
        selected = item;
    }
}
