using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractiveObject : MonoBehaviour
{
    protected bool isHighlighted = false;

    [SerializeField] Sprite atRestSprite = default;
    [SerializeField] Sprite highlightSprite = default;

    private SpriteRenderer spriteRenderer;
    protected Collider2D ioCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ioCollider = GetComponent<Collider2D>();
        spriteRenderer.sprite = atRestSprite;
    }
    protected virtual void Start()
    {
        InputManager.Instance.OnMousePositionChange.AddListener(OnMousePosChangeListener);
    }
    private void OnDestroy()
    {
        if (InputManager.Instance != null)
            InputManager.Instance.OnMousePositionChange.RemoveListener(OnMousePosChangeListener);
    }

    public void Highlight()
    {
        spriteRenderer.sprite = highlightSprite;
        isHighlighted = true;
        InputManager.Instance.currentlyHighlighted = this;
    }
    public void DeHighlight()
    {
        spriteRenderer.sprite = atRestSprite;
        isHighlighted = false;
        if (InputManager.Instance.currentlyHighlighted == this) {
            InputManager.Instance.currentlyHighlighted = null;
        }
    }

    protected virtual void OnMousePosChangeListener(Vector2 position)
    {
        if (ioCollider.bounds.Contains(position)) {
            Highlight();
        }
        else {
            DeHighlight();
        }
    }

    public abstract void Execute();
}


