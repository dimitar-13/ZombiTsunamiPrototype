using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZombieTsunami.Enviroment;

namespace Assets.Scripts.Enviroment.Spawners
{
    public class PowerBoxSpawner : MonoBehaviour, ISpawner
    {
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

        [SerializeField]
        private GameObject boxPrefab;


        public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate)
        {
            float Yoffset = (SpawnerHelper.GetExtentsOfObj(boxPrefab)*-1) + groundTopCordinates + 3f;
            return Instantiate(boxPrefab,new Vector2(xCordinate, Yoffset),Quaternion.identity);
        }
    }
}
