using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core;

namespace ZombieTsunami.Enviroment
{
    public class CoinBlock : MonoBehaviour
    {
        [SerializeField]
        private List<Coin> coinList;

        public List<Coin> CoinList
        {
            get { return coinList; }
            set { coinList = value; }
        }



        private void Awake()
        {
            Events.OnCoinPickup += (Coin coinToRemove) => { coinList.Remove(coinToRemove); };
        }


        private void Update()
        {
            if (coinList.Count <= 0)
            {
                //  Debug.Log("Nice");
            }
        }
    }
}
