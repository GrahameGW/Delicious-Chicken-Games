using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitleScreen
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField]
        private string startScene = default;

        public void Play()
        {
            SceneManager.LoadScene(startScene);
        }
    }
}

