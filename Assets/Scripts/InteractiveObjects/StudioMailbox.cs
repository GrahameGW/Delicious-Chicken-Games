using System.Collections;
using UnityEngine;

public class StudioMailbox : InteractiveObject
{
    [SerializeField] StudioState studioState = default;
    [SerializeField] Vector2 playerPosition = default;
    private PlayerController player;
    private Coroutine travelInst;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public override void Execute()
    {
        if (!studioState.mailChecked) {
            if (travelInst != null) StopCoroutine(travelInst);
            travelInst = StartCoroutine(WaitForPlayerArrival());
        }
    }

    public override void Highlight()
    {
        if (!studioState.mailChecked) {
            base.Highlight();
        }
    }

    private IEnumerator WaitForPlayerArrival()
    {
        player.StartTravel(playerPosition, false);
        while (Vector2.Distance(player.transform.position, playerPosition) >= 0.05f) {
            yield return null;
        }
        CheckMail();
    }

    private void CheckMail()
    {
        Debug.Log("Checked mail");
        studioState.mailChecked = true;
    }
}


