﻿using UnityEngine;

public class MoveLateral : MonoBehaviour
{
    // Start is called before the first frame update


    private bool moveRight = true;


    public float velocidade = 3f;
    public Transform pontoA;
    public Transform pontoB;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < pontoA.position.x)
        {

            moveRight = true;
        }

        if (transform.position.x > pontoB.position.x)
        {

            moveRight = false;
        }

        if (moveRight)
        {

            transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
        }
        else
        {

            transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
        }

    }
}
