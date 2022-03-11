using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour
{
    [SerializeField] GameObject turretRotateForTargetPoint;
    Transform turretDefultLookRotation;

    [SerializeField] GameObject turretSpinPoint;
    [SerializeField] float spinAmount;

    [SerializeField] float timeUntilAttack;
    float resetTimer;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shotPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] float turretATK;

    [SerializeField] public int level1Cost;
    [SerializeField] public int level2Cost;
    [SerializeField] public int level3Cost;

    [SerializeField] List<Collider> enemiesToTarget = new List<Collider>();

    private void Start()
    {
        resetTimer = timeUntilAttack;
        turretDefultLookRotation = turretRotateForTargetPoint.transform;


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemiesToTarget.Add(other);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesToTarget.Remove(other);
        }
    }

    private void Update()
    {
        if(enemiesToTarget.Count > 0)
        {
            if (enemiesToTarget[0] == null)
            {
                enemiesToTarget.Remove(enemiesToTarget[0]);
            }
        }


        TargetEnemy();
        
    }

    void TargetEnemy()
    {
        if (enemiesToTarget.Count > 0)
        {   

            //spins blades
            turretSpinPoint.transform.Rotate(new Vector3(0, 0, spinAmount));

            //sets the look at point to be in the enemy direction
            Vector3 target = new Vector3(enemiesToTarget[0].transform.position.x, turretRotateForTargetPoint.transform.position.y, enemiesToTarget[0].transform.position.z); 
            turretRotateForTargetPoint.transform.LookAt(target, Vector3.up);

            //attack enemy
            timeUntilAttack -= Time.deltaTime;

            if (timeUntilAttack <= 0)
            {
                Collider enemyTarget = enemiesToTarget[0];
                GameObject projectile;
                
                shotPoint.transform.LookAt(enemyTarget.transform.position, Vector3.up);
                projectile = Instantiate(bullet, shotPoint.transform.position, shotPoint.transform.rotation);

                projectile.GetComponent<bullet>().SetEnemyTarget(enemyTarget);
                projectile.GetComponent<bullet>().moveSpeed = bulletSpeed;

                enemyTarget.GetComponent<EnemyScript>().TakeDMG(turretATK);
                enemiesToTarget.Remove(enemiesToTarget[0]);

                timeUntilAttack = resetTimer;
            }



        }
        else if(enemiesToTarget.Count == 0)
        {
            turretRotateForTargetPoint.transform.rotation = Quaternion.Slerp(transform.rotation, turretDefultLookRotation.rotation, 1 * Time.deltaTime);
            timeUntilAttack = resetTimer;
        }
    }

    public void RemoveTower()
    {
        //Calculate refunding percentage of cost

        Destroy(gameObject);
    }

    public int GetCost()
    {
        return level1Cost;
    }

}
