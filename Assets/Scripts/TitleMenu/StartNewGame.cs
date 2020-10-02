using System.Collections;
using UnityEngine;

public class StartNewGame : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    [SerializeField] GlobalState startingState = default;

    [SerializeField] StudioState studioState = default;
    [SerializeField] StudioState defaultStudio = default;

    [SerializeField] CanvasGroup toFade = default;

    public void NewGame()
    {
        StartCoroutine(HideUI());
        startingState.Copy(globalState);
        defaultStudio.Copy(studioState);
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
