using System.Collections.Generic;
using UnityEngine;

namespace ZombieTsunami.UI
{
    public class NumberToSpriteConverter
    {
        //TODO:Get sprites from resource folder
        private Sprite[] numberSprites;
        private Color[] spriteSheetPixels;

        public NumberToSpriteConverter(Sprite[] numberSprites)
        {
            this.numberSprites = numberSprites;
            spriteSheetPixels = numberSprites[0].texture.GetPixels();
        }
        public Sprite TransformNumbersIntoSprites(int number)
        {
            if (number > 9)
            {
                int[] individualDigits = ReturnIndividualDigits(number);

                int totalWidth = 0;
                Sprite[] sprites = new Sprite[individualDigits.Length];
                int itterator = 0;
                foreach (var digit in individualDigits)
                {
                    totalWidth += (int)numberSprites[digit].rect.width;
                    sprites[itterator] = numberSprites[digit];
                    itterator++;
                }
                var texture = CombineSpritesInOneTexture(sprites, totalWidth);

                Sprite combinedSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one / 2);
                return combinedSprite;
            }
            else
            {
                return numberSprites[number];
            }
        }

        private void SetAllPixelsTransparent(Texture2D texture)
        {
            Color transparentColor = new Color(0, 0, 0, 0);

            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < 105; y++)
                {
                    texture.SetPixel(x, y, transparentColor);
                }
            }
        }

        private int[] ReturnIndividualDigits(int number)
        {
            Stack<int> individualNums = new Stack<int>();

            while (number > 9)
            {
                int floatingNum = number % 10;
                number /= 10;
                individualNums.Push(floatingNum);
            }
            individualNums.Push(number);
            return individualNums.ToArray();
        }
        private Texture2D CombineSpritesInOneTexture(Sprite[] spritesToCombine, int totalWidth)
        {
            int startX = 0;
            int newTextureXItterator = 0;
            int newTextureYItterator = 0;
            var newTexture = new Texture2D(totalWidth, 105);
            //If any pixels are unsigned they get gray be converting each pixel with alpha value of 0 we can avoid that
            SetAllPixelsTransparent(newTexture);

            foreach (var sprite in spritesToCombine)
            {
                for (int x = (int)sprite.rect.xMin; x < (int)sprite.rect.xMax; x++)
                {
                    newTextureXItterator++;
                    for (int y = (int)sprite.rect.yMin; y < (int)sprite.rect.yMax; y++)
                    {
                        newTexture.SetPixel(startX + newTextureXItterator, newTextureYItterator, spriteSheetPixels[y * sprite.texture.width + x]);

                        newTextureYItterator++;
                    }
                    newTextureYItterator = 0;
                }
                newTextureYItterator = 0;
                newTextureXItterator = 0;

                startX += (int)sprite.rect.width;
            }
            newTexture.Apply();
            return newTexture;
        }
    }
}
