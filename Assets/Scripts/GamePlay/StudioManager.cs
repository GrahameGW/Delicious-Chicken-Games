using System.Collections;
using UnityEngine;
using SimpleSceneTransitions;
using Yarn.Unity;

public class StudioManager : MonoBehaviour
{
    public static StudioManager Instance { get; private set; }

    [SerializeField] StudioState state = default;
    [SerializeField] GlobalState globalState = default;
    [SerializeField] GameObject player = default;
    [SerializeField] float dialogStartDelay = 1.0f;
    [SerializeField] DialogueOrganizer dialogOrganizer = default;
    [SerializeField] DialogueRunner dialogRunner = default;

    //[SerializeField] GameObject endDaybtn = default;
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
        day = globalState.currentDay;
    }

    public void Start()
    {
        LoadState();
        YarnProgram dialogue;
        if (GetDialog(globalState, dialogOrganizer, out dialogue)) {
            StartCoroutine(PlayDialog(dialogue, globalState.currentTime));
        }
        //endDaybtn.SetActive(globalState.currentTime == TimeOfDay.Evening);

        if (dialogOrganizer.dialoguesPerDays[globalState.currentDay].LetterDialogue == null)
        {
            state.mailChecked = true;
        }
    }

    private IEnumerator PlayDialog(YarnProgram dialog, TimeOfDay time)
    {
        dialogRunner.Add(dialog);

        if (time == TimeOfDay.Morning) {
            globalState.playedAMDialog = true;
        }
        if (time == TimeOfDay.Evening) {
            globalState.playedPMDialog = true;
        }

        yield return new WaitForSeconds(dialogStartDelay);
        dialogRunner.StartDialogue("Start");
    }
    private bool GetDialog(GlobalState state, DialogueOrganizer organizer, out YarnProgram dialogue)
    {
        var time = state.currentTime;
        var day = state.currentDay;
        dialogue = null;

        if (day >= organizer.dialoguesPerDays.Count) {
            return false;
        }
        
        if (time == TimeOfDay.Morning && !state.playedAMDialog) {
            dialogue = organizer.dialoguesPerDays[day].MorningDialogue;
            return organizer.dialoguesPerDays[day].MorningLocation == "Studio";
        }

        if (time == TimeOfDay.Evening && !state.playedPMDialog) {
            dialogue = organizer.dialoguesPerDays[day].EveningDialogue;
            return organizer.dialoguesPerDays[day].EveningLocation == "Studio";
        }

        return false;
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

    //public void EndDay(float fadespeed)
    //{
    //    SaveState();
    //    endDaybtn.SetActive(false);
    //    Initiate.Fade("EndOfDay", Color.black, fadespeed);
    //}
}
