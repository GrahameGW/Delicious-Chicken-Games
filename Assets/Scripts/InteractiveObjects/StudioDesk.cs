using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudioDesk : InteractiveObject
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnArrival()
    {
        StudioManager.Instance.LeaveStudio();
        SceneManager.LoadScene("DeskCloseup");
    }
}
