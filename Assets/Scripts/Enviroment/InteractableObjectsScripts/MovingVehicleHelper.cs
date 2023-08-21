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

        public void MoveWarningSingFoward(GameObject warningSing)
        {

            warningSing.transform.position = new Vector2(warningSing.transform.position.x - 3f, warningSing.transform.position.y);
        }

    }
}
