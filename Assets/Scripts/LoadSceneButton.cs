using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleSceneTransitions;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private string nextScene = default;

    [SerializeField]
    private Color fadeColor = default;
    [SerializeField]
    private float fadeMultiplier = default;

    public void Load()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadWithFade()
    {
        Initiate.Fade(nextScene, fadeColor, fadeMultiplier);
    }
}

