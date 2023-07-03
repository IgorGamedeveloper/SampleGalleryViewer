using UnityEngine;

namespace IMG.WebImages
{
    public static class WebImageViewerContainer //  ’–¿Õ»À»Ÿ≈ »«Œ¡–¿∆≈Õ»ﬂ ƒÀﬂ œ–≈ƒ—“¿¬À≈Õ»ﬂ
    {
        public static WebImageData ViewWebImage { get; private set; }

        public static Sprite ViewSprite { get; private set; }




        public static void SetData(WebImageData data)
        {
            ViewWebImage = data;
            ViewSprite = Sprite.Create(ViewWebImage.ImageTexture, new Rect(0, 0, ViewWebImage.ImageTexture.width, ViewWebImage.ImageTexture.height), Vector2.zero);
        }
    }
}
