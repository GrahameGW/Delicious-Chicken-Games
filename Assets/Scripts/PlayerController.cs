using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float minY, maxY;
    public float minScale, maxScale;
    [SerializeField] float speed = 2.0f;
    private Coroutine travelInst = null;

    [SerializeField] SpriteRenderer spriteRenderer = default;
    [SerializeField] Animator animator = default;

    public void StartTravel(Vector2 destination)
    {
        if (travelInst != null) StopCoroutine(travelInst);
        travelInst = StartCoroutine(Travel(destination));
        animator.SetBool("walking", true);
    }

    private IEnumerator Travel(Vector2 destintation)
    {
        destintation = ClampToScreen(destintation);
        Vector2 direction = (destintation - (Vector2)transform.position).normalized;
        spriteRenderer.flipX = direction.x < 0;

            while (Vector2.Distance(transform.position, destintation) > 0.05f) {
            transform.Translate(direction * Time.deltaTime * speed);
            transform.localScale = ScaleWithDistance(transform.position);
            yield return null;
        }
        animator.SetBool("walking", false);
    }

    private Vector2 ClampToScreen(Vector2 position)
    {
        float newX = Mathf.Clamp(position.x, -3f, 3f);
        float newY = Mathf.Clamp(position.y, minY, maxY);
        return new Vector2(newX, newY);
    }

    private Vector3 ScaleWithDistance(Vector3 position)
    {
        float ratio = (maxScale - minScale) / (maxY - minY);
        float dist = transform.position.y - minY;
        float newScale = maxScale - (dist * ratio);
        return new Vector3(newScale, newScale, 0f);
    }
}
