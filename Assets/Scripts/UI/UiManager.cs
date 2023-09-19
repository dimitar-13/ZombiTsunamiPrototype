using Assets.Scripts.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace ZombieTsunami.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] spriteNums;

        [SerializeField]
        public int ZombiCount = 1;
        [SerializeField]
        private SpriteRenderer ZombiCountSprite;
        [SerializeField]
        public int CollectedCoins = 0;
        [SerializeField]
        private SpriteRenderer CollectedCoinsSprite;
        [SerializeField]
        public int CollectedBrains = 0;
        [SerializeField]
        private SpriteRenderer CollectedBrainsSprite;

        private NumberToSpriteConverter helper;
        

        private void Awake()
        {
            helper = new NumberToSpriteConverter(spriteNums);

            Events.OnHumanEaten += () =>
            {
                CollectedBrains++;
                CollectedBrainsSprite.sprite = helper.TransformNumbersIntoSprites(CollectedBrains);
            };
            Events.OnHumanEaten += () =>
            {
                ZombiCount++;
                ZombiCountSprite.sprite = helper.TransformNumbersIntoSprites(ZombiCount);
            };
            Events.OnCoinPickup += (GameObject) =>
            {
                CollectedCoins++;
                CollectedCoinsSprite.sprite = helper.TransformNumbersIntoSprites(CollectedCoins);
            };

        }
    }
}
