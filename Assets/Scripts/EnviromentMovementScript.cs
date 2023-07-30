using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovementScript : MonoBehaviour
{
    private float movementSpeed = 5f;
    public Action OnGroundDeleted;


    // Update is called once per frame
    void Update()
    {
        DeleteGround();
        this.gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector3(Constants.DESTROY_X_POSSITION,this.transform.position.y), movementSpeed * Time.deltaTime);
    }

    private void DeleteGround()
    {
        if (this.gameObject.transform.position.x == Constants.DESTROY_X_POSSITION)
        {
            Destroy(gameObject);
            OnGroundDeleted?.Invoke();
        }
    }


}
