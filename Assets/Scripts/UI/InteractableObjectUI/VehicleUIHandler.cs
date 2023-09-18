using Assets.Scripts.Core;
using UnityEditor;
using UnityEngine;

namespace ZombieTsunami.UI
{
    public class VehicleUIHandler : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] numberSprites;
        [SerializeField]
        private SpriteRenderer amountToBreak_Sprite;
        [SerializeField]
        private VehicleUICommunication communication;

        private NumberToSpriteConverter helper;

        // Start is called before the first frame update
        void Start()
        {
            helper = new NumberToSpriteConverter(numberSprites);
            communication.OnCurrentZombieNumberChanged += OnCurrentAmountChanged;
        }

        void OnCurrentAmountChanged(int newAmount)
        {
            amountToBreak_Sprite.sprite = helper.TransformNumbersIntoSprites(newAmount);
        }
    }
}
