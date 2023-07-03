using UnityEngine;

namespace IMG.WebImages
{
    public class WebImageDataContainer : MonoBehaviour  //  ÕĞÀÍÈËÈÙÅ ÄÀÍÍÛÕ ÂÛÃĞÓÆÅÍÍÎÃÎ ÈÇÎÁĞÀÆÅÍÈß ÄËß ÏĞÅÄÑÒÀÂËÅÍÈß
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
                Debug.LogError("Îòñóòñòâóşò äàííûå äëÿ ïğåäñòàâëåíèÿ!");
                WebImageViewerContainer.SetData(WebImageData.Default);
            }
        }
    }
}
