using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed;

    Vector3 target;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground" || other.tag == "Enemy")
        {
            //Destroy(this);
        }
    }
    private void Update()
    {
        MoveToTarget();
    }

    public void SetEnemyTarget(Collider Enemy)
    {
        target = Enemy.transform.position;
    }

    void MoveToTarget()
    {
        float step = moveSpeed * Time.deltaTime;
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

        if(transform.position == target)
        {
            Destroy(this.gameObject);
        }
        
    }
}
