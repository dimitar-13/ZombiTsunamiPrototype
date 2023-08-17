
using Assets.Scripts.Core;
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

            //Check if the player is on the current ground
            //Launch after some kind of alarm
            var instance = Instantiate(vehicle, new Vector3(Constants.OFSCREEN_POSSITION, groundTopCordinates, 1), Quaternion.identity);
            objectLenght = 1f;
            return instance;
        }
    }
}
