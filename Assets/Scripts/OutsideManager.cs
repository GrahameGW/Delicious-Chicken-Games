using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class OutsideManager : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    [SerializeField] Sprite dayBgSprite = default;
    [SerializeField] Sprite eveningBgSprite = default;
    [SerializeField] GameObject player = default;
    [SerializeField] float dialogStartDelay = 1.0f;
    [SerializeField] DialogueOrganizer dialogOrganizer = default;
    [SerializeField] DialogueRunner dialogRunner = default;
    private SpriteRenderer playerSprite;
    private int day;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Vector2 startByDoor = default;
    [SerializeField] Vector2 startByRoad = default;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = player.GetComponentInChildren<SpriteRenderer>();
        day = globalState.currentDay;

        if (globalState.currentTime == TimeOfDay.Evening)
            spriteRenderer.sprite = eveningBgSprite;
        if (globalState.currentTime == TimeOfDay.Morning)
            spriteRenderer.sprite = dayBgSprite;
        YarnProgram dialogue;
        if (GetDialog(globalState, dialogOrganizer, out dialogue)) {
            StartCoroutine(PlayDialog(dialogue, globalState.currentTime));
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
            return organizer.dialoguesPerDays[day].MorningLocation == "Outside";
        }

        if (time == TimeOfDay.Evening && !state.playedPMDialog) {
            dialogue = organizer.dialoguesPerDays[day].EveningDialogue;
            return organizer.dialoguesPerDays[day].EveningLocation == "Outside";
        }

        return false;
    }

    public void TogglePlayerController()
    {
        player.gameObject.SetActive(!player.activeSelf);
    }
}
