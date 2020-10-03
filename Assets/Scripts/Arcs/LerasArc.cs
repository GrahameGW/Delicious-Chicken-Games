using UnityEngine;

[CreateAssetMenu(menuName = "Arc State/Lera's Arc")]
public class LerasArc : Arc
{
    [SerializeField] DialogueOrganizer organizer = default;
    [SerializeField] BroadcastItems interviews = default;
    [SerializeField] YarnProgram followupLetter = default;
    [SerializeField] GlobalState state = default;

    public bool hasMet = false;
    public int score = 0;
    public bool didBroadcast = false;

    public override void OnBroadcast(BroadcastClip clip, int day)
    {
        if (clip.name.Equals("Reader Mail - Lera's Letter") && !didBroadcast) {
            didBroadcast = true;
            interviews.UseClip(clip);
            organizer.dialoguesPerDays[day + 1].LetterDialogue = followupLetter;
        }
    }
}

