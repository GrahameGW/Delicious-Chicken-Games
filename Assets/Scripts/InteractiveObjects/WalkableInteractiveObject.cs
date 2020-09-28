using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableInteractiveObject : InteractiveObject
{
    [SerializeField] protected Collider2D arrivalPolygon;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerController>();
    }

    protected virtual IEnumerator WaitForPlayerArrival()
    {
        player.StartTravel(transform.position);
        while (!arrivalPolygon.OverlapPoint(player.transform.position))
        {
            yield return null;
        };
        OnArrival();
    }

    protected virtual void OnArrival()
    {

    }

    public override void Execute()
    {
        if (waitForPlayerInst != null)
            StopCoroutine(waitForPlayerInst);

        waitForPlayerInst = StartCoroutine(WaitForPlayerArrival());
    }
}
