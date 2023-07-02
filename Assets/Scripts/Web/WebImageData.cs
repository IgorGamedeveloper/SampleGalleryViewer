using UnityEngine;

namespace IMG.WebImages
{
    public class WebImageData
    {
        public Texture2D ImageTexture { get; private set; }

        public string ImageURL { get; private set; }

        public static WebImageData Default { get; private set; } = new WebImageData(Resources.Load("NotDownloaded") as Texture2D, "");


        public WebImageData(Texture2D texture, string url)
        {
            SetTecture(texture);
            SetImageURL(url);
        }

        public void SetTecture(Texture2D texture)
        {
            ImageTexture = texture;
        }

        public void SetImageURL(string url)
        {
            ImageURL = url;
        }

        public void SetData(Texture2D texture, string url)
        {
            SetTecture(texture);
            SetImageURL(url);
        }
    }
}
