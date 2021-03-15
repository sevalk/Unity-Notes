using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RaycastCam : MonoBehaviour
{
    Ray ray;
    RaycastHit Hit;

    Camera cam;

    [SerializeField] Transform ringPrefab;
    void Start()
    {
        cam = transform.GetComponent<Camera>();
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            DeformMesh();
        }
    }
    void DeformMesh()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out Hit))
        {
            //Deform Mesh
            
            DeformPlane deformPlane = Hit.transform.GetComponent<DeformPlane>();
            deformPlane.DeformThisPlane(Hit.point);

            Instantiate(ringPrefab, new Vector3(Hit.point.x, Hit.point.y, Hit.point.z + 0.62f),Quaternion.Euler(-90,0,0));
        }
    }
}
