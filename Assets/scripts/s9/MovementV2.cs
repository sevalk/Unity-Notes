using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementV2 : MonoBehaviour
{

    bool right;
    bool left;
    [SerializeField] float min = -7f;
    [SerializeField] float max = 1f;
    float speed_touch = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            Vector3 go_right = new Vector3(max, 0, 0);
            Vector3 go_left = new Vector3(min, 0, 0);

            if (parmak.deltaPosition.x > 2.0f)
            {
                right = true;
                left = false;
            }

            if (parmak.deltaPosition.x < -2.0f)
            {
                right = false;
                left = true;
            }

            if (right == true)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + go_right, speed_touch * Time.deltaTime);
            }

            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + go_left, speed_touch * Time.deltaTime);
            }
        }
    }
}
