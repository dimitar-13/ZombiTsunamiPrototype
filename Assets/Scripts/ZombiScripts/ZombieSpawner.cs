using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZombieTsunami.Core;

namespace ZombieTsunami.ZombiScripts
{
    public class ZombieSpawner : MonoBehaviour
    {
        public ZombiManager zombiManager;
        private float lastSpawnLocation;

        public GameObject zombiePrefab;
        // Start is called before the first frame update

        void Start()
        {
            Events.OnHumanEaten += SpawnZombie;

            var zombie = Instantiate(zombiePrefab, new Vector3(-5, 0, 0), Quaternion.identity);
            zombiManager.Zombies.Add((zombie.GetComponent<Zombie>()));
        }
        //TODO: zombies must spawn at different Z possitions so they can overlap without messing up the collition  in this case 
        //the ground must be a cude rather then a square
        public void SpawnZombie()
        {
            float lastzombiePossitonY = zombiManager.Zombies.Last().transform.position.y;
            Vector2 lastzombiePossiton = zombiManager.Zombies.Last().transform.position;


            //float randomSpawnPossition = Random.Range(Constants.KILLZONE_X_POSSITION, -5);
            //if (lastSpawnLocation == randomSpawnPossition)
            //{
            //   randomSpawnPossition = Random.Range(Constants.KILLZONE_X_POSSITION, -5);
            //}
            //lastSpawnLocation = randomSpawnPossition;

            var zombie = Instantiate(zombiePrefab, new Vector2(lastzombiePossiton.x - .3f, lastzombiePossitonY), Quaternion.identity);
            zombiManager.Zombies.Add((zombie.GetComponent<Zombie>()));
        }
    }
}
