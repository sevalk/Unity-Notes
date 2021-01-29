using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        StackTheCubes(collision);
    }

    private void StackTheCubes(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            Debug.Log("aaaaaaa");
            float _heightToAdd = 0f;
            float _unitHeight = 1.1f;

            float playersChildCount = this.transform.childCount - 1f;

            if (!collision.transform.parent)
            {

                collision.gameObject.tag = "collected";

                _heightToAdd = (_unitHeight + (playersChildCount * _unitHeight));


                collision.transform.parent = this.gameObject.transform;
                Vector3 position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + _heightToAdd, this.gameObject.transform.position.z);
                collision.gameObject.transform.position = position;
                
                collision.gameObject.transform.rotation = this.gameObject.transform.rotation;
                
            }
            else
            {
                
                GameObject collectableCubesParent = collision.transform.parent.gameObject;


                //Adjusts the height of the collected cubes and the characters
                foreach (Transform child in collectableCubesParent.transform)
                {
                    child.gameObject.tag = "collected";
                    _heightToAdd += _unitHeight;

                    Vector3 position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + (_heightToAdd + (playersChildCount * _unitHeight)), this.gameObject.transform.position.z);
                    child.position = position;


                    child.gameObject.transform.rotation = this.gameObject.transform.rotation;


                }


                DestroyListParent(collectableCubesParent);

            }


        }
    }


    //Makes the parent of the collected cubes a player and destroys the empty parent
    private void DestroyListParent(GameObject collectableCubesParent)
    {
        int childcount;
        for (childcount = collectableCubesParent.transform.childCount; childcount > 0; childcount--)
        {
            collectableCubesParent.transform.GetChild(0).parent = this.gameObject.transform;
        }
        Destroy(collectableCubesParent);
    }
}
