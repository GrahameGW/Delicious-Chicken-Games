using UnityEngine;
using SimpleSceneTransitions;

public class StudioWaypoint : InteractiveObject
{
    [SerializeField] Sprite daySprite = default;
    [SerializeField] Sprite dayHighlightedSprite = default;
    [SerializeField] Sprite nightSprite = default;
    [SerializeField] Sprite nightHighlightedSprite = default;

    public override void Execute()
    {
        Initiate.Fade("Outside", Color.black, 1.0f);
    }

    private void OnEnable()
    {
        if (globalState.currentTime == TimeOfDay.Morning) {
            spriteRenderer.sprite = atRestSprite = daySprite;
            highlightSprite = dayHighlightedSprite;
        }
        if (globalState.currentTime == TimeOfDay.Evening) {
            spriteRenderer.sprite = atRestSprite = nightSprite;
            highlightSprite = nightHighlightedSprite;
        }
    }
}