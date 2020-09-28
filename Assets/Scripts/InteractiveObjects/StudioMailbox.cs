using System.Collections;
using UnityEngine;

public class StudioMailbox : WalkableInteractiveObject
{
    [SerializeField] StudioState studioState = default;

    protected override void Start()
    {
        base.Start();
    }

    public override void Highlight()
    {
        if (!studioState.mailChecked) {
            base.Highlight();
        }
    }

    protected override void OnArrival()
    {
        Debug.Log("Checked mail");
        studioState.mailChecked = true;
    }
}


