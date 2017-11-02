using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMe : MonoBehaviour {

    public int topdown = 3;
    //public int leftright = 10;
    public float speed = 5;

    public bool direction = true;


    bool moveSignal = false;
    bool subSignal = false;
    float sign = 1;
    // Use this for initialization
    void Start()
    {
        if (direction)
            sign = 1;
        else
            sign = -1;

    }

    // Update is called once per frame
    void Update()
    {
        if (moveSignal == false)
        {
            if (transform.position.y <= -topdown)
            {
                sign = 1;

            }
            else if (transform.position.y >= topdown)
            {

                sign = -1;

            }

            transform.Translate(sign * Vector3.up * Time.deltaTime * speed);
        }




    }


    void StopMove()
    {
        moveSignal = true;
    }

}
