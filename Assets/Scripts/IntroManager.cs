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
    [SerializeField] Image[] backdrops = default;
    [SerializeField] Image activeBackdrop = default;

    private int currentNode = 0;

    void Start()
    {
        dialogueRunner.Add(yarnDialogue);
        dialogueRunner.StartDialogue(startNodes[currentNode]);
    }

    public void QueueNext()
    {
        currentNode++;
        if (currentNode >= startNodes.Length)
            LoadNextScene();
        else StartCoroutine(WaitForNewPanel());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private IEnumerator WaitForNewPanel()
    {
        activeBackdrop = backdrops[currentNode];
        yield return null;
        dialogueRunner.StartDialogue(startNodes[currentNode]);
    }
}
