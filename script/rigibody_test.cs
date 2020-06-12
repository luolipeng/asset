using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigibody_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // this.gameObject.GetComponent<Rigidbody>().adForce(new Vector3(10, 0, 0), ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(100, 0, 0), ForceMode.Force);
    }
}
