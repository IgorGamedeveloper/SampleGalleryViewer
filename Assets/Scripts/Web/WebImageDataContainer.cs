using UnityEngine;

namespace IMG.WebImages
{
    public class WebImageDataContainer : MonoBehaviour
    {
        public WebImageData Data { get; private set; }





        public void SetData(WebImageData data)
        {
            Data = data;
        }

        public void SetViewWebImage()
        {
            if (Data != null)
            {
                WebImageViewerContainer.SetData(Data);
            }
            else
            {
                Debug.LogError("Отсутствуют данные для представления!");
                WebImageViewerContainer.SetData(WebImageData.Default);
            }
        }
    }
}
