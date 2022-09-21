using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public float lifetime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
        IEnumerator coroutine = SelfDestruction(lifetime);
        StartCoroutine(coroutine);
        
        
    }
    IEnumerator SelfDestruction(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
