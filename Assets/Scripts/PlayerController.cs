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
    public Text WinLoseText;
    public Image WinLoseImage;
    public GameObject win;
    public GameObject over;

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
        //Debug.Log("You win!");
        WinLoseText.color = Color.black;
        WinLoseImage.color = Color.green;
        WinLoseText.text = "You win!";
        win.SetActive(true);
        StartCoroutine(LoadScene(3));

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
            //Debug.Log("Game Over!");
            WinLoseText.color = Color.white;
            WinLoseImage.color = Color.red;
            WinLoseText.text = "Game Over!";
            over.SetActive(true);
            StartCoroutine(LoadScene(3));

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
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Maze");
        score = 0;
        health = 5;
    }
}
