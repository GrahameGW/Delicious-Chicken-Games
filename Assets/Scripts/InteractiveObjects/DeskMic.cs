
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeskMic : InteractiveObject
{
    [SerializeField] GameObject confirmBroadcastPanel = default;

    protected override void Start()
    {
        base.Start();
        confirmBroadcastPanel.SetActive(false);
    }
    public override void Execute()
    {
        if (globalState.currentTime == TimeOfDay.Morning) {
            ToggleBroadcastPanel();
        }
    }

    public void ToggleBroadcastPanel()
    {
        confirmBroadcastPanel.SetActive(!confirmBroadcastPanel.activeSelf);
    }

    public void GoLive()
    {
        globalState.currentTime = TimeOfDay.Broadcast;
        SceneManager.LoadScene("BroadcastSequence");
    }
}
