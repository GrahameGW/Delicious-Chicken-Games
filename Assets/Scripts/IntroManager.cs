using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
using Yarn;

public class IntroManager : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] YarnProgram yarnDialogue;
    [SerializeField] string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner.Add(yarnDialogue);
        dialogueRunner.StartDialogue();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
