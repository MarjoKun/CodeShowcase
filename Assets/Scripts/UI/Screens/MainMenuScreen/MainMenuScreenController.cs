using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.MainMenuScreen
{
    public class MainMenuScreenController : BaseMainMenuScreenController
    {
        [field: SerializeField]
        private Button StartButton { get; set; }
        [field: SerializeField] 
        private Button OptionsButton { get; set; }
        [field: SerializeField]
        private Button ExitButton { get; set; }

        private void OnEnable()
        {
            AttachToEvents();
        }

        private void OnDisable()
        {
            DetachFromEvents();   
        }

        //TODO: Implement GameConfigurationScreen
        private void ShowGameConfigurationScreen()
        {
            //CachedMainMenuScreenManager.ShowGameConfigurationScreen();
        }

        //TODO: Implement OptionsScreen
        private void ShowOptionsScreen()
        {
            //CachedMainMenuScreenManager.ShowOptionsScreen();
        }

        private void ShowExitPopup()
        {

        }

        private void HandleOnStartButtonClicked()
        {
            ShowGameConfigurationScreen();
        }

        private void HandleOnOptionsButtonClicked()
        {
            ShowOptionsScreen();
        }

        private void HandleOnExitButtonClicked()
        {
            ShowExitPopup();
        }

        private void AttachToEvents()
        {
            StartButton.onClick.AddListener(HandleOnStartButtonClicked);
            OptionsButton.onClick.AddListener(HandleOnOptionsButtonClicked);
            ExitButton.onClick.AddListener(HandleOnExitButtonClicked);
        }

        private void DetachFromEvents()
        {
            StartButton.onClick.RemoveListener(HandleOnStartButtonClicked);
            OptionsButton.onClick.RemoveListener(HandleOnOptionsButtonClicked);
            ExitButton.onClick.RemoveListener(HandleOnExitButtonClicked);
        }
    }
}
