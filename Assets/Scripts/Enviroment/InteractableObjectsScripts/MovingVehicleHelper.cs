using UnityEngine;

namespace Assets.Scripts.InteractableObjectsScripts
{
    public class MovingVehicleHelper
    {
        public LayerMask groundLayerMask = 1 << 6;

        public bool IsPlayerOnSameGround(GameObject vehicle, GameObject player)
        {
            RaycastHit2D vehicleRay = Physics2D.Raycast(vehicle.transform.position, Vector2.down, 10f, groundLayerMask);
            RaycastHit2D playerRay = Physics2D.Raycast(player.transform.position, Vector2.down, 10f, groundLayerMask);
            return (vehicleRay && playerRay) ? vehicleRay.collider.Equals(playerRay.collider) : false;
        }
    }
}
