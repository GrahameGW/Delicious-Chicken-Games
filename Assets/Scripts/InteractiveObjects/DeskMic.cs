
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeskMic : InteractiveObject
{
    [SerializeField] GameObject confirmBroadcastPanel = default;
    [SerializeField] GameObject broadCastNotReadyPanel = default;
    [SerializeField] BroadcastSchedule broadcastSchedule = default;

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
        if (broadcastSchedule.musicSlot != null)
        {
            confirmBroadcastPanel.SetActive(!confirmBroadcastPanel.activeSelf);
        }
        else
        {
            ToggleBroadCastNotreadyPanel();
        }
        
    }

    public void ToggleBroadCastNotreadyPanel()
    {
        broadCastNotReadyPanel.SetActive(!broadCastNotReadyPanel.activeSelf);
    }

    public override void Highlight()
    {
        if (globalState.currentTime == TimeOfDay.Morning)
        {
            base.Highlight();
        }
    }

    public void GoLive()
    {
        globalState.currentTime = TimeOfDay.Broadcast;
        SceneManager.LoadScene("BroadcastSequence");
    }
}
