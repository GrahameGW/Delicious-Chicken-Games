using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StudioDesk : MonoBehaviour
{
    private bool isHighlighted = false;
    private Collider2D deskCollider;
    private Coroutine waitForPlayerInst;

    private GameObject player;

    private void Start()
    {
        deskCollider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            bool isHit = hit.collider == deskCollider;
            
            if (Input.GetButtonDown("Fire1")) {
                if (waitForPlayerInst != null)
                    StopCoroutine(waitForPlayerInst);
                if (isHit)
                    waitForPlayerInst = StartCoroutine(WaitForPlayerArrival());
            }

            Highlight(isHit);
        }
    }

    private void Highlight(bool onOff)
    {
        isHighlighted = onOff;
        // TODO: Highlight desk object
    }

    private IEnumerator WaitForPlayerArrival()
    {
        // create smaller bounding zone
        Vector2 center = deskCollider.bounds.center;
        Vector2 extents = deskCollider.bounds.extents;
        Vector2[] corners = new Vector2[] {
            new Vector2(center.x, center.y + 0.5f * extents.y),
            new Vector2(center.x, center.y - 0.5f * extents.y),
            new Vector2(center.x + 0.5f * extents.x, center.y),
            new Vector2(center.x - 0.5f * extents.x, center.y)
        };
        Polygon2D polygon = new Polygon2D(corners);

        while (!polygon.Contains(player.transform.position)) {
            yield return null;
        }

        SceneManager.LoadScene("DeskCloseup");
    }
}
