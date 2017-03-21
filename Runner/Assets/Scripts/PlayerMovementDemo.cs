using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovementDemo : MonoBehaviour {

    private Rigidbody rigidBody;
    public float force;
    public int jumpForce = 300;
    private int counter = 0;
    public Text scoreDisplayer;
    GameObject[] items;

    private void Restart()
    {
        counter = 0;
        scoreDisplayer.text = "SCORE: " + counter;
        transform.position = new Vector3(-10, -2, 0);       
        foreach (GameObject item in items)
        {
            item.SetActive(true);
        }
    }

    private void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpForce);
    }

    private void GoingForward()
    {
        gameObject.transform.position += Vector3.right * Time.deltaTime * force;
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        scoreDisplayer.text = "SCORE : " + counter;
        items = GameObject.FindGameObjectsWithTag("Pick Up");
    }

    // to run Physics
    private void FixedUpdate()
    {
        GoingForward();
       if (Input.GetKeyDown("space"))
        {
            Jump();
        }

       if (transform.position.y <= -4)
        {
            Restart();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            counter++;
            scoreDisplayer.text = "SCORE: " + counter;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Restart();
        }
    }

}


