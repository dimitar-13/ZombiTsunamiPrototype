using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZombieTsunami.Enviroment;

namespace Assets.Scripts.Enviroment.GroundScripts
{
    public class GroundBlockManager :MonoBehaviour
    {
        private GameObject groundObject;

        [SerializeField]
        private GroundSpawnManager spawnManager;


        public Func<GameObject> onPlayerEnterGround;


    }
}
