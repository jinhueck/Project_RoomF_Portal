﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;



    void Update()
    {



        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector2.right * speed);

        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(-Vector2.right * speed);

        }

        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(Vector3.forward * speed);

        }

        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(-Vector3.forward * speed);

        }

    }
}
