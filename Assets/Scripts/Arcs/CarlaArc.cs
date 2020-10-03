using UnityEngine;

[CreateAssetMenu(menuName = "Arc State/Carla's Arc")]
public class CarlaArc : Arc
{
    [SerializeField] BroadcastItems interviews = default;
    [SerializeField] BroadcastClip[] carlasClips = new BroadcastClip[3];

    public int currentClip = 0;

    public override void OnBroadcast(BroadcastClip clip, int day)
    {

         interviews.UseClip(clip);
        currentClip++;
        if (currentClip < carlasClips.Length)
            interviews.clips.Add(carlasClips[currentClip]);
    }
}

