using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnviromentBlock :MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objsOnGround = new List<GameObject>();
    private ISpawner[] spawners;
    private float objectsOffset =10f;
    private int amountToSpawn;

    private void Start()
    {
        SpawnRandomObjecstOnGround();
    }

    public void OnInitit(ISpawner[] spawners)
    {
        this.spawners = spawners;
    }

    private void SpawnRandomObjecstOnGround()
    {
        int randomObjIndex;
        int lastIndex = 0;
        float groundMaxPos =0f;
        float groundMinPos =0f;

        amountToSpawn = GetSpawnAmount();


        GroundSpawner.GetGroundMaxAndMinCordinate(this.gameObject, ref groundMaxPos, ref groundMinPos);


        float Xpossition = groundMinPos + 5f;
        float totalSpace = 0f;
        for (int i = 0; i < amountToSpawn; i++)
        {
            randomObjIndex = UnityEngine.Random.Range(0, spawners.Length);

            if (lastIndex == randomObjIndex)
            {
                randomObjIndex = UnityEngine.Random.Range(0, spawners.Length);

            }
              var objs = spawners.ElementAt(randomObjIndex).SpawnRandomObject(GroundSpawner.GetGroundTopCordinates(this.gameObject), Xpossition);
                objsOnGround.Add(objs);
            totalSpace += spawners.ElementAt(randomObjIndex).ObjectLenght;
            if(totalSpace >= (groundMaxPos - 5f))
            {
                return;
            }
           lastIndex = randomObjIndex;
            Xpossition += objectsOffset;
        }
    }

    private int GetSpawnAmount()
    {
        int maxAmount = (int)(this.transform.localScale.x / objectsOffset);


        if(maxAmount >2)
        {
            return Random.Range(maxAmount -1, maxAmount);
        }
        else
        {
            return Random.Range(0, maxAmount);
        }

    }
}
