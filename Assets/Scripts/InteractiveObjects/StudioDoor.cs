using System.Collections;
using UnityEngine;

public class StudioDoor : InteractiveObject
{
    [SerializeField] GameObject scenery = default;
    [SerializeField] Vector2 openDoorPosition = default;
    [SerializeField] string descriptionWhenClosed = default;
    [SerializeField] string descriptionWhenOpen = default;
    [SerializeField] SpriteRenderer doorSpriteRenderer;

    private bool isOpen = false;
    private Vector2 colliderOffsetClosed;
    private PlayerController player;
    private Coroutine travelInst;

    protected override void Start()
    {
        spriteRenderer = doorSpriteRenderer;
        actionDescription = descriptionWhenClosed;
        colliderOffsetClosed = ioCollider.offset;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        base.Start();
    }
    public override void Execute()
    {
        if (travelInst != null) StopCoroutine(travelInst);
        travelInst = StartCoroutine(WaitForPlayerArrival());
    }

    private IEnumerator WaitForPlayerArrival()
    {
        var target = transform.position;
        player.StartTravel(target, false);
        while (Vector2.Distance(player.transform.position, target) >= 0.05f) {
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;
        spriteRenderer.flipX = isOpen;

        if (isOpen) {
            doorSpriteRenderer.transform.localPosition += (Vector3)openDoorPosition;
            scenery.SetActive(true);
            actionDescription = descriptionWhenOpen;
            ioCollider.offset += openDoorPosition;
        }
        else {
            doorSpriteRenderer.transform.localPosition -= (Vector3)openDoorPosition;
            scenery.SetActive(false);
            actionDescription = descriptionWhenClosed;
            ioCollider.offset = colliderOffsetClosed;
        }

        DeHighlight();
    }
}


