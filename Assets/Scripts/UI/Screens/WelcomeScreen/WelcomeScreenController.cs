using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.WelcomeScreen
{
    public class WelcomeScreenController : BaseMainMenuScreenController
    {
        [field: SerializeField]
        private Button ContinueFullScreenButton { get; set; }

        private void OnEnable()
        {
            AttachToEvents();
        }

        private void OnDisable()
        {
            DetachFromEvents();
        }
        private void ShowMainMenuScreen ()
        {
            CachedMainMenuScreenManager.ShowMainMenuScreen();
        }

        private void HandleOnContinueFullScreenButtonClicked()
        {
            ShowMainMenuScreen();
        }

        private void AttachToEvents()
        {
            ContinueFullScreenButton.onClick.AddListener(HandleOnContinueFullScreenButtonClicked);
        }

        private void DetachFromEvents()
        {
            ContinueFullScreenButton.onClick.RemoveListener(HandleOnContinueFullScreenButtonClicked);
        }
    }
}
