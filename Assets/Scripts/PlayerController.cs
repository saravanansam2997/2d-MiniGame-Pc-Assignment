using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 500f;

    private AudioSource audioSource;
    public bool isJumped = false;
    Rigidbody2D rd;


    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJumped == false)
            {
                rd.AddForce(Vector2.up * speed);
                isJumped = true;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("ground"))
        {
            if (isJumped)
            {
                isJumped = false;
            }
        }
        if (other.gameObject.CompareTag("Box"))
        {
            GameManager.Instance.RestartShow();
        }
    }


}
