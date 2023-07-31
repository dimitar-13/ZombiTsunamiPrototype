using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoinShapeGenerator 
{
  public static void Triangle(float groundTopCordinates, float xCordinate, GameObject[] coins)
    {
        int coiniD = 0;

        for (int i = 5; i > 0; i--)
        {
            for (int y = 0; y < i; y++)
            {
                coins[coiniD].gameObject.transform.position = new Vector2(xCordinate + y , groundTopCordinates);
                coiniD++;
            }
            groundTopCordinates += 1f;
        }
    }

    public static void UpsideDownTriangle(float groundTopCordinates, float xCordinate, GameObject[] coins)
    {
        var offset = groundTopCordinates + 2f;
        int coiniD = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int y = 0; y < i + 1; y++)
            {
                coins[coiniD].gameObject.transform.position = new Vector2(xCordinate + y , offset);
                coiniD++;
            }
            offset += 1f;
        }
    }
    public static void SmallSquare(float groundTopCordinates, float xCordinate, GameObject[] coins,int lenght)
    {
        var offset = groundTopCordinates + 2f;
        int coiniD = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int y = 0; y < lenght; y++)
            {
                coins[coiniD].gameObject.transform.position = new Vector2(xCordinate + y, offset);
                coiniD++;
            }
            offset += 1f;
        }
    }
    public static void Circle(float groundTopCordinates, float xCordinate, GameObject[] coins)
    {
        int coiniD = 0;
        float radius = groundTopCordinates +  3f;

        Mathf.Cos(radius);
        Mathf.Sign(radius);

    }


}
