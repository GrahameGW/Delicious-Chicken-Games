using System.Collections;
using UnityEngine;

public class IntroSceneLoader : MonoBehaviour
{
    public IntroManager yarnManager = default;
    [SerializeField]
    private float waitBeforeInput = 3.0f;

    private void Start()
    {
        StartCoroutine(WaitForPlayerInput());
    }

    IEnumerator WaitForPlayerInput()
    {
        yield return new WaitForSeconds(waitBeforeInput);


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
    }
}

