using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn.Unity;


public class IntroManager : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner = default;
    [SerializeField] YarnProgram yarnDialogue = default;
    [SerializeField] string nextScene = default;
    [SerializeField] string[] startNodes = default;
    [SerializeField] Sprite[] backdrops = default;
    [SerializeField] SpriteRenderer activeBackdrop = default;
    [SerializeField]
    private float waitBeforeInput = 2.0f;


    private int currentNode = 0;

    private void Awake()
    {
        dialogueRunner.Add(yarnDialogue);
    }

    void Start()
    {
        Debug.Log(currentNode);
        if (!string.IsNullOrEmpty(startNodes[currentNode]))
            dialogueRunner.StartDialogue(startNodes[currentNode]);
        else
            StartCoroutine(WaitForPlayerInput());

        activeBackdrop.sprite = backdrops[currentNode];
    }

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
        SceneManager.LoadScene(nextScene);
    }

    private IEnumerator WaitForNewPanel()
    {
        yield return null;
        Start();
    }

    IEnumerator WaitForPlayerInput()
    {
        yield return new WaitForSeconds(waitBeforeInput);
        Debug.Log("Can click");

        while (true) {
            Debug.Log(Input.anyKeyDown);
            if (Input.anyKeyDown) {
                currentNode++;
                Start();

                yield break;
            }

            yield return null;
        }
    }
}
