using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{

    public bool hasTower;

    [SerializeField] GameObject towerA;
    [SerializeField] GameObject towerB;
    [SerializeField] GameObject towerC;
    [SerializeField] GameObject towerD;
    [SerializeField] GameObject towerE;


    GameObject currentTower;

    [SerializeField] Placement placementScript;

    TheGameManager tgsScript;


    private void Start()
    {
        tgsScript = GameObject.FindGameObjectWithTag("TheGameManager").GetComponent<TheGameManager>();
    }
    public void AddTower(string towerName)
    {
        hasTower = true;

        if(towerName == "towerA")
        {
            TowerA();
        }
        else if(towerName == "towerB")
        {
            TowerB();
        }
        else if(towerName == "towerC")
        {
            TowerC();
        }
        else if(towerName == "towerD")
        {
            TowerD();
        }
        else if(towerName == "towerE")
        {
            TowerE();
        }


    }

    public void RemoveTower()
    {
        hasTower = false;
        
        Destroy(currentTower);
    }

    void TowerA()
    {
        currentTower = (GameObject) Instantiate(towerA, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), transform.rotation * Quaternion.Euler(-45f, 180f, 0f));
    }

    void TowerB()
    {

    }

    void TowerC()
    {

    }

    void TowerD()
    {

    }

    void TowerE()
    {

    }


}
