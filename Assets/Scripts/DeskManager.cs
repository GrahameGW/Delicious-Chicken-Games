using UnityEngine;

public class DeskManager : MonoBehaviour
{
    public static DeskManager Instance { get; private set; }
    [SerializeField] GlobalState globalState = default;
    [SerializeField] GameObject confirmBroadcastPanel = default;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else {
            Destroy(Instance);
            Instance = this;
        }
        confirmBroadcastPanel.SetActive(false);
    }

    public void StartBroadcast()
    {
        if (globalState.currentTime == TimeOfDay.Morning) {
            confirmBroadcastPanel.SetActive(true);
        }
    }

}
