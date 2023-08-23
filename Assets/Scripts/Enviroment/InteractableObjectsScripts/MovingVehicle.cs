﻿using Assets.Scripts.Core;
using Assets.Scripts.Enviroment;
using System.Collections;
using UnityEngine;
using ZombieTsunami.Enviroment;

namespace Assets.Scripts.InteractableObjectsScripts
{
    public class MovingVehicle : MonoBehaviour, IGroundDependent,IInteractable
    {
        private MovingVehicleHelper helper;
        public GameObject CurrrentGround { get; set; }

        [SerializeField]
        private GameObject warningSing;
        private void Start()
        {
            helper = new MovingVehicleHelper();
            Events.OnPlayerEnterNewGround += OnZombieTouchGround;
            CurrrentGround.GetComponent<EnviromentMovementScript>().OnGroundDeleted += () => {
                Destroy(this.gameObject);
            };
            // var spriteToLoad = Resources.Load("Assets/Scripts/Enviroment/CoinBlock.cs");
            warningSing = (GameObject)Resources.Load("SpawnableObjects/UiSpawnableElements/WarningSing");
        }
        IEnumerator ShootVehicleAtPlayer()
        {
            helper.MoveWarningSingFoward(Instantiate(warningSing));

            yield return new WaitForSeconds(2); 
            Debug.Log("Starting to move..."); 
            while (Vector2.Distance(gameObject.transform.position, new Vector2(Constants.DESTROY_X_POSSITION, this.transform.position.y)) > 0.1f)
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2(Constants.DESTROY_X_POSSITION, this.transform.position.y), 15f * Time.deltaTime);
                yield return null;
            }
            Destroy(gameObject);
        }


        public void OnZombieTouchGround(GameObject playerGround)
        {
            if(helper.IsPlayerOnSameGround(this.CurrrentGround, playerGround))
            StartCoroutine(ShootVehicleAtPlayer());

        }

        public void Interact(Zombie zombie)
        {
            Events.OnZombieKilled?.Invoke(zombie);
            Destroy(gameObject);

        }
    }
}
