using UnityEngine;

namespace ZombieTsunami.Enviroment
{
    public class GroundSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] GroundAssets;
        public GameObject CurrentGround;
        public GroundGenerator groundGenerator;
        private float lastGroundOffset=0f;

        //max y -11.7
        //min y -3.6
        public void SpawnRandomGroundAsset()
        {
            var instance = groundGenerator.GenerateGround();

            float currentGroundBounds = SpawnerHelper.GetMaxBounOfObjX(CurrentGround);

            float newGroundBounds = SpawnerHelper.GetMinBounOfObjX(instance) * -1;

            float groundOffset = Random.Range(3f, 6f);
            if(groundOffset == lastGroundOffset)
            {
                groundOffset = Random.Range(3f, 6f);
            }

            instance.transform.position = new Vector2(currentGroundBounds + groundOffset + newGroundBounds, Random.Range(-6.16f, -4.76f));
            CurrentGround = instance;
            lastGroundOffset = groundOffset;
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
