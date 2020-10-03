using UnityEngine;
using SimpleSceneTransitions;

public class ExteriorDoor : WalkableInteractiveObject
{
    protected override void OnArrival()
    {
        Initiate.Fade("Studio", Color.black, 1.2f);
    }
}


