using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Core;


namespace ZombieTsunami.Enviroment
{
    public class CoinSpawner : MonoBehaviour, ISpawner
    {

        [SerializeField]
        private GameObject coin;
        [SerializeField]
        private GameObject coinBlock;


        private float objectLenght;

        public float ObjectLenght
        {
            get { return objectLenght; }
            set { objectLenght = value; }
        }



        public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate)
        {
            int lenght = CoinHelperClass.GetCoinAmoutForCurrentShape();

            var offset = groundTopCordinates + 3f;


            CoinBlock CoinBlock = Instantiate(coinBlock, new Vector2(xCordinate, offset), Quaternion.identity).GetComponent<CoinBlock>();

            List<GameObject> coins = new List<GameObject>();
            for (int i = 0; i < 15; i++)
            {
                coins.Add(Instantiate(coin, CoinBlock.transform));
            }


            CoinHelperClass.AssembleCoinRadomShape(groundTopCordinates, xCordinate, coins.ToArray());
            objectLenght = CoinHelperClass.GetCoinLenght(coins.ToArray());

            return CoinBlock.gameObject;
        }


        public void Triangle(float groundTopCordinates, float xCordinate)
        {
            var offset = groundTopCordinates + 2f;
            List<Coin> coins = new List<Coin>();
            CoinBlock CoinBlock = Instantiate(coinBlock, new Vector2(xCordinate, offset), Quaternion.identity).GetComponent<CoinBlock>();

            for (int i = 5; i > 0; i--)
            {
                for (int y = 0; y < i; y++)
                {
                    coins.Add(Instantiate(coin, new Vector2(xCordinate + (y * 2), offset), Quaternion.identity, CoinBlock.transform).GetComponent<Coin>());
                }
                offset += 1f;
            }
            CoinBlock.CoinList.AddRange(coins);
        }
        public void UpsideDownTriangle(float groundTopCordinates, float xCordinate)
        {
            var offset = groundTopCordinates + 2f;
            List<Coin> coins = new List<Coin>();
            CoinBlock CoinBlock = Instantiate(coinBlock, new Vector2(xCordinate, offset), Quaternion.identity).GetComponent<CoinBlock>();

            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < i + 1; y++)
                {
                    coins.Add(Instantiate(coin, new Vector2(xCordinate + (y * 3), offset), Quaternion.identity, CoinBlock.transform).GetComponent<Coin>());
                }
                offset += 1f;
            }
            CoinBlock.CoinList.AddRange(coins);
        }
        public void SmallSquare(float groundTopCordinates, float xCordinate)
        {
            var offset = groundTopCordinates + 2f;
            List<Coin> coins = new List<Coin>();
            CoinBlock CoinBlock = Instantiate(coinBlock, new Vector2(xCordinate, offset), Quaternion.identity).GetComponent<CoinBlock>();

            for (int i = 0; i < 6; i++)
            {
                for (int y = 0; y < 2; y++)
                {
                    coins.Add(Instantiate(coin, new Vector2(xCordinate + y, offset), Quaternion.identity, CoinBlock.transform).GetComponent<Coin>());
                }
                offset += 1f;
            }
            CoinBlock.CoinList.AddRange(coins);
        }

    }
}
