using UnityEngine;

[CreateAssetMenu(menuName = "Arc State/Bucks's Arc")]
public class BucksArc : Arc
{
    [SerializeField] DialogueOrganizer organizer = default;
    [SerializeField] BroadcastItems interviews = default;
    [SerializeField] BroadcastClip[] bucksClips = new BroadcastClip[3];
    [SerializeField] GlobalState state = default;

    public bool hasMet = false;
    public int score = 0;
    public int currentClip = 0;

    public override void OnBroadcast(BroadcastClip clip, int day)
    {
        interviews.UseClip(clip);
        currentClip++;
        if (currentClip < bucksClips.Length)
            interviews.clips.Add(bucksClips[currentClip]);
    }

    public void Unlock()
    {
        hasMet = true;
        interviews.clips.Add(bucksClips[currentClip]);
    }
}

