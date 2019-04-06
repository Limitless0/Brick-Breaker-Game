using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameManager gm;

    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform partpickleEffect;
    public Transform lifeUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay && !gm.gameOver)
        {
            transform.position = paddle.position;
        }

        if ((Input.GetButtonDown("Jump") && !inPlay) && !gm.gameOver)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }

        if (gm.gameOver)
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom"))
        {

            Debug.Log("ball off screen from bottom");
            rb.velocity = Vector2.zero;
            inPlay = false;

            gm.UpdateLives(-1);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int rand = UnityEngine.Random.Range(1, 101);

        if (other.transform.CompareTag("Brick"))
        {
            BrickScript brickScript = other.gameObject.GetComponent<BrickScript>();
            if (brickScript.hp > 1)
            {
                brickScript.HPUpdate();
            }
            else
            {

                if (rand > 70)
                {
                    Instantiate(lifeUp, other.transform.position, other.transform.rotation);
                }

                gm.UpdateScore(other.gameObject.GetComponent<BrickScript>().points);
                gm.UpdateBricks(-1); // TODO: change when variable strengh bricks implimented

                Destroy(other.gameObject);
                Transform newPartpickleEffect = Instantiate(partpickleEffect, other.transform.position, other.transform.rotation);
                Destroy(newPartpickleEffect.gameObject, 3.0f);
            }

        }
    }


}
