using UnityEngine;

public class HumanSpawner : MonoBehaviour,ISpawner
{
    [SerializeField]
    private GameObject[] humanAssets;
    private int lastSpawnAmount =0;
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
        objectLenght = 0f;
        int NumberOfHumansToSapwn = Random.Range(0, 4);

        if (lastSpawnAmount == NumberOfHumansToSapwn)
        {
            NumberOfHumansToSapwn = Random.Range(0, 4);
        }

        GameObject parrentObject = new GameObject("HumanGroup");
        var parrentObjectInstance = Instantiate(parrentObject);
        for (int i = 0; i < NumberOfHumansToSapwn; i++)
        {
            var assetToSpawn = SpawnerHelper.GetRandomAssetToSpawn(humanAssets);
            var instance = Instantiate(assetToSpawn);

            if (instance.TryGetComponent<BoxCollider2D>(out BoxCollider2D componet))
            {
                var topGround_y = groundTopCordinates + (componet.bounds.extents.y);
                var XCordinateOffset =  Random.Range(3f, 5f);

                instance.transform.position = new Vector3(xCordinate + XCordinateOffset, topGround_y, i*-1);
                objectLenght += instance.transform.localScale.x+ XCordinateOffset;

                instance.transform.parent = parrentObjectInstance.gameObject.transform;
            }
            else
            {
                Debug.Log("something went wrong");
            }
        }
        lastSpawnAmount = NumberOfHumansToSapwn;
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
