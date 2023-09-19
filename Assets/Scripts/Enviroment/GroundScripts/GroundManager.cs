using UnityEngine;

namespace Assets.Scripts.Enviroment
{
    public class GroundManager : MonoBehaviour
    {
        public static GroundManager Instance; // Singleton instance

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void NotifyPlayerStepOnGround(Transform groundTransform)
        {
            // Notify objects about the player stepping on the ground
        }

        private bool isPlayerOnGround = false;
        public bool IsPlayerOnGround { get { return isPlayerOnGround; } }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Zombie")
            {
                isPlayerOnGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Zombie")
            {
                isPlayerOnGround = false;
            }
        }

    }
}
