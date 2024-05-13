namespace UI.Screens
{
   public class MainMenuScreenManager : ScreenManager<MainMenuScreenManager.ScreenType, MainMenuScreenManager>
   {
      public void ShowWelcomeScreen ()
      {
         ShowScreenByScreenType(ScreenType.WELCOME_SCREEN);
      }

      public void ShowMainMenuScreen ()
      {
         ShowScreenByScreenType(ScreenType.MAIN_MENU);
      }

      public void ShowOptionsScreen ()
      {
         ShowScreenByScreenType(ScreenType.OPTIONS);
      }

      public void ShowGameConfigurationScreen ()
      {
         ShowScreenByScreenType(ScreenType.GAME_CONFIGURATION);
      }

      public enum ScreenType
      {
         WELCOME_SCREEN,
         MAIN_MENU,
         OPTIONS,
         GAME_CONFIGURATION
      }
   }
}