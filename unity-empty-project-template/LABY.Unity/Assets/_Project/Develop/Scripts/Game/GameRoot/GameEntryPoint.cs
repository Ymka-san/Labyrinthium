using System.Collections;
using _Project.Develop.Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Develop.Scripts.Game.GameRoot
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private Coroutines _coroutines;
        private UIRootView _uiRoot;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
          
            Application.targetFrameRate = 120;
            
            
            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint()
        {
            
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);
            
            var prefabUiRoot = Resources.Load<UIRootView>("UIRoot");
            _uiRoot = Object.Instantiate(prefabUiRoot);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);
        }

        private void RunGame()
        {
            
/*#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == NameScenes.META)
            {
                _coroutines.StartCoroutine(LoadAndStartGameplay());
                return;
            }

           
#endif*/

            _coroutines.StartCoroutine(LoadAndStartGameplay());
        }

        private IEnumerator LoadAndStartGameplay()
        {
          _uiRoot.ShowLoadingScreen();
          
          yield return LoadScene(NameScenes.BOOTSTRAP);
          yield return LoadScene(NameScenes.CORE);

          yield return new WaitForSeconds(2);


         
          
          
            _uiRoot.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}