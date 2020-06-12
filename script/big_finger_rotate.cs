using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big_finger_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform big_finger;
    private bool big_flag = false;
    void Start()
    {
        big_finger = this.transform.parent;
    }
    void Update()
    {
        if(flag.confirm_flag==true)
        {
            if(big_flag==false)
            {
                if(this.name=="left")
                {
                    big_finger.RotateAround(big_finger.position, this.transform.right, -1f);
                }
               else
                {
                    big_finger.RotateAround(big_finger.position, this.transform.forward, 1f);
                }
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        big_flag = true;
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
