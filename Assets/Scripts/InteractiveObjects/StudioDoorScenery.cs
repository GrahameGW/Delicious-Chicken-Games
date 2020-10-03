using SimpleSceneTransitions;
using UnityEngine;

public class StudioDoorScenery : InteractiveObject
{
    [SerializeField] Sprite daySprite = default;
    [SerializeField] Sprite dayHighlightedSprite = default;
    [SerializeField] Sprite nightSprite = default;
    [SerializeField] Sprite nightHighlightedSprite = default;
    [SerializeField] string nightAction = default;
    [SerializeField] string dayAction = default;


    private void OnEnable()
    {

        if (globalState.currentTime == TimeOfDay.Morning) {
            spriteRenderer.sprite = atRestSprite = daySprite;
            highlightSprite = dayHighlightedSprite;
            actionDescription = dayAction;
        }
        if (globalState.currentTime == TimeOfDay.Evening) {
            spriteRenderer.sprite = atRestSprite = nightSprite;
            highlightSprite = nightHighlightedSprite;
            actionDescription = globalState.currentDay != 9 ? nightAction : "Go to Festival";
        }
    }

    public override void Execute()
    {
        string target = globalState.currentDay != 9 ? "Outside" : "OutroSequence";
        Initiate.Fade(target, Color.black, 1.2f);
    }
}


