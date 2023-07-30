using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoinHelperClass 
{
    private static int lastShape;

    public static void AssembleCoinRadomShape(float groundTopCordinates, float xCordinate, Coin[] coins )
    {

        switch(coins.Length)
        {
            case 15:
                CoinShapeGenerator.Triangle(groundTopCordinates, xCordinate, coins);
                break;
            case 45:
                Debug.Log("Asume there are 3 triangles here");
                break;
            case 40:
                Debug.Log("Asume there square here");

                break;
            case 4:

                break;
        }


       
    }


    public static int GetCoinAmoutForCurrentShape()
    {
        int RandomShape = Random.Range(0, 6);
        int CoinToSpawnCount = 0;

        if (lastShape == RandomShape)
        {
            RandomShape = Random.Range(0, 6);
        }

        switch (RandomShape)
        {
            case 1:
                //Spawn triangle
                CoinToSpawnCount = 15;
                break;
            case 2:
                //Spawn 3 triangles
                CoinToSpawnCount = 45;
                break;
            case 3:
                //Spawn squares
                CoinToSpawnCount = 40;
                break;
        }

        lastShape = RandomShape;
        return CoinToSpawnCount;
    }

}
