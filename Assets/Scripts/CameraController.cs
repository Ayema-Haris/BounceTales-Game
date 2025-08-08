using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraController : MonoBehaviour
{
  // public GameObject Player;
   public Transform PlayerTransform;
  public Vector3 velocity = Vector3.zero;
   public float time = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //to move camera can use both of the following methods:
        
       // Method 1:
            //Vector3 targetPosition = new Vector3(PlayerTransform.position.x, transform.position.y, transform.position.z);

            //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, time);

        //Method 2:
        transform.position = new Vector3(PlayerTransform.position.x, transform.position.y, transform.position.z);
       
    }
}
