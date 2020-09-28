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

        while (Vector2.Distance(transform.position, destination) >= 0.05f)
        {
            if (walkableBounds.OverlapPoint((Vector2)transform.position + (direction * Time.deltaTime * speed)))
            {
                transform.Translate(direction * Time.deltaTime * speed);
                transform.localScale = ScaleWithDistance(transform.position);
            }
            else
            {
                //If blindly going in the direction we'd like to get to takes us outside of walkable bounds, try going around
                if (!walkableBounds.OverlapPoint(transform.position)) Debug.LogError("Player outside of walkable bounds");

                RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + (direction * Time.deltaTime * speed), -direction, 1f, LayerMask.GetMask("WalkBounds"));

                if (hit.collider == null) { Debug.LogError("No valid collision from player controller walk bounds."); }
                else
                {
                    //Cross product of walk bounds normal and the z vector gets us a vector along the collider's side
                    Vector3 tempDirection = Vector3.Cross(hit.normal, Vector3.forward);

                    //Dot product of that direction lets us direct naively in the direction that takes us more towards our target
                    if (Vector3.Dot(tempDirection, direction) < 0) tempDirection = -tempDirection;

                    //if this doesn't work, we just stop, since we're in a corner
                    if (!walkableBounds.OverlapPoint(transform.position + (tempDirection * Time.deltaTime * speed))) { break; }
                    else
                    {
                        transform.Translate(tempDirection * Time.deltaTime * speed);
                        transform.localScale = ScaleWithDistance(transform.position);
                    }
                }
            }
            
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
