using UnityEngine;
using UnityEngine.UI;
using ZombieTsunami.Core;

namespace ZombieTsunami.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private Text zombieCount;
        [SerializeField]
        private Text coinCount;
        [SerializeField]
        private Text brainCount;

        [SerializeField]
        public int ZombiCount = 1;
        [SerializeField]
        public int CollectedCoins = 0;
        [SerializeField]
        public int CollectedBrains = 0;

        private void Awake()
        {
            Events.OnHumanEaten += () =>
            {
                CollectedBrains++;
                brainCount.text = "BrainCount:" + CollectedBrains.ToString();
            };
            Events.OnHumanEaten += () =>
            {
                ZombiCount++;
                zombieCount.text = "ZombieCount:" + ZombiCount.ToString();
            };
            Events.OnCoinPickup += (GameObject) =>
            {
                CollectedCoins++;
                coinCount.text = "CoinsCollected:" + CollectedCoins.ToString();
            };

            brainCount.text = "BrainCount:" + CollectedBrains.ToString();
            zombieCount.text = "ZombieCount:" + ZombiCount.ToString();
            coinCount.text = "CoinsCollected:" + CollectedCoins.ToString();

        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}
