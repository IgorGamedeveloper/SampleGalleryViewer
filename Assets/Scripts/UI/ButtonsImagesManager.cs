using IMG.WebImages;
using UnityEngine;
using UnityEngine.UI;

namespace IMG.UI
{
    public class ButtonsImagesManager : MonoBehaviour
    {
        public static ButtonsImagesManager Instance;


        [SerializeField] private Image[] _images;
        public Image[] Images { get { return _images; } }




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

        public void SetDataForButtonWithIndex(int index, WebImageData data)
        {
            _images[index].GetComponentInParent<WebImageDataContainer>().SetData(data);
            _images[index].sprite = Sprite.Create(data.ImageTexture, new Rect(0, 0, data.ImageTexture.width, data.ImageTexture.height), Vector2.zero);
        }
    }
}
