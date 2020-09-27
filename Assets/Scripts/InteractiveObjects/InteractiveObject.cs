using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractiveObject : MonoBehaviour
{
    protected bool isHighlighted = false;

    [SerializeField] Sprite atRestSprite = default;
    [SerializeField] Sprite highlightSprite = default;
    [SerializeField]
    protected string actionDescription = default;

    [SerializeField]
    protected GlobalState globalState = default;

    protected SpriteRenderer spriteRenderer;
    protected Collider2D ioCollider;

    protected TextMeshProUGUI actionText;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ioCollider = GetComponent<Collider2D>();
    }
    protected virtual void Start()
    {
        InputManager.Instance.OnMousePositionChange.AddListener(OnMousePosChangeListener);
        actionText = GameObject.FindGameObjectWithTag("ActionDescription").GetComponent<TextMeshProUGUI>();
        spriteRenderer.sprite = atRestSprite;
    }
    private void OnDestroy()
    {
        if (InputManager.Instance != null)
            InputManager.Instance.OnMousePositionChange.RemoveListener(OnMousePosChangeListener);
    }

    public virtual void Highlight()
    {
        spriteRenderer.sprite = highlightSprite;
        isHighlighted = true;
        InputManager.Instance.currentlyHighlighted = this;
        actionText.text = actionDescription;
    }
    public void DeHighlight()
    {
        spriteRenderer.sprite = atRestSprite;
        isHighlighted = false;

        if (InputManager.Instance.currentlyHighlighted == this) {
            InputManager.Instance.currentlyHighlighted = null;
        }
        if (actionText.text == actionDescription) {
            actionText.text = null;
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


