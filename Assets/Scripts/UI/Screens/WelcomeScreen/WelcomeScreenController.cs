using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI.Screens.WelcomeScreen
{
    public class WelcomeScreenController : BaseMainMenuScreenController
    {
        [field: SerializeField]
        private Button ContinueFullScreenButton { get; set; }

        private InputActions CurrentInputActions { get; set; }

        private void Awake()
        {
            CurrentInputActions = new InputActions();
        }

        private void OnEnable()
        {
            CurrentInputActions.Enable();
            AttachToEvents();
        }

        private void OnDisable()
        {
            CurrentInputActions.Disable();
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

        private void HandleOnPressAnyButtonPerformed(InputAction.CallbackContext callback)
        {
            ShowMainMenuScreen();
        }

        private void AttachToEvents()
        {
            ContinueFullScreenButton.onClick.AddListener(HandleOnContinueFullScreenButtonClicked);
            CurrentInputActions.UI.PressAnyButton.performed += HandleOnPressAnyButtonPerformed;
        }

        private void DetachFromEvents()
        {
            ContinueFullScreenButton.onClick.RemoveListener(HandleOnContinueFullScreenButtonClicked);
            CurrentInputActions.UI.PressAnyButton.performed -= HandleOnPressAnyButtonPerformed;
        }
    }
}
