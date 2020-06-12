
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_rotate_horizontal : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hand;
    public Transform low_hand;
    public Transform point;
    public Transform cycle_head;
    // public Transform head_right;
    private double l0;
    private double l1;
    private double l2;
    private double l3;
    private double l4;
    private double l5;
    private double l6;
    private double sz_length;//手掌长度

    private float a2;
    private float a3;
    private float a4;
    private float a6;
    private float a7;
    private float a8;
    private float a9;
    private float a10;

    public void Start()
    {
        //rotate_robot_2();
    }
    //左转专用手部非水平放置
    public void rotate_robot_2()
    {
        // hand.parent = static_parameter.body;
        Transform rotate_point = GameObject.Find("rotate_point").transform;
        rotate_point.position = new Vector3(static_parameter.root.GetChild(1).position.x, 0, static_parameter.root.GetChild(1).position.z);
        static_parameter.human.parent = rotate_point;
        static_parameter.root.parent = rotate_point;

        rotate_point.RotateAround(rotate_point.position, new Vector3(0, 1, 0), static_parameter.count_b);
        static_parameter.root.parent = rotate_point.parent;
        static_parameter.human.parent = rotate_point.parent;

        double l0_x2 = Math.Pow((double)(hand.position.x - point.position.x), 2.0);
        double l0_y2 = Math.Pow((double)(hand.position.y - point.position.y), 2.0);

        double l1_x2 = Math.Pow((double)(hand.position.x - low_hand.position.x), 2.0);
        double l1_y2 = Math.Pow((double)(hand.position.y - low_hand.position.y), 2.0);
        double l2_x2 = Math.Pow((double)(point.position.x - low_hand.position.x), 2.0);
        double l2_y2 = Math.Pow((double)(point.position.y - low_hand.position.y), 2.0);
        double l3_x2 = Math.Pow((double)(cycle_head.position.x - hand.position.x), 2.0);
        double l3_y2 = Math.Pow((double)(cycle_head.position.y - hand.position.y), 2.0);
        double l4_x2 = Math.Pow((double)(cycle_head.position.x - point.position.x), 2.0);
        double l4_y2 = Math.Pow((double)(cycle_head.position.y - point.position.y), 2.0);
        double l6_z2 = Math.Pow((double)(cycle_head.position.z - hand.position.z), 2.0);
        l0 = Math.Sqrt(l0_x2 + l0_y2);
        l1 = Math.Sqrt(l1_x2 + l1_y2);
        l2 = Math.Sqrt(l2_x2 + l2_y2);
        l3 = Math.Sqrt(l3_x2 + l3_y2);
        l4 = Math.Sqrt(l4_x2 + l4_y2);
        l5 = Math.Abs(cycle_head.position.z - hand.position.z);
        l6 = Math.Sqrt(l3_x2 + l3_y2 + l6_z2);
        double l1_ls = Math.Sqrt(Math.Pow(hand.position.x - low_hand.position.x, 2) + Math.Pow(hand.position.y - low_hand.position.y, 2) + Math.Pow(hand.position.z - low_hand.position.z, 2));
        double l2_ls = Math.Sqrt(Math.Pow(point.position.x - low_hand.position.x, 2) + Math.Pow(point.position.y - low_hand.position.y, 2) + Math.Pow(point.position.z - low_hand.position.z, 2));
        Debug.Log(l1_ls - l1 + "   sl1");
        Debug.Log(l2_ls - l2 + "  sl2");
        double cos_a2 = (l6 * l6 - l1 * l1 - l2 * l2) / (2 * l1 * l2);
        a2 = (float)(Math.Acos(cos_a2) * (180 / Math.PI));
        double cos_a3 = (l2 * l2 - l6 * l6 - l1 * l1) / (-2 * l6 * l1);
        a3 = (float)(Math.Acos(cos_a3) * (180 / Math.PI));
        double cos_a4 = (l4 * l4 - l3 * l3 - l0 * l0) / (-2 * l3 * l0);
        a4 = (float)(Math.Acos(cos_a4) * (180 / Math.PI));
        double cos_a6 = (l5 * l5 - l3 * l3 - l6 * l6) / (-2 * l6 * l3);
        a6 = (float)(Math.Acos(cos_a6) * (180 / Math.PI));

        if (cycle_head.name == "left")
        {
            // hand.parent= static_parameter.root.parent;
            a6 = hand.position.z > cycle_head.position.z ? a6 : -a6;
            hand.Rotate(0, 0, a4);
            hand.Rotate(0, a6, 0);
            hand.Rotate(0, -a3, 0);
            low_hand.Rotate(0, a2, 0);
            Vector3 low_hand_xl = low_hand.position - point.parent.position;
            Vector3 cycle_xl = cycle_head.GetChild(0).position - cycle_head.position;
            Vector3 edg_low_hand_xl = cycle_xl - low_hand_xl;
            float low_hand_length = low_hand_xl.magnitude;
            float cycle_length = cycle_xl.magnitude;
            float edg_low_hand_length = edg_low_hand_xl.magnitude;

            double cos_a7 = (edg_low_hand_length * edg_low_hand_length - low_hand_length * low_hand_length - cycle_length * cycle_length) / (-2 * cycle_length * low_hand_length);

            a7 = (float)(Math.Acos(cos_a7) * (180 / Math.PI));
            point.parent.Rotate(0, a7 - 90, 0);
            // l1_ls = Math.Sqrt(Math.Pow(hand.position.x - low_hand.position.x, 2) + Math.Pow(hand.position.y - low_hand.position.y, 2)+ Math.Pow(hand.position.z - low_hand.position.z, 2));
            // l2_ls = Math.Sqrt(Math.Pow(point.position.x - low_hand.position.x, 2) + Math.Pow(point.position.y - low_hand.position.y, 2) + Math.Pow(point.position.z - low_hand.position.z, 2));
            //Debug.Log(l1_ls - l1 + "   sl1");
            //Debug.Log(l2_ls - l2 + "  sl2");
            flag.left_hand_rotate = true;
        }

        else
        {


            a6 = hand.position.z > cycle_head.position.z ? a6 : -a6;
            hand.Rotate(0, 0, -a4);

            hand.Rotate(0, a6, 0);

            hand.Rotate(0, a3, 0);

            low_hand.Rotate(0, -a2, 0);

            Vector3 low_hand_xl = low_hand.position - point.parent.position;
            Vector3 cycle_xl = cycle_head.GetChild(0).position - cycle_head.position;
            Vector3 edg_low_hand_xl = cycle_xl - low_hand_xl;
            float low_hand_length = low_hand_xl.magnitude;
            float cycle_length = cycle_xl.magnitude;
            float edg_low_hand_length = edg_low_hand_xl.magnitude;

            double cos_a7 = (edg_low_hand_length * edg_low_hand_length - low_hand_length * low_hand_length - cycle_length * cycle_length) / (-2 * cycle_length * low_hand_length);

            a7 = (float)(Math.Acos(cos_a7) * (180 / Math.PI));
            point.parent.Rotate(0, 90 - a7, 0);

            flag.right_hand_rotate = true;

        }
        rotate_point = GameObject.Find("rotate_point").transform;
        rotate_point.position = new Vector3(static_parameter.root.GetChild(1).position.x, 0, static_parameter.root.GetChild(1).position.z);
        static_parameter.human.parent = rotate_point;
        static_parameter.root.parent = rotate_point;

        rotate_point.RotateAround(rotate_point.position, new Vector3(0, 1, 0), -static_parameter.count_b);
        static_parameter.root.parent = rotate_point.parent;
        static_parameter.human.parent = rotate_point.parent;

        //hand.parent = static_parameter.root.parent;
        //hand.Rotate(new Vector3(0, 90, 0));
    }
    //左转专用手部水平放置
    public void rotate_robot_3()
    {
        Transform rotate_point = GameObject.Find("rotate_point").transform;
        rotate_point.position = new Vector3(static_parameter.root.GetChild(1).position.x, 0, static_parameter.root.GetChild(1).position.z);
        static_parameter.human.parent = rotate_point;
        static_parameter.root.parent = rotate_point;

        rotate_point.RotateAround(rotate_point.position, new Vector3(0, 1, 0), static_parameter.count_b);
        static_parameter.root.parent = rotate_point.parent;
        static_parameter.human.parent = rotate_point.parent;

        sz_length = Math.Sqrt(Math.Pow((double)(point.position.x - point.GetChild(0).position.x), 2.0) + Math.Pow((double)(point.position.y - point.GetChild(0).position.y), 2.0) + Math.Pow((double)(point.position.z - point.GetChild(0).position.z), 2.0));


        double l0_x2 = Math.Pow((double)(hand.position.x - point.position.x), 2.0);
        double l0_y2 = Math.Pow((double)(hand.position.y - point.position.y), 2.0);

        Vector3 cycle_head_new = utils.cal_cycle_head_new(cycle_head, sz_length);

        double l1_x2 = Math.Pow((double)(hand.position.x - low_hand.position.x), 2.0);
        double l1_y2 = Math.Pow((double)(hand.position.y - low_hand.position.y), 2.0);
        double l2_x2 = Math.Pow((double)(point.position.x - low_hand.position.x), 2.0);
        double l2_y2 = Math.Pow((double)(point.position.y - low_hand.position.y), 2.0);
        double l3_x2 = Math.Pow((double)(cycle_head_new.x - hand.position.x), 2.0);
        double l3_y2 = Math.Pow((double)(cycle_head_new.y - hand.position.y), 2.0);
        double l4_x2 = Math.Pow((double)(cycle_head_new.x - point.position.x), 2.0);
        double l4_y2 = Math.Pow((double)(cycle_head_new.y - point.position.y), 2.0);
        double l6_z2 = Math.Pow((double)(cycle_head_new.z - hand.position.z), 2.0);
        l0 = Math.Sqrt(l0_x2 + l0_y2);
        l1 = Math.Sqrt(l1_x2 + l1_y2);
        l2 = Math.Sqrt(l2_x2 + l2_y2);
        l3 = Math.Sqrt(l3_x2 + l3_y2);
        l4 = Math.Sqrt(l4_x2 + l4_y2);
        l5 = Math.Abs(cycle_head_new.z - hand.position.z);
        l6 = Math.Sqrt(l3_x2 + l3_y2 + l6_z2);
        double l1_ls = Math.Sqrt(Math.Pow(hand.position.x - low_hand.position.x, 2) + Math.Pow(hand.position.y - low_hand.position.y, 2) + Math.Pow(hand.position.z - low_hand.position.z, 2));
        double l2_ls = Math.Sqrt(Math.Pow(point.position.x - low_hand.position.x, 2) + Math.Pow(point.position.y - low_hand.position.y, 2) + Math.Pow(point.position.z - low_hand.position.z, 2));
        Debug.Log(l1_ls - l1 + "   sl1");
        Debug.Log(l2_ls - l2 + "  sl2");
        double cos_a2 = (l6 * l6 - l1 * l1 - l2 * l2) / (2 * l1 * l2);
        a2 = (float)(Math.Acos(cos_a2) * (180 / Math.PI));
        double cos_a3 = (l2 * l2 - l6 * l6 - l1 * l1) / (-2 * l6 * l1);
        a3 = (float)(Math.Acos(cos_a3) * (180 / Math.PI));
        double cos_a4 = (l4 * l4 - l3 * l3 - l0 * l0) / (-2 * l3 * l0);
        a4 = (float)(Math.Acos(cos_a4) * (180 / Math.PI));
        double cos_a6 = (l5 * l5 - l3 * l3 - l6 * l6) / (-2 * l6 * l3);
        a6 = (float)(Math.Acos(cos_a6) * (180 / Math.PI));

        if (cycle_head.name == "left")
        {
            // hand.parent= static_parameter.root.parent;
            a6 = hand.position.z > cycle_head_new.z ? a6 : -a6;
            hand.Rotate(0, 0, a4);
            hand.Rotate(0, a6, 0);
            hand.Rotate(0, -a3, 0);
            low_hand.Rotate(0, a2, 0);
            Vector3 zz_xl = point.GetChild(1).position - point.GetChild(1).GetChild(1).position;//中指平齐向量

            Vector3 zz_cz_xl = -utils.cal_cz(zz_xl);
            Vector3 sz_xl = point.position- point.GetChild(1).position;//手掌向量
            Vector3 other = sz_xl + zz_cz_xl;

            float sz_xl_length = sz_xl.magnitude;
            float zz_cz_xl_length = zz_cz_xl.magnitude;
            float other_length = other.magnitude;
            double cos_a8 = (other_length * other_length - zz_cz_xl_length * zz_cz_xl_length - sz_xl_length * sz_xl_length) / (-2 * sz_xl_length * zz_cz_xl_length);
            a8 = -(float)(Math.Acos(cos_a8) * (180 / Math.PI));
            point.Rotate(0,0, a8);

            zz_xl = -(point.GetChild(1).position - point.GetChild(1).GetChild(1).position);//中指平齐向量
            Vector3 sz_cz_xl = -utils.cal_cz(sz_xl);//手掌垂直向量
            other = sz_cz_xl - zz_xl;



            float zz_xl_length = zz_xl.magnitude;
            other_length = other.magnitude;
            float sz_cz_xl_length = sz_cz_xl.magnitude;

            double cos_a9 = (other_length * other_length - zz_xl_length * zz_xl_length - sz_cz_xl_length * sz_cz_xl_length) / (-2 * sz_cz_xl_length * zz_xl_length);
            a9 = (float)(Math.Acos(cos_a9) * (180 / Math.PI));
            point.Rotate(a9, 0, 0);


            sz_xl = -(point.position - point.GetChild(1).position);
            Vector3 cz_cycle_head = -utils.cal_cycle_head_cz(cycle_head,sz_length);
            other = sz_xl - cz_cycle_head;

             sz_xl_length = sz_xl.magnitude;
             float cz_cycle_head_length = cz_cycle_head.magnitude;
             other_length = other.magnitude;
        
             double cos_a10 = (other_length * other_length - cz_cycle_head_length * cz_cycle_head_length - sz_xl_length * sz_xl_length) / (-2 * sz_xl_length * cz_cycle_head_length);

              a10 = -(float)(Math.Acos(cos_a10) * (180 / Math.PI));
              point.Rotate(new Vector3(0, a10, 0),Space.World);




              flag.left_hand_rotate = true;
        }

        else
        {


            a6 = hand.position.z > cycle_head.position.z ? a6 : -a6;
            hand.Rotate(0, 0, -a4);

            hand.Rotate(0, a6, 0);

            hand.Rotate(0, a3, 0);

            low_hand.Rotate(0, -a2, 0);

            Vector3 zz_xl = point.GetChild(1).position - point.GetChild(1).GetChild(1).position;//中指平齐向量

            Vector3 zz_cz_xl = -utils.cal_cz(zz_xl);
            Vector3 sz_xl =-(point.position - point.GetChild(1).position);//手掌向量
            Vector3 other = sz_xl -zz_cz_xl;

            float sz_xl_length = sz_xl.magnitude;
            float zz_cz_xl_length = zz_cz_xl.magnitude;
            float other_length = other.magnitude;
            double cos_a8 = (other_length * other_length - zz_cz_xl_length * zz_cz_xl_length - sz_xl_length * sz_xl_length) / (-2 * sz_xl_length * zz_cz_xl_length);
            a8 = (float)(Math.Acos(cos_a8) * (180 / Math.PI));
            point.Rotate(0, 0, a8);

            sz_xl =point.GetChild(1).position-point.position;//方向向前
            zz_xl = point.GetChild(1).position - point.GetChild(1).GetChild(1).position;//中指平齐向量，方向向左
            Vector3 sz_cz_xl = utils.cal_cz(sz_xl);//手掌垂直向量
            if (sz_cz_xl.z < 0)
                sz_cz_xl = -sz_cz_xl;
            other = sz_cz_xl - zz_xl;



            float zz_xl_length = zz_xl.magnitude;
            other_length = other.magnitude;
            float sz_cz_xl_length = sz_cz_xl.magnitude;

            double cos_a9 = (other_length * other_length - zz_xl_length * zz_xl_length - sz_cz_xl_length * sz_cz_xl_length) / (-2 * sz_cz_xl_length * zz_xl_length);
            a9 = (float)(Math.Acos(cos_a9) * (180 / Math.PI));
            point.Rotate(a9, 0, 0);


            sz_xl = point.GetChild(1).position - point.position;//方向向前
            Vector3 cz_cycle_head = -utils.cal_cycle_head_cz(cycle_head, sz_length);
            
            other = sz_xl - cz_cycle_head;

            sz_xl_length = sz_xl.magnitude;
            float cz_cycle_head_length = cz_cycle_head.magnitude;
            other_length = other.magnitude;

            double cos_a10 = (other_length * other_length - cz_cycle_head_length * cz_cycle_head_length - sz_xl_length * sz_xl_length) / (-2 * sz_xl_length * cz_cycle_head_length);

            if(sz_xl.z<cz_cycle_head.z)
                a10 = -(float)(Math.Acos(cos_a10) * (180 / Math.PI));
            else
             a10 = (float)(Math.Acos(cos_a10) * (180 / Math.PI));
            point.Rotate(0, a10, 0);

            flag.right_hand_rotate = true;

        }
        rotate_point = GameObject.Find("rotate_point").transform;
        rotate_point.position = new Vector3(static_parameter.root.GetChild(1).position.x, 0, static_parameter.root.GetChild(1).position.z);
        static_parameter.human.parent = rotate_point;
        static_parameter.root.parent = rotate_point;

        rotate_point.RotateAround(rotate_point.position, new Vector3(0, 1, 0), -static_parameter.count_b);
        static_parameter.root.parent = rotate_point.parent;
        static_parameter.human.parent = rotate_point.parent;

        //hand.parent = static_parameter.root.parent;
        //hand.Rotate(new Vector3(0, 90, 0));
    }
    public void rotate_robot_3_reset()
    {
        if (cycle_head.name == "left")
        {
            point.Rotate(0,-a10, 0);
            point.Rotate(-a9, 0, 0);
            point.Rotate(0, 0, -a8);

            low_hand.Rotate(0, -a2, 0);
            hand.Rotate(0, a3, 0);
            hand.Rotate(0, -a6, 0);
            hand.Rotate(0, 0, -a4);
            flag.left_hand_rotate = true;
        }

        else
        {
            point.Rotate(0, -a10, 0);
            point.Rotate(-a9, 0, 0);
            point.Rotate(0, 0, -a8);

            low_hand.Rotate(0, a2, 0);
            hand.Rotate(0, -a3, 0);
            hand.Rotate(0, -a6, 0);
            hand.Rotate(0, 0, a4);
            flag.right_hand_rotate = true;

        }
    }
}
