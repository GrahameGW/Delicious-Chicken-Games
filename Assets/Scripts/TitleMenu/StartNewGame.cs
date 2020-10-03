using System.Collections;
using UnityEngine;

public class StartNewGame : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    [SerializeField] GlobalState startingState = default;

    [SerializeField] StudioState studioState = default;
    [SerializeField] StudioState defaultStudio = default;

    [SerializeField] DialogueOrganizer dialogOrg = default;
    [SerializeField] DialogueOrganizer defaultDialog = default;

    [SerializeField] LerasArc startingLera = default;
    [SerializeField] LerasArc lerasArc = default;

    [SerializeField] LuisArc startingLuis = default;
    [SerializeField] LuisArc luisArc = default;

    [SerializeField] BucksArc startingBuck = default;
    [SerializeField] BucksArc buckArc = default;

    [SerializeField] CarlaArc startingCarla = default;
    [SerializeField] CarlaArc carlaArc = default;

    [SerializeField] BroadcastItems startingInterviews = default;
    [SerializeField] BroadcastItems interviews = default;

    [SerializeField] CanvasGroup toFade = default;

    public void NewGame()
    {
        StartCoroutine(HideUI());
        startingState.Copy(globalState);
        defaultStudio.Copy(studioState);
        defaultDialog.Copy(dialogOrg);
        startingLera.Copy(lerasArc);
        startingLuis.Copy(luisArc);
        startingBuck.Copy(buckArc);
        startingInterviews.Copy(interviews);
        startingCarla.Copy(carlaArc);
    }

    IEnumerator HideUI()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f) {
            toFade.alpha = ft;
            yield return null;
        }
        toFade.gameObject.SetActive(false);
    }
}
