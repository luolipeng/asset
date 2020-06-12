using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//每一帧更新模块
public class update_all : MonoBehaviour
{

    public float distanceUp = 15f;
    public float distanceAway = 10f;
    public float smooth = 2f;//位置平滑移动值
    public float camDepthSmooth = 5f;
    public Transform camera1;
    private void Start()
    {
        camera1 = GameObject.Find("scene_all_object").transform.GetChild(0);
    }
    private  void update_input()
    {
        static_parameter.speed_inputField.text = static_parameter.speed_slider.value+"";
        static_parameter.seat_adjust_inputField.text = static_parameter.seat_adjust_slider.value + "";
        static_parameter.height_inputField.text = static_parameter.height_slider.value + "";
        static_parameter.power_inputField.text = static_parameter.power_slider.value + "";
        static_parameter.ahead_wheel_r.text = static_parameter.ahead_wheel_r_slider.value + "";
        
        static_parameter.road_down_a.text = static_parameter.road_down_a_slider.value + "";
        static_parameter.road_up_a.text = static_parameter.road_up_a_slider.value + "";
    }
    private void Scale()
    {
        float dis = static_parameter.offset.magnitude;
        dis += Input.GetAxis("Mouse ScrollWheel") * 5;
       // Debug.Log("dis=" + dis);
       
        static_parameter.offset = static_parameter.offset.normalized * dis;
    }
    //左右上下移动
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            
            Vector3 pos = camera1.position;
            Vector3 rot = camera1.eulerAngles;

            //围绕原点旋转，也可以将Vector3.zero改为 target.position,就是围绕观察对象旋转
            float sd_x= Input.GetAxis("Mouse X") * 10;
            float sd_y = Input.GetAxis("Mouse Y") * 10;
            Debug.Log("x=" + sd_x);
            Debug.Log("y=" + sd_y);
             if (Math.Abs(sd_x)-Math.Abs(sd_y)>0)
            {
                camera1.RotateAround(static_parameter.root.position, camera1.up, Input.GetAxis("Mouse X"));
            }
            else
             {
                camera1.RotateAround(static_parameter.root.position, -camera1.right, Input.GetAxis("Mouse Y"));
            }
          
            float x = camera1.eulerAngles.x;
            float y = camera1.eulerAngles.y;
           // Debug.Log("x=" + x);
            //Debug.Log("y=" + y);
            //控制移动范围

            //  更新相对差值
            static_parameter.offset = camera1.position - static_parameter.root.position;
        }
    }
    void Update()
       {
        //更新输入域
        update_input();
        // 相机跟随
        // if (flag.confirm_flag)
        if (true)
        {

           GameObject.Find("scene_all_object").transform.GetChild(0).position = static_parameter.root.position + static_parameter.offset;
            Rotate();
            Scale();
        }



    //    //更新腿部发力颜色
    //    if (flag.confirm_flag)
    //    {
    //        Material mat_right = static_parameter.right_small_leg.GetComponent<Renderer>().material;
    //        Material mat_left = static_parameter.left_small_leg.GetComponent<Renderer>().material;
    //        //腿部用力
    //        if (flag.zero_P==false)
    //        {

        //            if (static_parameter.rotate_all % 360 > 180)
        //            {
        //                mat_right.color = new Color(1, 1, 1, 1);
        //                mat_left.color = new Color(2 - Math.Abs(270 - static_parameter.rotate_all % 360) / 60, 0.2f, 0.2f, 1);
        //            }

        //            else
        //            {
        //                mat_right.color = new Color(2 - Math.Abs(90 - static_parameter.rotate_all % 360) / 60, 0.2f, 0.2f, 1);
        //                mat_left.color = new Color(1, 1, 1, 1);
        //            }
        //        }
        //        //腿部停止发力
        //        else
        //        {
        //            mat_right.color = new Color(1, 1, 1, 1);
        //            mat_left.color = new Color(1, 1, 1, 1);
        //        }
        //    }
    }
}
