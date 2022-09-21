using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    private bool canAttack = true;
    private float timeBetweenAttacks;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        timeBetweenAttacks = 0.2f;
    }
    private void attack(GameObject target)
    {
        transform.LookAt(target.transform);
        if (canAttack)
        {   
            Instantiate(bulletPrefab, transform.position,transform.rotation);
            
            canAttack = false;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }
    private void resetAttack()
    {
        canAttack = true;
    }
    // Update is called once per frame
    void Update()
    {
        attack(target);
    }
   
}
