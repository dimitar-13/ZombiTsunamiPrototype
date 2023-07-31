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
        public static void GetBoundries(Transform parentObject, ref float smallestXPosition, ref float farthestXPosition)
        {
            smallestXPosition = float.MaxValue; // Initialize with a very large value
            farthestXPosition = float.MinValue; // Initialize with a very small value

            foreach (Transform child in parentObject)
            {
                // Use 'child.position.x' to access the X position of the child object
                float childXPosition = child.position.x;

                // Update the smallestXPosition if the current child is farther to the left
                smallestXPosition = Mathf.Min(smallestXPosition, childXPosition);

                // Update the farthestXPosition if the current child is farther to the right
                farthestXPosition = Mathf.Max(farthestXPosition, childXPosition);
            }
        }
    }
}
