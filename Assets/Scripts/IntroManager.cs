using SimpleSceneTransitions;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;


public class IntroManager : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner = default;
    [SerializeField] YarnProgram yarnDialogue = default;
    [SerializeField] string nextScene = default;
    [SerializeField]
    private Color fadeColor = default;
    [SerializeField]
    private float fadeMultiplier = default;
    [SerializeField] string[] startNodes = default;
    [SerializeField] Sprite[] backdrops = default;
    [SerializeField] SpriteRenderer activeBackdrop = default;
    [SerializeField] CanvasGroup overlay = default;
    [SerializeField]
    private float waitBeforeInput = 2.0f;
    [SerializeField]
    private float fadeTime = 1.0f;
    [SerializeField]
    private float dialogDelay = 1.0f;
    [SerializeField] GameObject clickToContinueText = default;


    private int currentNode = 0;

    private void Start()
    {
        dialogueRunner.Add(yarnDialogue);
        StartCoroutine(WaitForNewPanel());
    }

    void StartPanel()
    {
        Debug.Log(currentNode);
        if (!string.IsNullOrEmpty(startNodes[currentNode]))
            dialogueRunner.StartDialogue(startNodes[currentNode]);
        else
            StartCoroutine(WaitForPlayerInput());

    }

    // Accessed by yarn
    public void QueueNext()
    {
        currentNode++;
        if (currentNode >= startNodes.Length)
            LoadNextScene();
        else
            StartCoroutine(WaitForNewPanel());
    }

    public void LoadNextScene()
    {
        Initiate.Fade(nextScene, fadeColor, fadeMultiplier);
    }

    private IEnumerator WaitForNewPanel()
    {
        overlay.blocksRaycasts = true;
        // fade out
        for (float i = 0; i < fadeTime; i += Time.deltaTime) {
            float a = i / fadeTime;
            overlay.alpha = a;
            yield return null;
        }
        activeBackdrop.sprite = backdrops[currentNode];

        // fade in
        for (float i = 0; i < fadeTime; i += Time.deltaTime) {
            float a = 1-(i / fadeTime);
            overlay.alpha = a;
            yield return null;
        }

        overlay.alpha = 0;
        overlay.blocksRaycasts = false;
        yield return new WaitForSeconds(dialogDelay);
        StartPanel();
    }

    IEnumerator WaitForPlayerInput()
    {
        yield return new WaitForSeconds(waitBeforeInput);
        Debug.Log("Can click");
        clickToContinueText.SetActive(true);

        while (true) {
            if (Input.anyKeyDown) {
                QueueNext();
                clickToContinueText.SetActive(false);
                yield break;
            }

            yield return null;
        }
    }
}
