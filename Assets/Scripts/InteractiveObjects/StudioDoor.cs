using System.Collections;
using UnityEngine;

public class StudioDoor : InteractiveObject
{
    [SerializeField] GameObject scenery = default;
    [SerializeField] Vector2 openDoorPosition = default;
    [SerializeField] string descriptionWhenClosed = default;
    [SerializeField] string descriptionWhenOpen = default;
    [SerializeField] SpriteRenderer doorSpriteRenderer = default;

    private bool isOpen = false;

    protected override void Start()
    {
        spriteRenderer = doorSpriteRenderer;
        actionDescription = descriptionWhenClosed;
        base.Start();
    }

    protected override void OnArrival()
    {
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
        }

        DeHighlight();
    }
}


