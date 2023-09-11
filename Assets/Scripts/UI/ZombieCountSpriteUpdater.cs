using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ZombieTsunami.UI
{

    public class ZombieCountSpriteUpdater : MonoBehaviour
    {
        [SerializeField]
        private Sprite [] numberSprites;
        [SerializeField]
        private UiManager uiManager;
        [SerializeField]
        private GameObject spriteToUpdate;
        private  Color[] spriteSheetPixels;

        private void Start()
        {
            Events.OnHumanEaten += TransformNumbersIntoSprites;
            spriteSheetPixels = numberSprites[0].texture.GetPixels();
        }

        private void TransformNumbersIntoSprites()
        {
            //int number = 2;
            uiManager.ZombiCount = 20;
            if (uiManager.ZombiCount > 9)
            {

                int[] individualDigits = ReturnIndividualDigits(uiManager.ZombiCount);

                int totalWidth = 0;
                Sprite[] sprites = new Sprite[individualDigits.Length];
                int itterator = 0;
                foreach (var digit in individualDigits)
                {
                    totalWidth += (int)numberSprites[digit].rect.width;
                    sprites[itterator] = numberSprites[digit];
                    itterator++;
                }

                // Copy the pixels of the digit sprite into the combined texture

                var texture = CombineSpritesInOneTexture(sprites, totalWidth);

                // Create a new sprite using the combined texture
                Sprite combinedSprite = Sprite.Create(texture, new Rect(0, 0, totalWidth, 105), Vector2.zero);

                // Set the combined sprite to the GameObject's SpriteRenderer component
                spriteToUpdate.GetComponent<SpriteRenderer>().sprite = combinedSprite;
            }
            else
            {
                spriteToUpdate.gameObject.GetComponent<SpriteRenderer>().sprite = numberSprites[uiManager.ZombiCount];
            }
        }

        private void SetAllPixelsTransparent(Texture2D texture)
        {
            Color transparentColor = new Color(0, 0, 0, 0); // Fully transparent color

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
                int floatingNum = number %10;
                Debug.Log(floatingNum);
              //  Math.DivRem(number,10, out floatingNum);
                number /= 10;
                individualNums.Push(floatingNum);          
            }
            individualNums.Push(number);
            return individualNums.ToArray();
        }


        private Texture2D CombineSpritesInOneTexture(Sprite[] spritesToCombine,int totalWidth)
        {
            int startX = 0;
            int newTextureXItterator = 0;
            int newTextureYItterator = 0;
            var newTexture = new Texture2D(totalWidth, 105);
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
