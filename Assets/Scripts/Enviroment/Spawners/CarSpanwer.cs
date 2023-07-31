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
                if (instance.TryGetComponent<BoxCollider2D>(out BoxCollider2D componet))
                {
                    var topGround_y = groundTopCordinates + (componet.bounds.extents.y);
                    instance.transform.position = new Vector3(xCordinate, topGround_y, 0);
                    objectLenght = instance.transform.localScale.x;
                }
                else
                {
                    Debug.Log("something went wrong");
                }
                return instance;
            }
            return null;
        }

    }
}
