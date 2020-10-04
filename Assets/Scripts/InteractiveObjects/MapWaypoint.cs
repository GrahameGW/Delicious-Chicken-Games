using UnityEngine;
using SimpleSceneTransitions;

public class MapWaypoint : InteractiveObject
{
    [SerializeField] Sprite daySprite = default;
    [SerializeField] Sprite dayHighlightedSprite = default;
    [SerializeField] Sprite nightSprite = default;
    [SerializeField] Sprite nightHighlightedSprite = default;
    [SerializeField] string location = default;

    public override void Execute()
    {
        Initiate.Fade(location, Color.black, 1.0f);
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
