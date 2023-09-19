using UnityEngine;

namespace ZombieTsunami.Enviroment
{
    public class CarSpanwer : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private GameObject[] carAssets;
        public GameObject[] assets
        {
            get { return carAssets; }
            set { carAssets = value; }
        }
        private float objectLenght;

        public float ObjectLenght
        {
            get { return objectLenght; }
            set { objectLenght = value; }
        }



        public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate)
        {
            var assetToSpawn = SpawnerHelper.GetRandomAssetToSpawn(carAssets);
            if (assetToSpawn != null)
            {
                var instance = Instantiate(assetToSpawn);      
                    var topGround_y = groundTopCordinates + SpawnerHelper.GetExtentsOfObj(instance);
                    instance.transform.position = new Vector3(xCordinate, topGround_y, 0);
                    objectLenght = instance.transform.localScale.x;
                return instance;
            }
            return null;
        }

    }
}
