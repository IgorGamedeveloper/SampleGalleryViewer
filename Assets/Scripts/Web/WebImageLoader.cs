using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using IMG.UI;

namespace IMG.WebImages
{
    public class WebImageLoader : MonoBehaviour
    {
        private UnityWebRequest _request;

        private IEnumerator LoadingImages;



        [Header("Адрес для загрузки изображений:")]
        [SerializeField] private string _imageServerURL = "http://data.ikppbb.com/test-task-unity-data/pics/";

        private int _currentImageNumber;
        private int _currentImageIndex;

        private string _imageFormat = ".jpg";

        private string _currentImageURL;

        private Texture2D _currentTexture;


        [Space(10f)]
        [Header("Количество загружаемых изображений:")]
        [SerializeField] private int _loadImageAmount = 66;


        [Space(25f)]
        [Header("Начинать загрузку ресурсов при старте:")]
        [SerializeField] private bool _loadingInStart = false;

        public WebImageData[] WebImagesData { get; private set; }




        private void Start()
        {
            if (_loadingInStart == true)
            {
                StartLoadingImages();
            }
        }

        public void StartLoadingImages()
        {
            if (LoadingImages != null)
            {
                StopCoroutine(LoadingImages);
                LoadingImages = null;
            }

            LoadingImages = LoadImages();

            StartCoroutine(LoadingImages);
        }


        private IEnumerator LoadImages()
        {
            _currentImageNumber = 1;
            _currentImageIndex = _currentImageNumber - 1;


            WebImagesData = new WebImageData[_loadImageAmount];

            while (_currentImageIndex < _loadImageAmount)
            {
                _currentImageURL = $"{_imageServerURL}{_currentImageNumber}{_imageFormat}";

                _request = UnityWebRequestTexture.GetTexture(_currentImageURL);

                yield return _request.SendWebRequest();

                if (_request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Произошла ошибка при загузке изображения! {_request.error};");
                }
                else
                {
                    _currentTexture = ((DownloadHandlerTexture)_request.downloadHandler).texture;
                    Debug.Log(_currentTexture.name);

                    WebImagesData[_currentImageIndex] = new WebImageData(_currentTexture, _currentImageURL);

                    ButtonsImagesManager.Instance.SetDataForButtonWithIndex(_currentImageIndex, WebImagesData[_currentImageIndex]);
                }

                yield return null;

                _currentImageNumber++;
                _currentImageIndex++;
            }
        }
    }
}
