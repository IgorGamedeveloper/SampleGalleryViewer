using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace IMG.SceneManagement
{
    public class LoadingBarManager : MonoBehaviour  //  МЕНЕДЖЕР УПРАВЛЕНИЯ ПОЛОСОЙ ЗАГРУЗКИ И ПРОЦЕНТНЫМ УКАЗАТЕЛЕМ ПРОЦЕССА ЗАГРУЗКИ СЦЕНЫ
    {
        public static LoadingBarManager Instance { get; private set; }

        public const float LOADING_PERCENT_MULTIPLIER = 100.0f;

        [Header("Текстовое поле статуса загрузки:")]
        [SerializeField] private TMP_Text _loadingProgressTextField;

        [Space(10f)]
        [Header("Заполняемое изображение статуса загрузки:")]
        [SerializeField] private Image _filledImage;

        private string _loadingText;



        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        //__________________________________________________________________    ОБНОВЛЕНИЕ СТАТУСА КОМПОНЕНТОВ ПОЛОСЫ ЗАГРУЗКИ:

        public void UpdateLoadingStatus(float loadingProgress)
        {
            _loadingText = $"Загрузка... {loadingProgress * LOADING_PERCENT_MULTIPLIER}%";

            if (_loadingProgressTextField != null)
            {
                _loadingProgressTextField.text = _loadingText;
            }

            if (_filledImage != null)
            {
                _filledImage.fillAmount = loadingProgress;
            }
        }
    }
}
