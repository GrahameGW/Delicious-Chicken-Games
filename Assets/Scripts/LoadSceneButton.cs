using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private string nextScene = default;

    public void Load()
    {
        SceneManager.LoadScene(nextScene);
    }
}

