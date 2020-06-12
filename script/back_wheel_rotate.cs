using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class back_wheel_rotate : MonoBehaviour
{
    public Transform back_wheel;
    public Text textspeed;
    private float rotate_ll = 0;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {



        rotate_ll = rotate_ll + 1 * Time.deltaTime * 10;
        back_wheel.gameObject.transform.Rotate(new Vector3(0,1 * Time.deltaTime * 10, 0));
        back_wheel.GetChild(2).GetChild(0).Rotate(new Vector3(0, -1 * Time.deltaTime * 10, 0));
        back_wheel.GetChild(0).GetChild(0).Rotate(new Vector3(0, -1 * Time.deltaTime * 10, 0));
    }
}
