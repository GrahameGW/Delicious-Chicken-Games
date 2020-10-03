using UnityEditor;
using UnityEngine;


public class ScheduleManager : MonoBehaviour
{
    [SerializeField] BroadcastSchedule schedule = default;
    [SerializeField] ClipsList musicList = default;
    [SerializeField] ClipsList interviewList = default;
    [SerializeField] ClipsList advertList = default;
    [SerializeField] BroadcastItems weatherClips = default;
    public GlobalState globalState;

    private void Start()
    {
        switch(globalState.currentDay) {
            case 0:
                advertList.gameObject.SetActive(false);
                interviewList.gameObject.SetActive(false);
                break;
            case 1:
                advertList.gameObject.SetActive(false);
                break;
            default: break;
        }
    }
    public void Save()
    {
        schedule.interviewSlot = interviewList.selected?.clip;
        schedule.musicSlot = musicList.selected?.clip;
        schedule.advertSlot = advertList.selected?.clip;
        schedule.weatherSlot = weatherClips.clips[Random.Range(0, weatherClips.clips.Count)];

        EditorUtility.SetDirty(schedule);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Saved " + schedule.interviewSlot?.name + " and " + schedule.musicSlot?.name + " and " + schedule.weatherSlot?.name + " and " + schedule.advertSlot?.name);
    }

    public string GetSaved()
    {
        return "Saved " + schedule.interviewSlot?.name + " and " + schedule.musicSlot?.name + " and " + schedule.weatherSlot?.name + " and " + schedule.advertSlot?.name + " for broadcast!";
    }
}
