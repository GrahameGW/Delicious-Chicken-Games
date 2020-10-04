using SimpleSceneTransitions;
using System.Collections;
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
    [SerializeField] YarnProgram noOneHereDialog = default;
    [SerializeField] GlobalState globalState = default;
    // Start is called before the first frame update
    void Start()
    {
        if (!lera.hasMet) {
            StartCoroutine(PlayDialog(firstMeetingDialog, TimeOfDay.Night)); // night so it does nothign
            lera.hasMet = true;
            buck.hasMet = true;
        }

        else {
            StartCoroutine(PlayDialog(noOneHereDialog, TimeOfDay.Night));
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

   public void LeaveGarage()
    {
        Initiate.Fade("OverworldMap", Color.black, 1.0f);
    }


}
