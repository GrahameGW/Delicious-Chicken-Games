using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float minY, maxY;
    public float minScale, maxScale;

    [SerializeField]
    private float speed = 2.0f;
    private Coroutine travelInst = null;

    private void Start()
    {
        InputManager.Instance.OnMousePositionChange.AddListener(OnMousePosChangeListener);
    }
    private void OnDestroy()
    {
        if (InputManager.Instance != null)
            InputManager.Instance.OnMousePositionChange.RemoveListener(OnMousePosChangeListener);
    }

    private void OnMousePosChangeListener(Vector2 position)
    {

    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetButtonDown("Fire1")) {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (travelInst != null) StopCoroutine(travelInst);
                travelInst = StartCoroutine(Travel(worldPosition));
            }
        }
    }

    private IEnumerator Travel(Vector3 newPosition)
    {
        Vector2 target = new Vector2(newPosition.x, newPosition.y);
        target = ClampToScreen(target);
        Vector2 direction = (target - (Vector2)transform.position).normalized;

        while (Vector2.Distance(transform.position, target) > 0.05f) {
            transform.Translate(direction * Time.deltaTime * speed);
            transform.localScale = ScaleWithDistance(transform.position);
            yield return null;
        }
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
