using UnityEngine;

[CreateAssetMenu(menuName = "Arc State/Luis Arc")]
public class LuisArc : Arc { 
    [SerializeField] DialogueOrganizer organizer = default;
    [SerializeField] BroadcastItems ads = default;
    [SerializeField] YarnProgram introDialog = default;
    [SerializeField] GlobalState state = default;

    public float score = 0;
    public float dupAdMultiplier = 1.0f;
    public float moneyMultiplier = 100.0f;
    private string previousAd;
    public bool didAd = false;

    public override void OnBroadcast(BroadcastClip clip, int day)
    {
        if (clip.GetType() == typeof(AdvertClip) && !didAd) {
            didAd = true;
            organizer.SetNextEvening(introDialog, "Outside", state.currentDay);
            AdAffectsScore(clip);
        }
    }

    private void AdAffectsScore(BroadcastClip ad)
    {
        float adScore = ads.clips.IndexOf(ad);
        if (ad.name.Equals(previousAd)) {
            adScore *= dupAdMultiplier;
        }

        score += adScore;
        state.luisScore = score;
        state.money += adScore * moneyMultiplier;
    }
}

