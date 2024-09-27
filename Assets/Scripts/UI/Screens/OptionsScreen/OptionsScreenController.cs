using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.OptionsScreen
{
    public class OptionsScreenController : BaseMainMenuScreenController
    {
        [field: SerializeField]
        private Button BackButton { get; set; }

        private void OnEnable()
        {
            AttachToEvents();
        }

        private void OnDisable()
        {
            DetachFromEvents();
        }

        private void ShowMainMenuScreen()
        {
            CachedMainMenuScreenManager.ShowMainMenuScreen();
        }

        private void HandleOnBackButtonClicked()
        {
            ShowMainMenuScreen();
        }

        private void AttachToEvents()
        {
            BackButton.onClick.AddListener(HandleOnBackButtonClicked);
        }

        private void DetachFromEvents()
        {
            BackButton.onClick.RemoveListener(HandleOnBackButtonClicked);
        }
    }
}
