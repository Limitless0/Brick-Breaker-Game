using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points;
    public int hp;
    public Sprite[] hitsprite = {};

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = hitsprite[hp - 1];
    }

    public void HPUpdate()
    {
        hp--;
        GetComponent<SpriteRenderer>().sprite = hitsprite[hp - 1];
    }


}


