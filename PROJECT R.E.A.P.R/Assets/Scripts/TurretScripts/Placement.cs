using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placement : MonoBehaviour
{

    [SerializeField] Camera cam;

    [SerializeField] GameObject towerSelect;

    [SerializeField] Canvas towerMenu;

    GameObject targetObject;

    Spot spotScript;
    TheGameManager tgsScript;

    int towerACost;
    int towerBCost;
    int towerCCost;
    int towerDCost;
    int towerECost;

    [SerializeField] GameObject towerAObject;
    [SerializeField] GameObject towerBObject;
    [SerializeField] GameObject towerCObject;
    [SerializeField] GameObject towerDObject;
    [SerializeField] GameObject towerEObject;

    void Start()
    {
        tgsScript = GameObject.FindGameObjectWithTag("TheGameManager").GetComponent<TheGameManager>();

        towerACost = towerAObject.GetComponent<Turbine>().GetCost();
        towerBCost = towerBObject.GetComponent<Turbine>().GetCost();
        towerCCost = towerCObject.GetComponent<Turbine>().GetCost();
        towerDCost = towerDObject.GetComponent<Turbine>().GetCost();
        towerECost = towerEObject.GetComponent<Turbine>().GetCost();
    }

    void Update()
    {
        //INSTANTIATES MENU OVER THE TOWER PLACEMENT SPOT

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "TowerSpot")
                {
                    spotScript = hit.transform.gameObject.GetComponent<Spot>();

                    towerMenu.GetComponent<Canvas>().enabled = true;

                    towerMenu.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z - 1);
                }
                else if (hit.transform.gameObject.tag == "TowerMenu")
                {

                }
                else
                {
                    HideMenu();
                }
            }
        }
    }

    public void HideMenu()
    {
        towerMenu.GetComponent<Canvas>().enabled = false;
    }

    public void TriggerTowerA()
    {
        if (spotScript.hasTower)
        {
            //CANT PLACE TOWER
        }
        else
        {
            if(tgsScript.playerBalance > towerACost)
            {
                tgsScript.RemoveBalance(towerACost);

                spotScript.AddTower("towerA");
                HideMenu();
            }

        }
    }
    public void TriggerTowerB()
    {
        HideMenu();
    }
    public void TriggerTowerC()
    {
        HideMenu();
    }
    public void TriggerTowerD()
    {
        HideMenu();
    }
    public void TriggerTowerE()
    {
        HideMenu();
    }
    public void TriggerDeleteTower()
    {
        if (!spotScript.hasTower)
        {
            print("Nothing to delete");
        }
        else
        {
            spotScript.RemoveTower();
            HideMenu();
        }

    }


    void CheckTowerSpot()
    {

    }
}
