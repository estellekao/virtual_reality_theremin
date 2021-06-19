using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;


public class move_card : MonoBehaviour
{
    //movement speed in units per second
    //public float filtering;
    public float x_offset;
    //public float x_orig;

    
    public string name ;
    public GameObject righthand;
    GetLeapFingers rightfinger_script;
    RigidHand righthand_script;
    
    /*
    void Start()
    {
        x_orig = transform.position.x;
        //rightfinger_script = righthand.GetComponent<GetLeapFingers>();
        //righthand_script = righthand.GetComponent<RigidHand>();
    }
    */
     

    void Update()
    {
        
        x_offset = GetLeapFingers.MinFingerToPoleDist + 0.07f;
        //update the position
        
        if (x_offset != 100) {
            transform.position = new Vector3(transform.position.x, transform.position.y, x_offset);
        }
        
        //Debug.Log(transform.position);
    }
        
}
