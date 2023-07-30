using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpanwer : MonoBehaviour,ISpawner
{
    [SerializeField]
    private GameObject[] carAssets;
    public GameObject[] assets
    {
        get { return carAssets; }
        set { carAssets = value; }
    }



    public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate)
    {
        var assetToSpawn = SpawnerHelper.GetRandomAssetToSpawn(carAssets);
        if (assetToSpawn != null)
        {
            var instance = Instantiate(assetToSpawn);

            var topGround_y = 0f;
            if (instance.TryGetComponent<BoxCollider2D>(out BoxCollider2D componet))
            {
                topGround_y = groundTopCordinates + (componet.bounds.extents.y);
                instance.transform.position = new Vector3(xCordinate, topGround_y, 0);
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
