using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;


namespace ZombieTsunami.UI
{
    public class UiManager : MonoBehaviour
    {

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
            };
            Events.OnHumanEaten += () =>
            {
                ZombiCount++;
            };
            Events.OnCoinPickup += (GameObject) =>
            {
                CollectedCoins++;
            };

        }
    }
}
