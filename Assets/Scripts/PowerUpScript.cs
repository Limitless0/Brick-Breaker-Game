using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -1) * Time.deltaTime * speed);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
