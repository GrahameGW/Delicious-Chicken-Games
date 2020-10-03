using UnityEngine;

public class OverworldMap : MonoBehaviour
{
    [SerializeField] Sprite dayMap = default;
    [SerializeField] Sprite eveMap = default;

    [SerializeField] GlobalState globalState = default;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (globalState.currentTime == TimeOfDay.Morning) {
            spriteRenderer.sprite = dayMap;
        }
        if (globalState.currentTime == TimeOfDay.Evening) {
            spriteRenderer.sprite = eveMap;
        }
    }
}
