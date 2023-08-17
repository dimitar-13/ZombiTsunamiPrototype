using UnityEngine;

namespace Assets.Scripts.InteractableObjectsScripts
{
    public class MovingVehicleHelper
    {
        public LayerMask groundLayerMask = 1 << 6;

        public bool IsPlayerOnSameGround(GameObject vehicleGround, GameObject playerGround)
        {
            return vehicleGround == playerGround; 
        }
    }
}
