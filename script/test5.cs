using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test5 : MonoBehaviour
{
    // Start is called before the first frame update
    private int cont = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }
    private void FixedUpdate()
    {
        rotate();
        if (cont == 90)
        {
            int s = 5;
        }
        if (flag.figure_flag[this.name] == true & flag.figure_isfinish[this.name] == false& flag.right_hand_rotate == true)
        {
            flag.figure_isfinish[this.name] = true;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            if (this.transform.childCount != 0 & this.transform.GetChild(0).GetComponent<test5>() != null)
            {
                this.transform.GetChild(0).GetComponent<test5>().enabled = true;
            }

        }

    }
    private void rotate()
    {
        if (cont < 90 & flag.figure_flag[this.name] == false & flag.right_hand_rotate == true)
        {
            this.transform.Rotate(0, 0, -1);
            cont = cont + 1;
        }
        if (cont == 90)
        {
            flag.figure_flag[this.name] = true;
        }


    }
    void OnCollisionEnter(Collision collision)
    {

        flag.figure_flag[this.name] = true;
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

    }

}
