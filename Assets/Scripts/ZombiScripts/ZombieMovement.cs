using System.Collections;
using UnityEngine;

namespace ZombieTsunami.ZombiScripts
{
    public class ZombieMovement : MonoBehaviour
    {
        public int JumpHeigh = 5;
        public ZombiManager zombiManager;


        // Update is called once per frame
        void Update()
        {
            if (zombiManager.Zombies.Count != 0 && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(MakeZombiesJump());
            }
        }

        IEnumerator MakeZombiesJump()
        {
            foreach (var zombie in zombiManager.Zombies)
            {
                if (zombie.isOnGround)
                {
                    zombie.ZombieRigidBody.AddForce(Vector2.up * JumpHeigh, ForceMode2D.Impulse);
                    yield return new WaitForSeconds(0.1f);
                    yield return zombie;
                }
            }
        }
    }
}
