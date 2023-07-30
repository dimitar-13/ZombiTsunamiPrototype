using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField]
    public GroundSpawner groundSpawner;
    private ISpawner[] spawners;
    private int groundCount;

    // Start is called before the first frame update
    void Start()
    {
        spawners = this.gameObject.GetComponents<ISpawner>();
        groundSpawner.SpawnStartingGround();
    }

    // Update is called once per frame
    void Update()
    {
    
            if(!(groundCount >= 3))
             {
            SpawnInviroment();
             }  
    }

    private void SpawnInviroment()
    {
         groundSpawner.SpawnRandomGroundAsset();
        groundCount++;

        if(groundSpawner.CurrentGround.TryGetComponent<EnviromentMovementScript>(out EnviromentMovementScript groundScript))
        {
            groundScript.OnGroundDeleted += () => { groundCount--; };
        }
        groundSpawner.CurrentGround.gameObject.AddComponent<EnviromentBlock>().OnInitit(spawners);
    }





}
