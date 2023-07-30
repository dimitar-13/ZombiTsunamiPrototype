using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner 
{

    public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate);
}
