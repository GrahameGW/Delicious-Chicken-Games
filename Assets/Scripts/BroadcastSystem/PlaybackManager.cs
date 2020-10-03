using SimpleSceneTransitions;
using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class PlaybackManager : MonoBehaviour
{
    [SerializeField] float playbackDelay = 1.0f;
    [SerializeField]
    float fadeOutMultiplier = 1.0f;
    [SerializeField] DialogueOrganizer dialogOrganizer = default;
    [SerializeField] DialogueRunner dialogRunner = default;

    [SerializeField] YarnProgram weather = default;

    private int stage = 0;
    private int day;
    [SerializeField] BroadcastSchedule schedule = default;
    // 0 = weather, 1 = random general clip, 2 = ad, 3 = interview


    void Start()
    {
        day = GetComponent<BroadcastPlayer>().globalState.currentDay;
        StartCoroutine(PlayWeather());
    }

    IEnumerator PlayWeather()
    {
        yield return new WaitForSeconds(playbackDelay);
        if  (day != 0) {
            stage++;
            dialogRunner.Add(weather);
            dialogRunner.StartDialogue(Random.Range(1, 6).ToString());

            yield break;
        }
        else {
            // play music
        }
    }

    public void PlayNext()
    {
        //dialogRunner.Clear();

        switch(stage) {
            case 1:
                // play random clip
                goto case 2;
                //break;
            case 2:
                // play ad
                if (schedule.advertSlot != null) {
                    dialogRunner.Add(schedule.advertSlot.yarn);
                    dialogRunner.StartDialogue("Start");
                    break;
                }
                else {
                    goto case 3;
                }
            case 3:
                // play interview if exists
                if (schedule.interviewSlot != null) {
                    dialogRunner.Add(schedule.interviewSlot.yarn);
                    dialogRunner.StartDialogue("Start");
                }
                else {
                    EndBroadcast();
                }
                break;
            default:
                EndBroadcast();
                break;
        }

        stage++;
    }

    private void EndBroadcast()
    {
        GetComponent<BroadcastPlayer>().globalState.currentTime = TimeOfDay.Evening;
        Initiate.Fade("Studio", Color.black, fadeOutMultiplier);
    }
}
