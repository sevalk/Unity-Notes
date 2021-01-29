using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] GameObject dropList;
    [SerializeField] Transform parent;
    float _unitHeight = 1.1f;

    

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "collected")
        {

            collision.transform.parent = dropList.transform;
            StartCoroutine(SetHigh());
        }


    }


    //Sets the height of each cube collected and the character
    IEnumerator SetHigh()
    {
        
        yield return new WaitForSeconds(0.45f);

        foreach (Transform child in parent)
        {
            child.position = new Vector3(child.position.x, child.position.y - _unitHeight, child.position.z);
        }
        
    }
}
