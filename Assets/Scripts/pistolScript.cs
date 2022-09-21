using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;


public class pistolScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMove(InputValue inputValue)
    {
        player.SendMessage("OnMove", inputValue);
        
    }
    void OnFire(InputValue inputValue)
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        
    }
}
