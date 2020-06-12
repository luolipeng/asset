using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_leg_rotate : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform show_small_leg;
    public Transform show_big_leg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag.confirm_flag)
        {
            //lap_rotate lap_rotet = new lap_rotate();
            Vector3 small_leg = utils.getls(show_small_leg);
            Vector3 origin_right_small_leg = utils.getls(static_parameter.right_small_leg);
            Vector3 origin_right_leg = utils.getls(static_parameter.right_big_leg);
            Vector3 big_leg = utils.getls(show_big_leg);
            show_big_leg.Rotate(origin_right_leg-big_leg);
            show_small_leg.position = show_big_leg.GetChild(0).position;
            show_small_leg.Rotate(origin_right_small_leg-small_leg);

        }
    }
}
