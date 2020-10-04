using UnityEngine;

[CreateAssetMenu(menuName = "Arc State/Lera's Arc")]
public class LerasArc : Arc
{
    [SerializeField] DialogueOrganizer organizer = default;
    [SerializeField] BroadcastItems interviews = default;
    [SerializeField] YarnProgram followupLetter = default;

    public bool hasMet = false;
    public int score = 0;
    public bool didBroadcast = false;

    public override void OnBroadcast(BroadcastClip clip, int day)
    {
        interviews.UseClip(clip);

        if (clip.name.Equals("Reader Mail - Lera's Letter") && !didBroadcast) {
            didBroadcast = true;
            organizer.dialoguesPerDays[day + 1].LetterDialogue = followupLetter;
        }
    }
}

