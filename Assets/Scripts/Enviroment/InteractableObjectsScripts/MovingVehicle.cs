using System.Collections;
using UnityEngine;
using ZombieTsunami.Core;

namespace Assets.Scripts.InteractableObjectsScripts
{
    public class MovingVehicle : MonoBehaviour
    {

        private RaycastHit2D hitData;
        private Ray2D ray;
        [SerializeField]
        private LayerMask zombieMask;
        private bool isPlayerDetected = false;
        private float detectionTime = 0f;
        private MovingVehicleHelper helper;



        private GameObject currentGround;
        private void Start()
        {
            ray = new Ray2D(this.transform.position, Vector2.left);
            helper = new MovingVehicleHelper();
            Events.OnPlayerEnterNewGround += OnZombieTouchGround;
        }

        private void Update()
        {
        

        }

        IEnumerator ShootVehicleAtPlayer()
        {
            while (!isPlayerDetected)
            {
                hitData = Physics2D.Raycast(ray.origin, ray.direction, 100f, zombieMask);
                if (hitData.collider != null)
                {
                    isPlayerDetected = helper.IsPlayerOnSameGround(this.gameObject, hitData.collider.gameObject);
                }
                yield return null;
            }

            if(isPlayerDetected)
            {
            Debug.Log("Attention");
            yield return new WaitForSeconds(2); // Wait for 5 seconds after detecting the player
            }

            Debug.Log("Starting to move...");
            // Start moving the vehicle after waiting
            while (Vector2.Distance(gameObject.transform.position, new Vector2(Constants.DESTROY_X_POSSITION, this.transform.position.y)) > 0.1f)
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(Constants.DESTROY_X_POSSITION, this.transform.position.y), 15f * Time.deltaTime);
                yield return null;
            }
        }


        public void OnZombieTouchGround(Transform zombieTransform, Transform groundTransform)
        {
            StartCoroutine(ShootVehicleAtPlayer());
        }
    }
}
