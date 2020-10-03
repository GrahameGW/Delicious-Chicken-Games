using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class StudioMailbox : WalkableInteractiveObject
{
    [SerializeField] StudioState studioState = default;
    [SerializeField] DialogueOrganizer dialogueOrganizer = default;
    [SerializeField] DialogueRunner dialogueRunner = default;

    protected override void Start()
    {
        base.Start();
    }

    public override void Highlight()
    {
        if (!studioState.mailChecked) {
            base.Highlight();
        }
    }

    protected override void OnArrival()
    {
        //Debug.Log("Checked mail");
        DeHighlight();

        dialogueRunner.Add(dialogueOrganizer.dialoguesPerDays[globalState.currentDay].LetterDialogue);

        dialogueRunner.StartDialogue("Start");

        studioState.mailChecked = true;
    }
}


