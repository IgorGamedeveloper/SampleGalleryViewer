using UnityEngine;
using UnityEngine.UI;

namespace IMG.WebImages
{
    public class WebImageViewer : MonoBehaviour
    {
        [SerializeField] private Image _viewImage;



        private void Start()
        {
            ViewSprite();
        }

        public void ViewSprite()
        {
            _viewImage.sprite = WebImageViewerContainer.ViewSprite;
        }
    }
}
