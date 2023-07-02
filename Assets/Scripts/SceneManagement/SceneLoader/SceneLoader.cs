using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IMG.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        private AsyncOperation _asyncOperation;

        private IEnumerator LoadSceneAsyncCoroutine;

        [Header("Задержка после загрузки, перед переходом на следующую сцену:")]
        [SerializeField] private float _loadingSceneDelay = 0.2f;

        [Space(15f)]
        [Header("Начать загрузку следующей сцены при старте:")]
        [SerializeField] private bool _loadSceneInStart = false;

        [Space(20f)]
        [Header("Название следующей сцены:")]
        [SerializeField] private string _nextSceneName = "MainScene";

        [Space(10f)]
        [Header("Название предидущей сцены:")]
        [Tooltip("Название для перехода на сцену при нажатии 'Escape' и андроид ввода системными кнопками. Если ввести 'Exit' произойдет выход из приложения")]
        [SerializeField] private string _previousSceneName = _applicationQuitPreviousSceneNameCommand;

        private static string _applicationQuitPreviousSceneNameCommand = "Exit";

        private string _loadSceneName = "LoadScene";
        private string _currentSceneName;

        private bool _loadingStarted = false;





        private void Start() 
        {
            if (_loadSceneInStart == true)
            {
                StartLoadNextScene();
            }
        }

        //  ____________________________________________________________    ЗАПУСК ПРОЦЕССА ЗАГРУЗКИ СЛЕДУЮЩЕЙ СЦЕНЫ:

        public void StartLoadNextScene()   
        {
            StartLoadScene(_nextSceneName);
        }

        public void StartLoadPreviousScene()
        {
            StartLoadScene(_previousSceneName);
        }

        private void StartLoadScene(string sceneName)
        {
            if (_loadingStarted == false)
            {
                _loadingStarted = true;

                if (LoadSceneAsyncCoroutine != null)
                {
                    StopCoroutine(LoadSceneAsyncCoroutine);
                    LoadSceneAsyncCoroutine = null;
                }

                LoadSceneAsyncCoroutine = LoadSceneAsync(sceneName);
                StartCoroutine(LoadSceneAsyncCoroutine);
            }
        }

        private IEnumerator LoadSceneAsync(string nextScene)
        {
            //  ____________________________________________________________    ПРОВЕРКА ВОЗМОЖНОСТИ ПЕРЕХОДА НА СЛЕДУЮЩУЮ СЦЕНУ:

            if (nextScene == _applicationQuitPreviousSceneNameCommand)
            {
                Application.Quit();
            }

            _currentSceneName = SceneManager.GetActiveScene().name;

            Scene nextSceneChecker = SceneManager.GetSceneByName(nextScene);

            if (nextSceneChecker == null)
            {
                Debug.LogError("Отсутствует сцена для загрузки!");
                yield break;
            }

            //  ____________________________________________________________    ЗАГРУЗКА ПРОМЕЖУТОЧНОЙ ЗАГРУЗОЧНОЙ СЦЕНЫ:

            _asyncOperation = SceneManager.LoadSceneAsync(_loadSceneName, LoadSceneMode.Additive);

            while (_asyncOperation.isDone != true)
            {
                yield return null;
            }

            //  ____________________________________________________________    ЗАГРУЗКА КОНЕЧНОЙ СЦЕНЫ:

            _asyncOperation = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
            _asyncOperation.allowSceneActivation = false;

            bool loaded = _asyncOperation.isDone;

            while (loaded != true)
            {
                if (_asyncOperation.progress < 0.9f)
                {
                    if (LoadingBarManager.Instance != null)
                    {
                        LoadingBarManager.Instance.UpdateLoadingStatus(_asyncOperation.progress);
                    }

                    yield return null;
                }
                else
                {
                    if (LoadingBarManager.Instance != null)
                    {
                        LoadingBarManager.Instance.UpdateLoadingStatus(1f);
                    }

                    loaded = true;
                }
            }

            yield return new WaitForSeconds(_loadingSceneDelay);

            _asyncOperation.allowSceneActivation = true;

        }
    }
}
