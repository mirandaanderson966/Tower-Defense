using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretNode : MonoBehaviour
{

    public static Node instance;
    public Color hoverColor;
    [Header("Optional")]
    public GameObject turret;
    //public GameObject theNode;
    public GameObject Turretnode;

    private Renderer rend;
    public Vector3 positionOffset;
    public GameObject buildturret;
    public GameObject anotherTurretPrefab;

    public Transform SpawnpointLaser;
    public Transform SpawnPointTurret;

    //BuildManager buildManager;
    public Color notEnoughMoneyColor;
    //private Color startColor;
    public GameObject standardTurretPrefab;

    private void Awake()
    {
        
    }
    void Start()
    {
        Turretnode.gameObject.GetComponent<MeshRenderer>().enabled = false;
       // theNode.gameObject.GetComponent<MeshRenderer>().enabled = false;
        // startColor = rend.material.color;
        //buildManager = BuildManager.instance;
        // gameObject.SetActive(false);


    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void Update()
    {

        if (PlayerStats.Money >= 300)
        {
            Debug.Log("Got in here!!!");
            //gameObject.SetActive(true);

            //theNode.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        if (PlayerStats.Money >= 100)
        {
            Turretnode.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }


    private void OnMouseDown()
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {

            Debug.Log("no money");
            return;
        }
       // if (EventSystem.current.IsPointerOverGameObject())//is the pointer over a node.. do nothin
            return;
        //if (!buildManager.CanBuild)
        //return;
        if (turret != null)//checking if something is built here
        {
            Debug.Log("Cant build here");
            return;
        }
        Debug.Log("your clicking me...");

        BuildTurretn();

        // Instantiate(buildturret, SpawnpointLaser.position, SpawnpointLaser.rotation);
    }

    public void BuildTurretn()
    {
        Debug.Log("got here!!");
        if (PlayerStats.Money < turretToBuild.cost)
        {

            Debug.Log("no money");
            return;
        }
        else if (PlayerStats.Money >= 300)
        {
            Debug.Log("Got in here!!!");
            //gameObject.SetActive(true);

            //theNode.gameObject.GetComponent<MeshRenderer>().enabled = false;

            Instantiate(buildturret, SpawnpointLaser.position, SpawnpointLaser.rotation);
            PlayerStats.Money -= 300;
            // GetComponent<Renderer>().enabled =false; 
        }
        else
        {

            Instantiate(buildturret, SpawnPointTurret.position, SpawnPointTurret.rotation);
            PlayerStats.Money -= 100;
            Turretnode.gameObject.GetComponent<Renderer>().enabled = false;
        }

        //PlayerStats.Money -= turretToBuild.cost;
        Debug.Log("right before build");
        //GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);

        //Debug.Log("Got here");

        // if (Transform.SpawnpointLaser =  )
        // Instantiate(buildturret, SpawnPointTurret.position, SpawnPointTurret.rotation);
        //Instantiate(buildturret, SpawnpointLaser.position, SpawnpointLaser.rotation);
        //node.turret = turret;


        Debug.Log("Turret to build left" + PlayerStats.Money);
    }


    public TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }



}
