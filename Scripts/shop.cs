using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour {

    BuildManager buildManager;
    Node bode;
    public TurretBlueprint standardTurret;
    public TurretBlueprint laserTurret; 

    void Start()
    {
        
        buildManager = BuildManager.instance;
        bode = Node.instance;
        return;
    }

    public void SelectStandardTurret()
    {
     
        Debug.Log("Purchased Turret");
        bode.SelectTurretToBuild(standardTurret);
        return;
    }

    public void SelectLaserTurret()
    {
      
        
        bode.SelectTurretToBuild(laserTurret);
        return;
        Debug.Log("Purchased Turret");
    }
}
