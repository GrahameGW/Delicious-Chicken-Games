using UnityEngine;
using Yarn.Unity;

public class EndingSelector : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    [SerializeField] IntroSceneLoader loader = default;
    [SerializeField] IntroManager goodManager = default;
    [SerializeField] IntroManager badManager = default;
    [SerializeField] DialogueUI dialogueUI = default;

    private IntroManager managerSelected;

    private void Start()
    {
        // todo: logic for selecting ending. 
        managerSelected = globalState.NetScore > 1 ? goodManager : badManager;
        loader.yarnManager = managerSelected;
        loader.gameObject.SetActive(true);
        dialogueUI.gameObject.SetActive(true);
        dialogueUI.onDialogueEnd.AddListener(() => { managerSelected.QueueNext(); });
        dialogueUI.gameObject.SetActive(false);
    }

    public void QueueNext()
    {

    }
}
