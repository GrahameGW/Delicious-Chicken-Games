using System.Collections;
using UnityEngine;

public class OutroLoader : MonoBehaviour
{
    public IntroManager yarnManager = default;
    [SerializeField]
    private float waitBeforeInput = 3.0f;

    [SerializeField] GameObject textToContinue = default;

    private void Start()
    {
        StartCoroutine(WaitForPlayerInput());
    }

    IEnumerator WaitForPlayerInput()
    {
        yield return new WaitForSeconds(waitBeforeInput);
        textToContinue.SetActive(true);

        while (true) {
            if (Input.anyKey) {
                StartYarn();
                yield break;
            }

            yield return null;
        }
    }

    private void StartYarn()
    {
        yarnManager.gameObject.SetActive(true);
        textToContinue.SetActive(false);
    }
}
