using UnityEngine;

namespace ZombieTsunami.Enviroment
{
    public static class SpawnerHelper
    {
        public static GameObject GetRandomAssetToSpawn(GameObject[] assets)
        {
            int randomIndex = Random.Range(0, assets.Length);
            return assets[randomIndex];
        }
        
        public static float GetExtentsOfObj(GameObject gameObjs)
        {
            return gameObjs.transform.localScale.y / 2;
        }

        /// <summary>
        /// Returns the right side of the give game object
        /// </summary>
        /// <param name="gameObjs"></param>
        /// <returns></returns>
        public static float GetMaxBounOfObjX(GameObject gameObjs)
        {
            return gameObjs.transform.position.x + (gameObjs.transform.localScale.x /2);
        }
        public static float GetMinBounOfObjX(GameObject gameObjs)
        {
            return gameObjs.transform.position.x - (gameObjs.transform.localScale.x / 2);
        }
        public static float GetObjTopCordinate(GameObject gameObjs)
        {
            return gameObjs.transform.position.y + GetExtentsOfObj(gameObjs);
        }
        public static float GetObjBottomCordinate(GameObject gameObjs)
        {
            return gameObjs.transform.position.y - GetExtentsOfObj(gameObjs);
        }
    }
}
