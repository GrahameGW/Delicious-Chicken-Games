using UnityEngine;

[CreateAssetMenu(menuName = "Arc State/Carla's Arc")]
public class CarlaArc : Arc
{
    [SerializeField] BroadcastItems interviews = default;
    [SerializeField] BroadcastClip[] carlasClips = new BroadcastClip[3];
    [SerializeField] GlobalState state = default;
    [SerializeField] RuthArc ruth = default;
    [SerializeField] DialogueOrganizer organizer = default;
    [SerializeField] YarnProgram finalYarn = default;

    public int currentClip = 0;
    public bool isDone = false;

    public override void OnBroadcast(BroadcastClip clip, int day)
    {

        interviews.UseClip(clip);
        currentClip++;
        if (currentClip < carlasClips.Length)
            interviews.clips.Add(carlasClips[currentClip]);
        else if (state.carlaScore > 0 && ruth.isDone) {
            // add to dialog organizer
            organizer.SetNextEvening(finalYarn, "Outside", state.currentDay);
        }
    }
}

