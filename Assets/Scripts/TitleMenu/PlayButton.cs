using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitleScreen
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField]
        private string nextScene = default;

        public void Play()
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}

