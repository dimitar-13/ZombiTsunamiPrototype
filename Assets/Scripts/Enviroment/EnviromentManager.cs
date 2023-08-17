using Assets.Scripts.Enviroment;
using UnityEngine;

namespace ZombieTsunami.Enviroment
{
    public class EnviromentManager : MonoBehaviour
    {
        [SerializeField]
        public GroundSpawner groundSpawner;
        private ISpawner[] spawners;
        private int groundCount;

        // Start is called before the first frame update
        void Start()
        {
            spawners = this.gameObject.GetComponents<ISpawner>();
            groundSpawner.SpawnStartingGround();
            groundCount++;
            if (groundSpawner.CurrentGround.TryGetComponent<EnviromentMovementScript>(out EnviromentMovementScript groundScript))
            {
                groundScript.OnGroundDeleted += () => { groundCount--; };
            }
            groundSpawner.CurrentGround.gameObject.AddComponent<GroundSpawnManager>().OnInitit(spawners);
        }

        // Update is called once per frame
        void Update()
        {

            if (!(groundCount >= 3))
            {
                SpawnInviroment();
            }
        }

        private void SpawnInviroment()
        {
            groundSpawner.SpawnRandomGroundAsset();
            groundCount++;

            if (groundSpawner.CurrentGround.TryGetComponent<EnviromentMovementScript>(out EnviromentMovementScript groundScript))
            {
                groundScript.OnGroundDeleted += () => { groundCount--; };
            }
            groundSpawner.CurrentGround.gameObject.AddComponent<GroundSpawnManager>().OnInitit(spawners);

        }
    }
}
