using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
   
    [Range(0, 5)] public float speed;
   
    void Update()
    {
        var X = new Vector3(0, 0, speed);
        transform.position = transform.position + X;
        Move();
    }

    private void Move()
    {
        //-2    +2
        // var move= new Vector3(Input.GetAxis("Horizontal") , 0 , 0);
        //  transform.position = transform.position + move;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var move = new Vector3(-2f, 0, 0);
            transform.position = transform.position + move;
            //transform.position = Vector3.Lerp(transform.position, transform.position + move , 1f * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var move = new Vector3(2f, 0, 0);
            transform.position = transform.position + move;
        }
    }
}
