using SimpleSceneTransitions;
using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class PlaybackManager : MonoBehaviour
{
    [SerializeField] float playbackDelay = 1.0f;
    [SerializeField]
    float fadeOutMultiplier = 1.0f;
    [SerializeField] DialogueRunner dialogRunner = default;

    [SerializeField] YarnProgram weather = default;

    private int day;
    [SerializeField] BroadcastSchedule schedule = default;
    private int stage = 0;
    // 0 = weather, 1 = random general clip, 2 = ad, 3 = interview


    void Start()
    {
        day = GetComponent<BroadcastPlayer>().globalState.currentDay;
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(playbackDelay);
        if  (day != 0) {
            // load weather
            dialogRunner.Add(weather);
            dialogRunner.Add(schedule.advertSlot.yarn);
            dialogRunner.Add(schedule.interviewSlot.yarn);
            dialogRunner.StartDialogue(Random.Range(1, 6).ToString());
            stage++;


            yield break;
        }
        else {
            // play music
        }
    }

    public void NextNode()
    {
        stage++;

        if (stage == 1) {
            stage++;
        }
        if (stage == 2) {
            if (schedule.advertSlot != null) {
                dialogRunner.StartDialogue("StartAd");
                return;
            }
            stage++;
        }
        if (stage == 3) {
            if (schedule.interviewSlot != null) {
                dialogRunner.StartDialogue("StartInterview");
                return;
            }
            EndBroadcast();
        }
    }
    private void EndBroadcast()
    {
        GetComponent<BroadcastPlayer>().globalState.currentTime = TimeOfDay.Evening;
        Initiate.Fade("Studio", Color.black, fadeOutMultiplier);
    }
}
