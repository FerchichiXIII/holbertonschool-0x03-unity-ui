using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1500f;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickup")
        {
            score += 1;
            Destroy(other.gameObject);
            SetScoreText();
        }
    if (other.tag == "Trap")
    {
        health --;
        //Debug.Log($"Health: {health}");
        SetHealthText();
    }
    if (other.tag == "Goal")
    {
        Debug.Log("You win!");
    }


    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
       float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x, 0, z).normalized;
        Vector3 force = dir * speed * Time.deltaTime;
        rb.AddForce(force);
    }
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
    void SetScoreText()
    {
        scoreText.text =  "Score: " + score;
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
    
}
