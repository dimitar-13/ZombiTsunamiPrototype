using UnityEngine;
using ZombieTsunami.Core;

namespace ZombieTsunami.Enviroment
{
    public class GroundSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] GroundAssets;
        public GameObject CurrentGround;
        public GroundGenerator groundGenerator;

        //max y -11.7
        //min y -3.6
        public void SpawnRandomGroundAsset()
        {
            //we need to get a reference to the Instantiated onbject so that we can get the correct value for the Box collider bounds
            //for some reason if its a prefab you cant do it might be beause it doesnt exist in the scene

            //var instance = Instantiate(GroundAssets[randomIndex],new Vector3(Constants.SpawnXPossition, 0f),Quaternion.identity,this.gameObject.transform,);

            //var instance = Instantiate(groundGenerator.GenerateGround(), new Vector3(Constants.SPAWN_X_POSSITION, 0f), Quaternion.identity, this.gameObject.transform);
            var instance = groundGenerator.GenerateGround();

            float currentGroundBounds = SpawnerHelper.GetMaxBounOfObjX(CurrentGround);

            instance.gameObject.transform.position = new Vector3(Constants.SPAWN_X_POSSITION, 0f);

           // BoxCollider2D groundColider = instance.GetComponent<BoxCollider2D>();


            //since some of the box coliders does use offset to be able to get the exact bound location we need to subtract the offset of the colider
            float newGroundBounds = SpawnerHelper.GetMinBounOfObjX(instance);


            instance.transform.position = new Vector2(currentGroundBounds +  5f + newGroundBounds, Random.Range(-6.16f, -4.76f));
            CurrentGround = instance;
        }

        public void SpawnStartingGround()
        {
            var instance = groundGenerator.GenerateGround();
            instance.gameObject.transform.position = new Vector3(0f, -7.18f);
            CurrentGround = instance;
        }


        public GameObject GetCurrentGround()
        {
            return CurrentGround;
        }

        public static void GetGroundMaxAndMinCordinate(GameObject CurrentGround, ref float Max, ref float Min)
        {
            BoxCollider2D groundColider = CurrentGround.GetComponent<BoxCollider2D>();

            Max = CurrentGround.transform.position.x + groundColider.bounds.extents.x;
            Min = CurrentGround.transform.position.x - groundColider.bounds.extents.x;
        }


        public static float GetGroundTopCordinates(GameObject CurrentGround)
        {
            return CurrentGround.transform.position.y + SpawnerHelper.GetExtentsOfObj(CurrentGround);
        }


    }
}
