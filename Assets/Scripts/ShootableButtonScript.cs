using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableButtonScript : MonoBehaviour
{   public GameObject messageReceiver;
    public bool repeatable = false;
    public string message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            messageReceiver.SendMessage(message);
            Destroy(other.gameObject);
            if (!repeatable)Destroy(gameObject);

        }
    }
}
