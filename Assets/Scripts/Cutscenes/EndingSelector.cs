using UnityEngine;

public class EndingSelector : MonoBehaviour
{
    [SerializeField] GlobalState globalState = default;
    [SerializeField] IntroSceneLoader loader = default;
    [SerializeField] IntroManager goodManager = default;
    [SerializeField] IntroManager badManager = default;

    private void Start()
    {
        // todo: logic for selecting ending.
        loader.yarnManager = goodManager;
        loader.gameObject.SetActive(true);
    }
}
