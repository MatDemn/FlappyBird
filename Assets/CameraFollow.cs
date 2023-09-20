using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Camera cameraToFollow;
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 0, -10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraToFollow.transform.position = new Vector3(objectToFollow.position.x + cameraOffset.x, cameraToFollow.transform.position.y, cameraOffset.z);
    }
}
