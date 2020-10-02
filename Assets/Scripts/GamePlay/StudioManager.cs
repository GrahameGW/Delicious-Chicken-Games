using UnityEngine;

public class StudioManager : MonoBehaviour
{
    public static StudioManager Instance { get; private set; }

    [SerializeField] StudioState state = default;
    [SerializeField] GlobalState globalState = default;
    [SerializeField] GameObject player = default;
    private SpriteRenderer playerSprite;

    int day;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else {
            Destroy(Instance);
            Instance = this;
        }

        playerSprite = player.GetComponentInChildren<SpriteRenderer>();
        OpenStudio();
        day = globalState.currentDay;
    }

    public void OpenStudio()
    {
        LoadState();
        /*
        if (globalState.currentTime == TimeOfDay.Morning && !globalState.playedAMDialog) {
            if (scheduledAMDialogs[day] != null) {
                dialogueRunner.Add(scheduledAMDialogs[day]);
                dialogueRunner.StartDialogue("Start");
                globalState.playedAMDialog = true;
            }
        }
        else if (globalState.currentTime == TimeOfDay.Evening && !globalState.playedPMDialog) {
            if (scheduledPMDialogs[day] != null) {
                dialogueRunner.Add(scheduledPMDialogs[day]);
                dialogueRunner.StartDialogue("Start");
                globalState.playedPMDialog = true;
            }
        }
        */
    }

    public void LeaveStudio()
    {
        SaveState();
    }

    private void SaveState()
    {
        state.playerPosition = player.transform.position;
        state.playerLocalScale = player.transform.localScale;
        state.playerFaceLeft = playerSprite.flipX;
    }

    private void LoadState()
    {
        player.transform.position = state.playerPosition;
        player.transform.localScale = state.playerLocalScale;
        playerSprite.flipX = state.playerFaceLeft;
    }

    public void TogglePlayerController()
    {
        player.gameObject.SetActive(!player.activeSelf);
    }
}
