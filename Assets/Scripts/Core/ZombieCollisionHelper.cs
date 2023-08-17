using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public static class ZombieCollisionHelper
    {
        private static GameObject previousGroundObj;


        public static bool IsZombieOnSameGround(GameObject groundObj)
        {
            if(previousGroundObj != null && previousGroundObj == groundObj)
            return true;
            else
            {
                previousGroundObj = groundObj;
                return false;
            }
        }
    }
}
