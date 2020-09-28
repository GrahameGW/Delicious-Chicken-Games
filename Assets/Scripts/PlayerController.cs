using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float minY, maxY;
    public float minScale, maxScale;
    //[Range(-1, 1)]
    //[SerializeField]
    //[Tooltip("Where the character goes relative to the destination point")]
    //float clickOffsetY = default;
    [SerializeField] float speed = 2.0f;
    private Coroutine travelInst = null;

    [SerializeField] SpriteRenderer spriteRenderer = default;
    [SerializeField] Animator animator = default;

    [SerializeField] Collider2D walkableBounds;

    public void Awake()
    {
        if (walkableBounds == null)
        {
            Debug.LogError("No walkable boundary set to Player object!");
        }
    }

    public void StartTravel(Vector2 destination)
    {

        if (travelInst != null) StopCoroutine(travelInst);
        destination = ClampToWalkableBounds(destination);
        travelInst = StartCoroutine(Travel(destination));
    }

    private IEnumerator Travel(Vector2 destination)
    {
        animator.SetBool("walking", true);
        Vector2 direction = (destination - (Vector2)transform.position).normalized;
        spriteRenderer.flipX = direction.x < 0;

        while (Vector2.Distance(transform.position, destination) >= 0.05f) {
            transform.Translate(direction * Time.deltaTime * speed);
            transform.localScale = ScaleWithDistance(transform.position);
            yield return null;
        }
        animator.SetBool("walking", false);
    }

    private Vector2 ClampToWalkableBounds(Vector2 position)
    {
        if (!walkableBounds.OverlapPoint(position))
        {
            position = walkableBounds.ClosestPoint(position);
        }
        return position;
    }

    private Vector3 ScaleWithDistance(Vector3 position)
    {
        float ratio = (maxScale - minScale) / (walkableBounds.bounds.max.y - walkableBounds.bounds.min.y);
        float dist = transform.position.y - walkableBounds.bounds.min.y;
        float newScale = maxScale - (dist * ratio);
        return new Vector3(newScale, newScale, 0f);
    }
}
