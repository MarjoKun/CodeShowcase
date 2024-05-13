using UnityEngine;

namespace UI.Screens
{
    public class BaseMainMenuScreenController : MonoBehaviour, IScreen<MainMenuScreenManager>
    {
        public MainMenuScreenManager CachedMainMenuScreenManager { get; set; }

        public void InitializeManager(MainMenuScreenManager manager)
        {
            CachedMainMenuScreenManager = manager;
        }
    }
}
