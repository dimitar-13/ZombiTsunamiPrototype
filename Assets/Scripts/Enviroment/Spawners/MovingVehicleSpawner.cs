using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZombieTsunami.Enviroment;

namespace Assets.Scripts.Enviroment
{
    public class MovingVehicleSpawner : MonoBehaviour, ISpawner
    {
        private float objectLenght;

        public float ObjectLenght
        {
            get { return objectLenght; }
            set { objectLenght = value; }
        }

        [SerializeField]
        private GameObject vehicle;


        public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate)
        {
            groundTopCordinates += vehicle.transform.localScale.y / 2;
            var instance = Instantiate(vehicle, new Vector3(xCordinate, groundTopCordinates,1),Quaternion.identity);
            objectLenght = 1f;
            return vehicle;
        }
    }
}
