using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    [Range(0, 5)] public float speed;
    //public float Sp = 1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var X = new Vector3(0, 0, speed);
        transform.position = transform.position + X;
       
    }

}
