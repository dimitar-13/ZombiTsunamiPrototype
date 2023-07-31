using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour,ISpawner
{
    [SerializeField]
    private GameObject bomb;
    public float ObjectLenght
    {
        get
        {
            return objectLenght;
        }
        set
        {
            objectLenght = value;
        }
    }
    private float objectLenght;
    public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate)
    {
       return Instantiate(bomb, new Vector3(xCordinate, groundTopCordinates),Quaternion.identity);
    }

}
