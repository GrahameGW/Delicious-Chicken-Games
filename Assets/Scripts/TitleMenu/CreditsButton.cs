using UnityEngine;

namespace TitleScreen
{
    public class CreditsButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject creditsDisplay = default;
        [SerializeField]
        private GameObject menuButtons = default;

        void Start()
        {
            creditsDisplay.SetActive(false);
        }

        public void ShowCredits()
        {
            creditsDisplay.SetActive(true);
            menuButtons.SetActive(false);
        }

        public void HideCredits()
        {
            creditsDisplay.SetActive(false);
            menuButtons.SetActive(true);
        }
    }
}

