using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    protected bool isHighlighted = false;

    [SerializeField] Sprite atRestSprite = default;
    [SerializeField] Sprite highlightSprite = default;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = atRestSprite;
        InputManager.Instance.OnMousePositionChange.AddListener(OnMousePosChangeListener);
    }
    private void OnDestroy()
    {
        if (InputManager.Instance != null)
            InputManager.Instance.OnMousePositionChange.RemoveListener(OnMousePosChangeListener);
    }
    private void Update()
    {
        if (isHighlighted && Input.GetButtonDown("Fire1")) {
            Execute();
        }
    }

    public void Highlight()
    {
        spriteRenderer.sprite = highlightSprite;
        isHighlighted = true;
    }
    public void DeHighlight()
    {
        spriteRenderer.sprite = atRestSprite;
        isHighlighted = false;
    }

    protected virtual void OnMousePosChangeListener(Vector2 position)
    {
        if (spriteRenderer.sprite.bounds.Contains(position)) {
            Highlight();
        }
        else {
            DeHighlight();
        }
    }

    protected abstract void Execute();
}


