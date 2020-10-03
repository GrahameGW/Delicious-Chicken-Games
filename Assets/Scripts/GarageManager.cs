using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GarageManager : MonoBehaviour
{
    [SerializeField] LerasArc lera = default;
    [SerializeField] BucksArc buck = default;
    [SerializeField] float dialogStartDelay = 1.0f;
    [SerializeField] DialogueOrganizer dialogOrganizer = default;
    [SerializeField] DialogueRunner dialogRunner = default;
    [SerializeField] YarnProgram firstMeetingDialog = default;
    [SerializeField] GlobalState globalState = default;
    // Start is called before the first frame update
    void Start()
    {
        if (!lera.hasMet) {
            StartCoroutine(PlayDialog(firstMeetingDialog, TimeOfDay.Night)); // night so it does nothign
            lera.hasMet = true;
        }

        else {
            YarnProgram dialogue;
            if (GetDialog(globalState, dialogOrganizer, out dialogue)) {
                StartCoroutine(PlayDialog(dialogue, globalState.currentTime));
                buck.hasMet = true;
            }

            else {
                // play random dialog
            }
        }
    }

    private IEnumerator PlayDialog(YarnProgram dialog, TimeOfDay time)
    {
        dialogRunner.Add(dialog);

        if (time == TimeOfDay.Morning) {
            globalState.playedAMDialog = true;
        }
        if (time == TimeOfDay.Evening) {
            globalState.playedPMDialog = true;
        }

        yield return new WaitForSeconds(dialogStartDelay);
        dialogRunner.StartDialogue("Start");
    }

    private bool GetDialog(GlobalState state, DialogueOrganizer organizer, out YarnProgram dialogue)
    {
        var time = state.currentTime;
        var day = state.currentDay;
        dialogue = null;

        if (day >= organizer.dialoguesPerDays.Count) {
            return false;
        }

        if (time == TimeOfDay.Morning && !state.playedAMDialog) {
            dialogue = organizer.dialoguesPerDays[day].MorningDialogue;
            return organizer.dialoguesPerDays[day].MorningLocation == "Outside";
        }

        if (time == TimeOfDay.Evening && !state.playedPMDialog) {
            dialogue = organizer.dialoguesPerDays[day].EveningDialogue;
            return organizer.dialoguesPerDays[day].EveningLocation == "Outside";
        }

        return false;
    }


}
