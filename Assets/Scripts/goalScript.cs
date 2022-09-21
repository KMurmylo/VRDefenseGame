using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour
{
    public float health = 250f;
    private float maxHealth;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        renderer= gameObject.GetComponent<Renderer>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            health = health - other.gameObject.GetComponent<projectileScript>().damage;
            updateHealth();
            Destroy(other.gameObject);
            if (health <= 0)
            { GameOver();
              gameObject.SetActive(false);
            }
            
        }
    }
    private void updateHealth()
    {
        renderer.material.color = getcolor();

    }
    private Color getcolor()
    {
        float R = 1.0f - (health / maxHealth);
        float G=(float)health/maxHealth;
        return new Color(R, G, 0f);
    }
    private void GameOver()
    {
        GameObject.Find("GameOverRoom").SendMessage("GameOver", "Goal has been destroyed");
    }
}
