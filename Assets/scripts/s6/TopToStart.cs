//#define PHONE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopToStart : MonoBehaviour
{

    [SerializeField] GameObject player;

    private Touch theTouch;

    private void Awake()
    {
        player.SetActive(false);
    }

    void Update()
    {
        topToStart();
    }

    public void topToStart()
    {

#if PHONE
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            Destroy(this.gameObject);
            player.SetActive(true);
            
        }
#else
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
            player.SetActive(true);
        }


#endif
    }
}
