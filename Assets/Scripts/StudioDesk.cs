using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudioDesk : InteractiveObject
{

    [Range(0, 1)]
    [SerializeField]
    [Tooltip("Controls the size of the trigger box as a percent of the collider size. Action occurs when player in the box")]
    private float xTriggerModifier = default;
    [Range(0, 1)]
    [SerializeField]
    [Tooltip("Controls the size of the trigger box as a percent of the collider size. Action occurs when player in the box")]
    private float yTriggerModifier = default;

    private Coroutine waitForPlayerInst = null;
    private PlayerController player;

    private Polygon2D triggerPolygon;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        triggerPolygon = ResizeTriggerZone(ioCollider);
        Debug.Log(ioCollider.bounds);
    }

    public override void Execute()
    {
        if (waitForPlayerInst != null)
            StopCoroutine(waitForPlayerInst);

        waitForPlayerInst = StartCoroutine(WaitForPlayerArrival());
    }

    private IEnumerator WaitForPlayerArrival()
    {
        player.StartTravel(transform.position);
        while (!triggerPolygon.Contains(player.transform.position)) {
            yield return null;
        }
        SceneManager.LoadScene("DeskCloseup");
    }

    private Polygon2D ResizeTriggerZone(Collider2D collider)
    {
        // create smaller bounding zone
        Vector2 center = collider.bounds.center;
        Vector2 extents = collider.bounds.extents;
        Vector2[] corners = new Vector2[] {
            new Vector2(center.x, center.y + yTriggerModifier * extents.y),
            new Vector2(center.x, center.y - yTriggerModifier * extents.y),
            new Vector2(center.x + xTriggerModifier * extents.x, center.y),
            new Vector2(center.x - xTriggerModifier * extents.x, center.y)
        };
        return new Polygon2D(corners);
    }
}
