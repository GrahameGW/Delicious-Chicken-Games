using UnityEngine;

namespace TitleScreen
{
    public class QuitButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject confirmQuitPanel = default;
        [SerializeField]
        private GameObject menuButtons = default;

        private void Start()
        {
            confirmQuitPanel.SetActive(false);
        }

        public void QuitApp()
        {
            confirmQuitPanel.SetActive(true);
            menuButtons.SetActive(false);
        }

        public void ConfirmQuit()
        {
            Application.Quit();
        }

        public void CancelQuit()
        {
            confirmQuitPanel.SetActive(false);
            menuButtons.SetActive(true);
        }
    }
}

