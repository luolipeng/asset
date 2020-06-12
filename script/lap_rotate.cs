using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class lap_rotate : MonoBehaviour
{
    ///-public Transform root;
    public Transform feet;
    public Transform small_lap;
    public Transform big_lap;
    public Transform pedal_board;
   // private float l1 = 20.1837F;
    //private float l2 = 18.69872f;
    //private float l1 = 22.0759F;
   // private float l2 = 20.45173f;
    private float l1;
    private float l2;
    private  float length_sole;
    private float height_sole;
    // private double x0 = 100.41;
    //private double big_lap_y = 55.55399;
    private double big_lap_x;
    private double big_lap_y;
    public Transform human_cs;
    // private double z0;
    // Start is called before the first frame update
    void Start()
    {
        // big_lap.parent = human_cs;
        big_lap_x = big_lap.position.x;
        big_lap_y= big_lap.position.y;
        //z0 = big_lap.position.z;
        l1 = small_lap.position.x - big_lap.position.x;
        l2 = small_lap.position.y - feet.position.y;
        length_sole = feet.GetChild(0).position.x - feet.position.x;
        height_sole=Math.Abs( feet.GetChild(0).position.y - feet.position.y);

    }

    // Update is called once per fram
    public void rotate()
    {
        Transform rotate_point = GameObject.Find("rotate_point").transform;
        rotate_point.position = new Vector3(static_parameter.root.GetChild(1).position.x, 0, static_parameter.root.GetChild(1).position.z);
        static_parameter.human.parent = rotate_point;
        static_parameter.root.parent = rotate_point;


        rotate_point.Rotate(0, static_parameter.count_b, 0);
        static_parameter.root.parent = rotate_point.parent;
        static_parameter.human.parent = rotate_point.parent;

        big_lap_x = big_lap.position.x;
        big_lap_y = big_lap.position.y;


        double x2 = Math.Pow((double)(pedal_board.position.x - length_sole - big_lap_x), 2.0);
        double y2 = Math.Pow((double)(pedal_board.position.y + height_sole - big_lap_y), 2.0);
        double cos_a2 = (x2 + y2 - l1 * l1 - l2 * l2) / (2 * l1 * l2);
        double a2 = (Math.Acos(cos_a2) * (180 / Math.PI));

        double cos_a3 = (l2 * l2 - x2 - y2 - l1 * l1) / (-2 * l1 * Math.Sqrt(x2 + y2));
        double a3 = Math.Acos(cos_a3) * (180 / Math.PI);
        double a1_fan = 180 - Math.Atan((pedal_board.position.x - length_sole - big_lap_x) / (big_lap_y - pedal_board.position.y - height_sole)) * (180 / Math.PI);
        ///double a1_fan = 180 - Math.Atan((pedal_board.position.x- big_lap_x) / (big_lap_y - pedal_board.position.y)) * (180 / Math.PI);
        if (pedal_board.name == "pedal_right_board")
        {
            double a1 = (a1_fan - a3) - 180;

            float big_lap_rotate = (float)(a1 - (double)utils.getls(big_lap).x + static_parameter.ls_a);
            double ls = (double)utils.getls(small_lap).x + 3.6;


            //big_lap.Rotate(new Vector3(0, a0 - utils.getls(big_lap).x, 0));
            big_lap.Rotate(new Vector3(big_lap_rotate, 0, 0));
            // small_lap.parent = big_lap.parent;
            float small_lap_rotate = (float)(a2 - ls);
            small_lap.Rotate(new Vector3(small_lap_rotate, 0, 0));



            //double l1_ls = Math.Sqrt(Math.Pow(small_lap.position.x - big_lap.position.x, 2) + Math.Pow(small_lap.position.y - big_lap.position.y, 2));
            //double l2_ls = Math.Sqrt(Math.Pow(small_lap.position.x - feet.position.x, 2) + Math.Pow(small_lap.position.y - feet.position.y, 2));
            //Debug.Log(l1_ls - l1 + "   l1");
            //Debug.Log(l2_ls - l2 + "  l2");
            //Debug.Log(feet.GetChild(0).position - pedal_board.position);
            double feet_rotate = ((180 - a2) - ((a1_fan - a3) - 90));
            double ls_feet = (double)utils.getls(feet).x + 90;
            feet.Rotate(new Vector3((float)(feet_rotate - ls_feet), 0, 0));
            Debug.Log("right"+(feet.GetChild(0).position - pedal_board.position));
        }
        else
        {
            float a1 = (float)(a1_fan - a3) - 180;

            float big_lap_rotate = (float)(a1 - (double)utils.getls(big_lap).x + static_parameter.ls_a);
            big_lap.Rotate(new Vector3(big_lap_rotate, 0, 0));

            double ls = (double)utils.getls(small_lap).x + 3.6;
            float small_lap_rotate = (float)(a2 - ls);
            small_lap.Rotate(new Vector3(small_lap_rotate, 0, 0));

            double feet_rotate = ((180 - a2) - ((a1_fan - a3) - 90));
            double ls_feet = (double)utils.getls(feet).x + 90;
            feet.Rotate(new Vector3((float)(feet_rotate - ls_feet), 0, 0));


            //double l1_ls = Math.Sqrt(Math.Pow(small_lap.position.x - big_lap.position.x, 2) + Math.Pow(small_lap.position.y - big_lap.position.y, 2));
            //double l2_ls = Math.Sqrt(Math.Pow(small_lap.position.x - feet.position.x, 2) + Math.Pow(small_lap.position.y - feet.position.y, 2));
            //Debug.Log(l1_ls - l1 + "   l1");
            //Debug.Log(l2_ls - l2 + "  l2");
            Debug.Log(feet.GetChild(0).position - pedal_board.position);

        }
        rotate_point = GameObject.Find("rotate_point").transform;
        rotate_point.position = new Vector3(static_parameter.root.GetChild(1).position.x, 0, static_parameter.root.GetChild(1).position.z);
        static_parameter.human.parent = rotate_point;
        static_parameter.root.parent = rotate_point;


        rotate_point.Rotate(0, -static_parameter.count_b, 0);
        static_parameter.root.parent = rotate_point.parent;
        static_parameter.human.parent = rotate_point.parent;


    }

}
