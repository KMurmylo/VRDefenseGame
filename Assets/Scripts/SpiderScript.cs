using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderScript : MonoBehaviour
{   
    public int scoreValue=10;
    public float health = 100;
    public float timeBetweenAttacks = 1;
    

    public LayerMask WhatIsPlayer, WhatIsGoal;
    private NavMeshAgent agent;
    private GameObject goal;
    private GameObject player;
    public GameObject bulletPrefab;
    public GameObject shootingPoint;

    public float attackRange = 10;
    public float aggroRange = 20;
    public float maxSpread = 3;
    public int numberOfShots = 5;
    private bool goalInAttackRange;
    private bool playerInAttackRange;
    private bool playerInAggrokRange;
    private bool canSeePlayer;
    private bool canAttack=true;
    private RaycastHit hit;

    private IEnumerator attackCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
        goal = GameObject.Find("Goal");
        player = GameObject.Find("Player");
        
        
    }
 
    

    // Update is called once per frame
    void Update()
    {
        goalInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsGoal);
        playerInAttackRange=Physics.CheckSphere(transform.position,attackRange, WhatIsPlayer);
        playerInAggrokRange = Physics.CheckSphere(transform.position, aggroRange, WhatIsPlayer);
        
        
        if (goalInAttackRange &&checkLineOfSight(goal)) attack(goal);
        else{
        if (playerInAttackRange&& checkLineOfSight(player)) attack(player);
        else{
        if (playerInAggrokRange) agent.SetDestination(player.transform.position);
        else agent.SetDestination(goal.transform.position);
        }
        }
        
    }
    private bool checkLineOfSight(GameObject target)
    {
        Vector3 direction =-(transform.position - target.transform.position);
        direction = direction / direction.magnitude;
        RaycastHit hit;
        Physics.Raycast(shootingPoint.transform.position, direction, out hit, 500);


        if (hit.collider != null&& Object.ReferenceEquals(hit.collider.gameObject,target))
        {
            return true;
        }
        else
            return false;

    }
    private void attack(GameObject target)
    {
        agent.ResetPath();
        
        transform.LookAt(target.transform);
        if (canAttack)
        {
            for(int i = 0; i < numberOfShots; i++)
            Instantiate(bulletPrefab, shootingPoint.transform.position, transform.rotation*
                Quaternion.Euler(Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread), Random.Range(-maxSpread, maxSpread))    
                );
            canAttack = false;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }

    }
    private void resetAttack()
    {
        
        canAttack = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health = health - other.gameObject.GetComponent<projectileScript>().damage;
            
            Destroy(other.gameObject);
            if (health<=0)
            {
                GameObject.Find("SpawnSystem").GetComponent<SpawnSystemScript>().enemyDestroyed();
                player.GetComponent<playerController>().addScore(scoreValue); 
                Destroy(gameObject); }
        }
    }
   
}