using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Screens
{
    public abstract class ScreenManager<T, U> : MonoBehaviour where T : Enum where U : class
    {
        public event Action OnScreenShown = delegate { };
        public event Action OnAllScreensHidden = delegate { };

        [field: SerializeField]
        public List<ScreenData> ScreenDataCollection { get; private set; } = new();
        [field: Space, SerializeField]
        private RectTransform ScreensContainer { get; set; }

        [field: Space, Header("Settings")]
        [field: SerializeField]
        private bool ShowFirstScreen { get; set; } = true;
        [field: SerializeField]
        private T FirstScreenToShow { get; set; }

        public void HideAllScreens(bool notifyOnHide = true)
        {
            for (int i = 0; i < ScreenDataCollection.Count; i++)
            {
                SetScreenActiveState(ScreenDataCollection[i].InstantiatedScreen, false);
            }

            if (notifyOnHide == true)
            {
                OnAllScreensHidden.Invoke();
            }
        }

        public void ShowScreenByScreenType(T screenType)
        {
            ActiveScreen(GetScreenByScreenType(screenType));
        }

        private void Awake()
        {
            AttemptToShowFirstScreen();
        }

        private void ActiveScreen(ScreenData screenDataToActivate)
        {
            HideAllScreens(false);

            if (screenDataToActivate.InstantiatedScreen == null)
            {
                InstantiateScreen(screenDataToActivate);
            }
            else
            {
                SetScreenActiveState(screenDataToActivate.InstantiatedScreen, true);
            }

            OnScreenShown.Invoke();
        }

        private ScreenData GetScreenByScreenType(T screenType)
        {
            for (int i = 0; i < ScreenDataCollection.Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(ScreenDataCollection[i].BoundScreenType, screenType) == true)
                {
                    return ScreenDataCollection[i];
                }
            }

            return null;
        }

        private void SetScreenActiveState(RectTransform screenRect, bool setActive)
        {
            if (screenRect != null)
            {
                screenRect.gameObject.SetActive(setActive);
            }
        }

        private void AttemptToShowFirstScreen()
        {
            if (ShowFirstScreen == true)
            {
                ActiveScreen(GetScreenByScreenType(FirstScreenToShow));
            }
        }

        private void InstantiateScreen(ScreenData screenData)
        {
            screenData.InstantiatedScreen = Instantiate(screenData.ScreenPrefab, ScreensContainer);
            screenData.CachedIScreen = screenData.InstantiatedScreen.GetComponent<IScreen<U>>();
            InitializeManager(screenData.CachedIScreen);
        }

        private void InitializeManager(IScreen<U> iScreen)
        {
            iScreen.InitializeManager(this as U);
        }

        [Serializable]
        public class ScreenData
        {
            [field: SerializeField]
            public T BoundScreenType { get; private set; }
            [field: SerializeField]
            public RectTransform ScreenPrefab { get; private set; }

            public RectTransform InstantiatedScreen { get; set; }
            public IScreen<U> CachedIScreen { get; set; }
        }
    }
}
