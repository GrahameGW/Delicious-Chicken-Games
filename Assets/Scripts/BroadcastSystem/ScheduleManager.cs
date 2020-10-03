using UnityEditor;
using UnityEngine;


public class ScheduleManager : MonoBehaviour
{
    [SerializeField] BroadcastSchedule schedule = default;
    [SerializeField] ClipsList musicList = default;
    [SerializeField] ClipsList interviewList = default;
    [SerializeField] ClipsList advertList = default;
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

        EditorUtility.SetDirty(schedule);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public string GetSaved()
    {
        string str = string.Empty;
        var interview = schedule.interviewSlot;
        var music = schedule.musicSlot;
        var ad = schedule.advertSlot;

        if (!interview && !music && !ad) {
            return "Nothing scheduled for the upcoming broadcast.";
        }
        else {
            str += "Saved ";
            str += interview != null ? interview.name + " (interview)": "";
            str += music != null ?
                (!str.Equals("Saved ") ?  " and " + music.name : music.name) + " (music)"  : 
                "";
            str += ad != null ?
                !str.Equals("Saved ") ? " and " + ad.name + " (ad)" : ad.name + " (ad)" :
                "";
            str += " for broadcast!";
        }
        return str;
    }
}
