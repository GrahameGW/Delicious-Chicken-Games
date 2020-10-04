using UnityEngine;

[CreateAssetMenu(menuName = "Arc State/Ruth's Arc")]
public class RuthArc : Arc
{
    [SerializeField] BroadcastItems interviews = default;
    [SerializeField] BroadcastClip ruthInterview = default;
    [SerializeField] CarlaArc carla = default;
    [SerializeField] GlobalState state = default;
    [SerializeField] DialogueOrganizer organizer = default;
    [SerializeField] BroadcastClip stories = default;
    [SerializeField] YarnProgram finalYarn = default;

    public bool isDone = false;

    public override void OnBroadcast(BroadcastClip clip, int day)
    {

        interviews.UseClip(clip);
        if (clip.Equals(ruthInterview)) {
            interviews.clips.Add(stories);
            isDone = true;
            if (carla.isDone && state.carlaScore > 0) {
                organizer.SetNextEvening(finalYarn, "Outside", state.currentDay);
            }
        }

        else interviews.clips.Add(ruthInterview);

    }
}

