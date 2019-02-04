using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;//changed

    private Rigidbody rb;
    private int count;
    private int score;//changed

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;//changed
        SetAllText ();
        winText.text = "";
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetAllText();//changed
        }
        else if (other.gameObject.CompareTag("Enemy"))//changed and added
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            SetAllText();//changed           
        }
    }
    
    void SetAllText ()//changed
    {
       // scoreText.text = "Winnings: " + score.ToString();
        countText.text = "Consumption Score:" + count.ToString();
        if (count >=12)
        {
            winText.text = "The Game Has Been Won";
        }        
    }
}
/*rivate void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Pick Up"))
    {
        other.gameObject.SetActive(false);
        count = count + 1;
        score = score + 1; // I added this code to track the score and count separately.
        SetAllText();
    }
    else if (other.gameObject.CompareTag("Enemy"))
    {
        other.gameObject.SetActive(false);
        count = count + 1;
        score = score - 1; // this removes 1 from the score
        SetAllText();
    }
}*/