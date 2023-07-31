using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieTsunami.Enviroment
{
    public interface ISpawner
    {
        float ObjectLenght { get; set; }
        public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate);
    }
}
