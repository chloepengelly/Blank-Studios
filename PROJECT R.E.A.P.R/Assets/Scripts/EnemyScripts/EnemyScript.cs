using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class EnemyScript: MonoBehaviour
{
    [Header("Path Variables")]

    PathCreator pathCreator;
    
    GameObject Path;

    float distanceMoved;
    float pathEndPoint;

    [Header("Enemy Stats")]

    [SerializeField] float enemyHP;
    [SerializeField] float enemyATK;
    [SerializeField] int enemyValue;

    [SerializeField] float enemySpeed = 10f;

    [Header("The Game Manager")]

    TheGameManager theGameManagerScript;

    void Start()
    {
        Path = GameObject.FindWithTag("EnemyPath");
        pathCreator = Path.gameObject.GetComponent<PathCreator>();

        theGameManagerScript = GameObject.FindWithTag("TheGameManager").GetComponent<TheGameManager>();
    }
    
    void Update()
    {
        distanceMoved += enemySpeed * Time.deltaTime;

        transform.position = pathCreator.path.GetPointAtDistance(distanceMoved);

        if(enemyHP <= 0)
        {
            EnemyDeath();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PathEnd")
        {
            Destroy(gameObject);
            theGameManagerScript.TakeDMG(enemyATK);
        }
    }

    public void TakeDMG(float damage)
    {
        enemyHP -= damage;
    }

    void EnemyDeath()
    {
        Destroy(gameObject);
        theGameManagerScript.AddToBalance(enemyValue);
    }



}
