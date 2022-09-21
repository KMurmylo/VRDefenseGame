using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameOverScript : MonoBehaviour
{
    public GameObject spawnPoint;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI causeText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver(string cause)
    {
        GameObject player = GameObject.Find("Player");
        player.transform.position = spawnPoint.transform.position;
        causeText.text = cause;
        scoreText.text = "Your score: "+player.GetComponent<playerController>().getScore().ToString();

    }
    void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
