using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControllerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 10;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    





    void Start()
    {
        winTextObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        float speed_ball = Vector3.Magnitude(rb.velocity);
        rb.AddForce(movement * speed);
        if (speed_ball >= 10)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        
    }


    void OnJump(InputValue value)
    {

        if (gameObject.transform.position.y == 0.5)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 5, rb.velocity.z);
        }
    }

    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        Debug.Log(movementX + " " + movementY);
    }

    void SetCountText()
    {
       
        countText.text = "Count: " + count.ToString();

        // Check if the count has reached or exceeded the win condition.
        if (count >= 6)
        {
            winTextObject.SetActive(true);
        }
    }


    }
