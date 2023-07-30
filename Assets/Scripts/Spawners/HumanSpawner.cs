using UnityEngine;

public class HumanSpawner : MonoBehaviour,ISpawner
{
    [SerializeField]
    private GameObject[] humanAssets;
   public GameObject[] assets
    {
        get { return humanAssets; }
        set { humanAssets = value; }
    }


    public GameObject SpawnRandomObject(float groundTopCordinates, float xCordinate)
    {
        int NumberOfHumansToSapwn = Random.Range(0, 8);
        GameObject parrentObject = new GameObject("HumanGroup");
        var parrentObjectInstance = Instantiate(parrentObject);
        for (int i = 0; i < NumberOfHumansToSapwn; i++)
        {
            var assetToSpawn = SpawnerHelper.GetRandomAssetToSpawn(humanAssets);
            var instance = Instantiate(assetToSpawn);

            var topGround_y = 0f;
            if (instance.TryGetComponent<BoxCollider2D>(out BoxCollider2D componet))
            {
                topGround_y = groundTopCordinates + (componet.bounds.extents.y);
                instance.transform.position = new Vector3(xCordinate + Random.Range(3f,5f), topGround_y, i*-1);
                instance.transform.parent = parrentObjectInstance.gameObject.transform;
            }
            else
            {
                Debug.Log("something went wrong");
            }
        }    
        return parrentObjectInstance;
    }



    public BoxCollider2D GetBoxCollider2D(GameObject gameobj)
    {
        if(gameobj.TryGetComponent<BoxCollider2D>(out BoxCollider2D boxColider))
        {
            return boxColider;
        }
        return null;
    }

}
