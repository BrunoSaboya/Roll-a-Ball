using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float speed = 0;
    public TextMeshProUGUI countText;

    public float startTime = 10f;
    private float timeRemaining;


    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        timeRemaining = startTime;
    }

    void OnMove(InputValue movementValue)
    {
        // Debug.Log("Move");
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        // Debug.Log("SetCountText");
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            SceneManager.LoadScene("Win");
        }
    }

    void FixedUpdate()
    {
        // Debug.Log("FixedUpdate");
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        timeRemaining -= Time.deltaTime;

        timerText.text = "Timer: " + timeRemaining.ToString("F2");

        if (timeRemaining <= 0f)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("OnTriggerEnter");
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Game Over");
        }
        
    }
}
