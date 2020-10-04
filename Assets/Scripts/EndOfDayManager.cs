using SimpleSceneTransitions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOfDayManager : MonoBehaviour
{
    [SerializeField] GlobalState state = default;
    [SerializeField] TextMeshProUGUI moneyText = default;
    [SerializeField] TextMeshProUGUI dayText = default;
    [SerializeField] TextMeshProUGUI daysLeftText = default;
    [SerializeField] float waitBeforeInput = 2.0f;

    [SerializeField] CanvasGroup toFade = default;
    [SerializeField] GameObject textToContinue = default;
    int daysInTotal = 10;

    private void Start()
    {
        StartCoroutine(ShowUI());
        StartCoroutine(WaitForPlayerInput());
        moneyText.text = "Money earned: $" + state.money.ToString();
        dayText.text = "End of Day " + (state.currentDay + 1).ToString();
        daysLeftText.text = (daysInTotal - state.currentDay).ToString() + " days until the Harvest Festival...";
    }

    IEnumerator WaitForPlayerInput()
    {
        yield return new WaitForSeconds(waitBeforeInput);
        textToContinue.SetActive(true);

        while (true) {
            if (Input.anyKey) {
                textToContinue.SetActive(false);
                StartCoroutine(HideUI());
                Next();
                Initiate.Fade("Studio", Color.black, 1.0f);
                yield break;
            }

            yield return null;
        }
    }

    IEnumerator HideUI()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f) {
            toFade.alpha = ft;
            yield return null;
        }
        toFade.gameObject.SetActive(false);
    }

    IEnumerator ShowUI()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f) {
            toFade.alpha = ft;
            yield return null;
        }
        toFade.gameObject.SetActive(false);
    }

    public void Next()
    {
        state.currentDay++;
        state.currentTime = TimeOfDay.Morning;
        state.playedAMDialog = false;
        state.playedPMDialog = false;
    }
}
