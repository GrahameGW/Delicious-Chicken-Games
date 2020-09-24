using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    private Coroutine travelInst = null;

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
        if (Mathf.Abs(transform.position.x - newPosition.x) <= 0.05f) {
            yield break;
        }

        Vector2 a = transform.position;
        Vector2 b = new Vector2(newPosition.x, newPosition.y);
        float dist = speed / Vector2.Distance(b, a);

        for (float t = 0f; t < 1f; t += Time.deltaTime * dist ) {
            transform.position = Vector3.Lerp(a, b, t);
            yield return null;
        }
    }
}
