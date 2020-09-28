using UnityEngine;
using UnityEngine.SceneManagement;

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
            actionDescription = nightAction;
        }
    }

    public override void Execute()
    {
        if (globalState.currentTime == TimeOfDay.Evening) {
            SceneManager.LoadScene("EndOfDay");
        }
    }
}


