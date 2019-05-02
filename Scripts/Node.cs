
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour
{
    public static Node instance;
    public Color hoverColor;
    [Header("Optional")]
    public GameObject turret;
    public GameObject theNode;
   public GameObject TurretNode;

    private Renderer rend;
    public Vector3 positionOffset;
    public GameObject buildturret;
    public GameObject anotherTurretPrefab;
    public GameObject Laserblender;

    public Transform SpawnpointLaser;
    public Transform SpawnPointTurret;

    //BuildManager buildManager;
    public Color notEnoughMoneyColor; 
    //private Color startColor;
    public GameObject standardTurretPrefab;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        Laserblender.gameObject.GetComponent<MeshRenderer>().enabled = false;
        TurretNode.gameObject.GetComponent<MeshRenderer>().enabled = false;
        theNode.gameObject.GetComponent<MeshRenderer>().enabled = false; 
        Laserblender.GetComponent<Turret>().enabled = false;
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

      if (PlayerStats.Money >400){
            TurretNode.gameObject.GetComponent<MeshRenderer>().enabled = true;
            theNode.gameObject.GetComponent<MeshRenderer>().enabled = true; 
            //Laserblender.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Laserblender.GetComponent<Turret>().enabled = true;
            Debug.Log("you got money!!!");
        }
            
    }

        private void OnMouseDown()
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {

            Debug.Log("no money");
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())//is the pointer over a node.. do nothin
            return;
        //if (!buildManager.CanBuild)
            //return;
        if (turret != null)//checking if something is built here
        {
            Debug.Log("Cant build here");
            return;
        }
        Debug.Log("your clicking me...");
        
        BuildTurretOn(this);

        // Instantiate(buildturret, SpawnpointLaser.position, SpawnpointLaser.rotation);
    }
    public void YouHaveMoney(){
        
        if(PlayerStats.Money >500)
        Laserblender.SetActive(true);
        Debug.Log("no money");
        
        
    }
    public void BuildTurretOn(Node node)
    {
        Debug.Log("got here!!");
        if (PlayerStats.Money < turretToBuild.cost)
        {

            Debug.Log("no money");
            return;
        }
        else if (PlayerStats.Money >= 400)
                {
            Debug.Log("Got in here!!!");
            //gameObject.SetActive(true);

            theNode.gameObject.GetComponent<MeshRenderer>().enabled = false;

            Instantiate(buildturret, SpawnpointLaser.position, SpawnpointLaser.rotation);
            PlayerStats.Money -= 400;
            Destroy(gameObject);
           // GetComponent<Renderer>().enabled =false; 
        } 
        else
        {
            
            Instantiate(buildturret, SpawnPointTurret.position, SpawnPointTurret.rotation);
           
            PlayerStats.Money -= 200;
            Destroy(gameObject);
            //TurretNode.gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (PlayerStats.Money >= 300)
                {
            Debug.Log("Got in here");
            //gameObject.SetActive(true);

            this.gameObject.GetComponent<MeshRenderer>().enabled = true;

            Instantiate(buildturret, SpawnpointLaser.position, SpawnpointLaser.rotation);
            PlayerStats.Money -= 300;

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
    }

   
    public TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }


    

}

