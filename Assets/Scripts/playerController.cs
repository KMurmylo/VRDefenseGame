using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movement;
    public float speed = 20;
    public float health = 200;
    private float sprinting;
    public Slider hPBar;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject camera;
    public GameObject leftController;
    public GameObject rightController;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        movement = new Vector3(0, 0, 0);
        
        hPBar.maxValue = health;
        hPBar.value = health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* void OnLook(InputValue inputValue)
    {
        Vector2 vect = inputValue.Get<Vector2>();
        Quaternion rotationx = Quaternion.Euler(0, vect.x, 0);
        transform.rotation = transform.rotation * rotationx;
    }*/
    void FixedUpdate()
    {
        rb.AddForce(Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * movement * (speed + (sprinting * 50)));

    }
    void OnMove(InputValue inputValue)
    {

        Vector2 vect = inputValue.Get<Vector2>();
        movement.x = vect.x;
        movement.z = vect.y;

    }
    void OnSprint(InputValue inputValue)
    {
        sprinting = inputValue.Get<float>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            health = health - other.gameObject.GetComponent<projectileScript>().damage;
            updateHealth();
            Destroy(other.gameObject);
            if (health <= 0)
            { GameOver(); }
        }
    }
    private void updateHealth()
    {
        hPBar.value = health;
    }
    private void GameOver() {
        GameObject.Find("GameOverRoom").SendMessage("GameOver", "You died");
    }
    public void addScore(int amount)
    {
        score += amount;
        scoreText.text=score.ToString();
    }
    public int getScore()
    {
        return score;
    }
    /*void OnPrimaryButton(InputValue inputValue)
    {
        Instantiate(bulletPrefab,leftController.transform.position,leftController.transform.rotation);
        Debug.Log(inputValue.ToString());
    }
    void OnSecondaryButton(InputValue inputValue)
    {
        Instantiate(bulletPrefab, rightController.transform.position, leftController.transform.rotation);
        Debug.Log(inputValue.ToString());
    }*/

}
