using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance; //make sure there is only one instance in the scene. 
    //public Transform SpawnpointLaser;
    //public Transform SpawnPointTurret;
   public GameObject buildturret; 

    private void Awake()
    {
        instance = this; 
    }
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

   /* public void BuildTurretOn(Node node)
    {
        Debug.Log("got here");
         if (PlayerStats.Money < turretToBuild.cost)
        {

        Debug.Log("no money");
         return; 
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        //Debug.Log("Got here");

       // if (Transform.SpawnpointLaser =  )
        //Instantiate(buildturret, SpawnPointTurret.position, SpawnPointTurret.rotation);
        //Instantiate(buildturret, SpawnpointLaser.position, SpawnpointLaser.rotation);
        //node.turret = turret;
       

        Debug.Log("Turret to build left" + PlayerStats.Money);
    }*/

    

   // public TurretBlueprint turretToBuild; 

   // public bool CanBuild { get { return turretToBuild != null; } }
    //public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    //public void SelectTurretToBuild(TurretBlueprint turret)
   // {
       // turretToBuild = turret;
    }
//}
