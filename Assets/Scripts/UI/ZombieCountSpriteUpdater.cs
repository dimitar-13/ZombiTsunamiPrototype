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

        private void Start()
        {
            Events.OnHumanEaten += TransformNumbersIntoSprites;
        }
        private void TransformNumbersIntoSprites()
        {
            int number = uiManager.ZombiCount;
           if(number >9)
            {
                string tempNum = number.ToString();
                var newTexture = new Texture2D(100 * tempNum.Length, 100);
                for (int i = 0; i < newTexture.width; i++)
                {
                    for (int y = 0; y < newTexture.height; y++)
                    {
                        newTexture.SetPixel(i,y,new Color(0,0,0,0));
                    }
                }

                Sprite[] spritesToMerge = new Sprite[tempNum.Length];
                int iterator = 0;
                foreach (var n in tempNum)
                {
                    int num = Int32.Parse(n.ToString());
                    spritesToMerge[iterator] = numberSprites[num];
                    iterator++;
                }
            }
            else
            {
                spriteToUpdate.gameObject.GetComponent<SpriteRenderer>().sprite = numberSprites[number];
            }
        }

    }
}
