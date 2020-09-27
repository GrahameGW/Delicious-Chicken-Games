using UnityEngine;

public class StudioDoorScenery : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    [SerializeField] Sprite daySprite = default;
    [SerializeField] Sprite nightSprite = default;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (globalState.currentTime == TimeOfDay.Morning) {
            spriteRenderer.sprite = daySprite;
        }
        if (globalState.currentTime == TimeOfDay.Evening) {
            spriteRenderer.sprite = nightSprite;
        }
    }
}


