using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    //public float newPosition;
    public float speed;

    public float lowerBound=0;
    public float upperBound;
   // public float middleBound = 1;
    bool isMovingDown=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingDown)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
       else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
            if (transform.position.y >= upperBound)
            {
            isMovingDown = true;
            }

        if (transform.position.y < lowerBound)
        {
            //newPosition = transform.position.y + 0.1f;
           
            isMovingDown = false;
        }





    }
}
