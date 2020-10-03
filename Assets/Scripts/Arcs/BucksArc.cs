using UnityEngine;

[CreateAssetMenu(menuName = "Arc State/Bucks's Arc")]
public class BucksArc : Arc
{
    [SerializeField] BroadcastItems interviews = default;
    [SerializeField] BroadcastClip[] bucksClips = new BroadcastClip[3];

    public bool hasMet = false;
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

