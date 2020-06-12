using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//物理更新模块，施加力,自行车移动，车轮旋转等；
public class move : MonoBehaviour
{
    private float speed = 0.001f;
    // public Transform right_small_lap;
    //public Transform right_big_lap;
    //public Transform left_small_lap;
    // public Transform left_big_lap;
    public Transform root;
    private float b_count = 0f;
    private void FixedUpdate1()
    {
        //DateTime t = DateTime.Now;
        static_parameter.speed_inputField.text = Math.Round(static_parameter.V, 3) + "";
        // Debug.Log(t.ToString("yyyMMddhhmmssfff"));
        //为第一帧需要初始化速度
        if (flag.is_init_V == false)
        {
            static_parameter.s_last = new Vector3(static_parameter.root.position.x * 0.01f - speed * 0.02f, static_parameter.root.position.y * 0.01f, static_parameter.root.position.z * 0.01f);
            flag.is_init_V = true;
        }
        float back_r = float.Parse(static_parameter.ahead_wheel_r.text);
        static_parameter.P = float.Parse(static_parameter.power_inputField.text);
        static_parameter.s_now = static_parameter.root.position * 0.01f;
        static_parameter.human_now = static_parameter.human.position.x * 0.01f;
        if (flag.cyclehead_is_start_rotate == false)
        {
            static_parameter.V = (static_parameter.s_now - static_parameter.s_last).magnitude / 0.02f;
        }
        if (flag.cyclehead_is_finish_rotate == true)
        {
            static_parameter.V = (static_parameter.s_now - static_parameter.s_last).magnitude / 0.02f;
        }
        static_parameter.speed_slider.value = static_parameter.V;
        // Debug.Log(static_parameter.V);

        if (static_parameter.scene_dropdown.value <= 2)
        {
            // 当处于拐角处
            if (static_parameter.root.GetChild(0).position.x > 2000 & flag.is_rotate == false)
            {
                if (static_parameter.root.GetChild(1).position.x < 2000)
                {
                    float ls_a = utils.cal_a();
                    static_parameter.ls_a = ls_a;
                    float ls_head_y = static_parameter.root.GetChild(1).position.y;
                    static_parameter.human.parent = static_parameter.root;
                    float root_X = static_parameter.root.transform.GetChild(1).position.x;
                    float root_Z = static_parameter.root.transform.GetChild(1).position.z;

                    switch (static_parameter.scene_dropdown.value)
                    {
                        case 0:
                            static_parameter.root.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, 1f), ls_a - static_parameter.last_a);
                            static_parameter.human.parent = static_parameter.root.parent;
                            static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                            static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                            break;
                        case 1:
                            static_parameter.root.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, 1f), ls_a - static_parameter.last_a);
                            static_parameter.human.parent = static_parameter.root.parent;
                            static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                            static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                            break;
                        case 2:
                            static_parameter.ls_a = static_parameter.ls_a * -1;
                            static_parameter.root.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, -1f), ls_a - static_parameter.last_a);
                            static_parameter.human.parent = static_parameter.root.parent;
                            static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, -(ls_a - static_parameter.last_a), 0));
                            static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, -(ls_a - static_parameter.last_a), 0));
                            break;
      
                    }


                    ////static_parameter.human.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, 1f), ls_a - static_parameter.last_a);
                    ///- static_parameter.root.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, 1f), ls_a - static_parameter.last_a);
                    ////static_parameter.root.transform.Translate(new Vector3(0, ls_head_y- static_parameter.root.GetChild(1).position.y, 0));
                    // // static_parameter.human.transform.Translate(new Vector3(0, ls_head_y - static_parameter.root.GetChild(1).position.y, 0));
                    static_parameter.human.parent = static_parameter.root.parent;
                    //- static_parameter.right_small_leg.parent = static_parameter.right_big_leg;
                    //   Debug.Log("上坡旋转人和车后小腿角度-0.8:" + utils.getls(static_parameter.right_small_leg));
                    //   Debug.Log("上坡旋转人和车后大腿角度-0.8:" + utils.getls(static_parameter.right_big_leg));
                    //- static_parameter.right_small_leg.parent = static_parameter.right_big_leg.parent;
                    ///-  static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                    ///-  static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                    static_parameter.last_a = ls_a;

                    //Debug.Log("上坡旋转人和车后feet0:" + static_parameter.right_small_leg.GetChild(0).position);A
                    //Debug.Log("上坡旋转人和车后pedal0:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);Q
                }
                else
                {
                    flag.is_rotate = true;
                    static_parameter.a = static_parameter.vertical_a;
                }
            }
            //施加力  旋转踏板
            if (((static_parameter.s_now - static_parameter.s_last).magnitude > 0.000001))
            {
                float s = utils.cal_force();
                //Debug.Log("力：" + utils.cal_force());
                // Debug.Log("施加力前feet0.1:" + static_parameter.right_small_leg.GetChild(0).position);
                //Debug.Log("施加力前pedal0.1:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);
                static_parameter.s_last = static_parameter.s_now;
                //施加力
                if (flag.is_rotate == false)//当在后轮还在平路上
                {
                    static_parameter.human.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100, 0, 0), ForceMode.Force);
                    root.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100, 0, 0), ForceMode.Force);
                }

                //后轮不在平路上
                else
                {
                    if (flag.is_changespeed_direction == false)
                    {
                        static_parameter.root.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(root.gameObject.GetComponent<Rigidbody>().velocity.x * (float)Math.Cos(Math.PI * static_parameter.vertical_a / 180), root.gameObject.GetComponent<Rigidbody>().velocity.x * (float)Math.Sin(Math.PI * static_parameter.vertical_a / 180), 0);
                        ///static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(root.gameObject.GetComponent<Rigidbody>().velocity.x * (float)Math.Cos(Math.PI * static_parameter.vertical_a / 180), root.gameObject.GetComponent<Rigidbody>().velocity.x * (float)Math.Sin(Math.PI * static_parameter.vertical_a / 180), 0);
                        static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = static_parameter.root.gameObject.GetComponent<Rigidbody>().velocity;
                        flag.is_changespeed_direction = true;
                    }

                    root.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100 * (float)Math.Cos(Math.PI * static_parameter.vertical_a / 180), utils.cal_force() * 100 * (float)Math.Sin(Math.PI * static_parameter.vertical_a / 180), 0), ForceMode.Force);
                    static_parameter.human.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100 * (float)Math.Cos(Math.PI * static_parameter.vertical_a / 180), utils.cal_force() * 100 * (float)Math.Sin(Math.PI * static_parameter.vertical_a / 180), 0), ForceMode.Force);


                }
                //  Debug.Log("施加力后转踏板前feet0.2:" + static_parameter.right_small_leg.GetChild(0).position);
                // Debug.Log("施加力后旋转踏板前pedal0.2:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);
                //旋转踏板
                if (static_parameter.P != 0)
                {
                    static_parameter.root.GetChild(5).transform.Rotate(new Vector3(0, (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                }
                // Debug.Log("施加力后转踏板后feet0.2:" + static_parameter.right_small_leg.GetChild(0).position);
                // Debug.Log("施加力后旋转踏板后pedal0.2:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);
                static_parameter.root.GetChild(0).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_ahead), 0));
                static_parameter.root.GetChild(1).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                static_parameter.rotate_all = static_parameter.rotate_all + (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back);
            }
            else
            {
                root.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            //static_parameter.right_big_leg.GetComponent<lap_rotate>().lap_rotate_update2();
            //static_parameter.left_big_leg.GetComponent<lap_rotate>().lap_rotate_update2();
            static_parameter.right_big_leg.GetComponent<lap_rotate>().rotate();
            static_parameter.left_big_leg.GetComponent<lap_rotate>().rotate();
        }
        if (static_parameter.scene_dropdown.value == 3)
        {
            // 当处于拐角处及后面
            if (static_parameter.root.GetChild(0).position.x > 2000 - static_parameter.ahead_wheel_r_slider.value)
            {
                root.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                // 处于拐角处
                if (b_count<30)
                {
                    ///  float ls_a = utils.cal_a();
                    ///  static_parameter.ls_a = ls_a;
                    /// float ls_head_y = static_parameter.root.GetChild(1).position.y;
                    ///static_parameter.human.parent = static_parameter.root;
                    /// float root_X = static_parameter.root.transform.GetChild(1).position.x;
                    ///float root_Z = static_parameter.root.transform.GetChild(1).position.z;
                    ///
                    if (flag.cyclehead_is_start_rotate == false)
                    {

                        Transform cycle_head = static_parameter.root.GetChild(4);//车头
                        static_parameter.root.GetChild(0).parent = cycle_head;

                        Transform yao = static_parameter.human.GetChild(2).GetChild(3);

                        cycle_head.Rotate(0, 0, -static_parameter.left_a);//旋转车头
                        Transform ahead_wheel = cycle_head.GetChild(2);//车轮
                        ahead_wheel.parent = static_parameter.root;
                        ahead_wheel.SetAsFirstSibling();
                        flag.cyclehead_is_start_rotate = true;
                        //充值手臂
                        //static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate>().rotate_robot_reset();
                        // static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate>().rotate_robot_reset();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3_reset();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3_reset();
                        //手臂重新握车把手
                        //static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate>().rotate_robot_2();
                        // static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate>().rotate_robot_2();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                        ///-yao.parent = static_parameter.human.GetChild(2);
                        ///
                    }
                    Transform rotate_point = GameObject.Find("rotate_point").transform;
                    rotate_point.position = new Vector3(static_parameter.root.GetChild(1).position.x, 0, static_parameter.root.GetChild(1).position.z);
                    static_parameter.human.parent = rotate_point;
                    static_parameter.root.parent = rotate_point;
                    float r = (float)(static_parameter.cycle_l/ (Math.Tan(static_parameter.left_a / 180f * Math.PI)));
                    float b = (float)(static_parameter.V*0.02*180/ r/Math.PI);
                    b_count = b_count + b;
                    static_parameter.count_b = b_count;
                    Debug.Log("r:======" + r+"v:===="+ static_parameter.V+ "b_count;====="+ b_count+"o:===="+ new Vector3((float)(rotate_point.position.x - r * Math.Sin(b_count / 180 * Math.PI) * 100), 0, (float)(rotate_point.position.z + r * Math.Cos(b_count / 180 * Math.PI) * 100)));
                    rotate_point.RotateAround(new Vector3((float)(rotate_point.position.x - r * Math.Sin(b_count / 180 * Math.PI)*100), 0, (float)(rotate_point.position.z + r * Math.Cos(b_count / 180 * Math.PI)*100)), new Vector3(0, -1, 0), b);
                   static_parameter.root.parent = rotate_point.parent;
                    static_parameter.human.parent = rotate_point.parent;


                }
                //完成转弯
                else
                {
                    int s = 4;
                    //自行车转弯完成摆正车头
                    if(flag.cyclehead_is_finish_rotate==false)
                    {
                        Transform cycle_head = static_parameter.root.GetChild(4);//车头
                        static_parameter.root.GetChild(0).parent = cycle_head;

                        cycle_head.Rotate(0, 0, static_parameter.left_a);//旋转车头
                        Transform ahead_wheel = cycle_head.GetChild(2);//车轮
                        ahead_wheel.parent = static_parameter.root;
                        ahead_wheel.SetAsFirstSibling();
                        flag.cyclehead_is_finish_rotate = true;
                        //充值手臂
                        //static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate>().rotate_robot_reset();
                       // static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate>().rotate_robot_reset();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3_reset();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3_reset();
                        //手臂重新握车把手
                        //static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate>().rotate_robot_2();
                       // static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate>().rotate_robot_2();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                    }
               //改变速度方向
                    root.gameObject.GetComponent<Rigidbody>().velocity = new Vector3((float)(static_parameter.V*100 * Math.Cos(b_count / 180 * Math.PI)), 0, (float)(static_parameter.V*100 * Math.Sin(b_count / 180 * Math.PI)));
                    static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = new Vector3((float)(static_parameter.V *100* Math.Cos(b_count / 180 * Math.PI)), 0, (float)(static_parameter.V *100* Math.Sin(b_count / 180 * Math.PI)));
                    //施加力
                    {
                        static_parameter.human.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100*(float)(Math.Cos(static_parameter.left_road_a)), 0, utils.cal_force() * 100 * (float)(Math.Sin(static_parameter.left_road_a))), ForceMode.Force);
                        root.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100 * (float)(Math.Cos(static_parameter.left_road_a)), 0, utils.cal_force() * 100 * (float)(Math.Sin(static_parameter.left_road_a))), ForceMode.Force);
                    }
                }

                //旋转踏板
                if (static_parameter.P != 0)
                {
                    static_parameter.root.GetChild(5).transform.Rotate(new Vector3(0, (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                }
                //旋转车轮
                static_parameter.root.GetChild(0).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_ahead), 0));
                static_parameter.root.GetChild(1).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                static_parameter.rotate_all = static_parameter.rotate_all + (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back);

            }
            //转弯前
            else
            {
                float s = utils.cal_force();
                //Debug.Log("力：" + utils.cal_force());
                // Debug.Log("施加力前feet0.1:" + static_parameter.right_small_leg.GetChild(0).position);
                //Debug.Log("施加力前pedal0.1:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);
                static_parameter.s_last = static_parameter.s_now;
                //施加力
                if (flag.is_rotate == false)//当在后轮还在平路上
                {
                    static_parameter.human.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100, 0, 0), ForceMode.Force);
                    root.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100, 0, 0), ForceMode.Force);
                }

                //旋转踏板
                if (static_parameter.P != 0)
                {
                    static_parameter.root.GetChild(5).transform.Rotate(new Vector3(0, (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                }
                //旋转车轮
                static_parameter.root.GetChild(0).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_ahead), 0));
                static_parameter.root.GetChild(1).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                static_parameter.rotate_all = static_parameter.rotate_all + (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back);
            }
            static_parameter.right_big_leg.GetComponent<lap_rotate>().rotate();
            static_parameter.left_big_leg.GetComponent<lap_rotate>().rotate();
        }


    }
    private void FixedUpdate()
    {
        //DateTime t = DateTime.Now;
        static_parameter.speed_inputField.text = Math.Round(static_parameter.V, 3) + "";
        // Debug.Log(t.ToString("yyyMMddhhmmssfff"));
        //为第一帧需要初始化速度
        if (flag.is_init_V == false)
        {
            static_parameter.s_last = new Vector3(static_parameter.root.position.x * 0.01f - speed * 0.02f, static_parameter.root.position.y * 0.01f, static_parameter.root.position.z * 0.01f);
            flag.is_init_V = true;
        }
        float back_r = float.Parse(static_parameter.ahead_wheel_r.text);
        static_parameter.P = float.Parse(static_parameter.power_inputField.text);
        static_parameter.s_now = static_parameter.root.position* 0.01f;
        static_parameter.human_now = static_parameter.human.position.x * 0.01f;
        if (flag.cyclehead_is_start_rotate == false)
        {
            static_parameter.V = (static_parameter.s_now-static_parameter.s_last).magnitude / 0.02f;
        }
        if (flag.cyclehead_is_finish_rotate == true)
        {
            static_parameter.V = (static_parameter.s_now - static_parameter.s_last).magnitude / 0.02f;
        }
        static_parameter.speed_slider.value = static_parameter.V;
        // Debug.Log(static_parameter.V);

        if (static_parameter.scene_dropdown.value <= 2)
        {
            // 当处于拐角处
            if (static_parameter.root.GetChild(0).position.x > 2000 & flag.is_rotate == false)
            {
                if (static_parameter.root.GetChild(1).position.x < 2000)
                {
                    float ls_a = utils.cal_a();
                    static_parameter.ls_a = ls_a;
                    float ls_head_y = static_parameter.root.GetChild(1).position.y;
                    static_parameter.human.parent = static_parameter.root;
                    float root_X = static_parameter.root.transform.GetChild(1).position.x;
                    float root_Z = static_parameter.root.transform.GetChild(1).position.z;

                    switch (static_parameter.scene_dropdown.value)
                    {
                        case 0:
                            static_parameter.root.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, 1f), ls_a - static_parameter.last_a);
                            static_parameter.human.parent = static_parameter.root.parent;
                            static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                            static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                            break;
                        case 1:
                            static_parameter.root.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, 1f), ls_a - static_parameter.last_a);
                            static_parameter.human.parent = static_parameter.root.parent;
                            static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                            static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                            break;
                        case 2:
                            static_parameter.ls_a = static_parameter.ls_a * -1;
                            static_parameter.root.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, -1f), ls_a - static_parameter.last_a);
                            static_parameter.human.parent = static_parameter.root.parent;
                            static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, -(ls_a - static_parameter.last_a), 0));
                            static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, -(ls_a - static_parameter.last_a), 0));
                            break;

                    }


                    ////static_parameter.human.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, 1f), ls_a - static_parameter.last_a);
                    ///- static_parameter.root.transform.RotateAround(new Vector3(root_X, 0, root_Z), new Vector3(0, 0, 1f), ls_a - static_parameter.last_a);
                    ////static_parameter.root.transform.Translate(new Vector3(0, ls_head_y- static_parameter.root.GetChild(1).position.y, 0));
                    // // static_parameter.human.transform.Translate(new Vector3(0, ls_head_y - static_parameter.root.GetChild(1).position.y, 0));
                    static_parameter.human.parent = static_parameter.root.parent;
                    //- static_parameter.right_small_leg.parent = static_parameter.right_big_leg;
                    //   Debug.Log("上坡旋转人和车后小腿角度-0.8:" + utils.getls(static_parameter.right_small_leg));
                    //   Debug.Log("上坡旋转人和车后大腿角度-0.8:" + utils.getls(static_parameter.right_big_leg));
                    //- static_parameter.right_small_leg.parent = static_parameter.right_big_leg.parent;
                    ///-  static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                    ///-  static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, ls_a - static_parameter.last_a, 0));
                    static_parameter.last_a = ls_a;

                    //Debug.Log("上坡旋转人和车后feet0:" + static_parameter.right_small_leg.GetChild(0).position);A
                    //Debug.Log("上坡旋转人和车后pedal0:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);Q
                }
                else
                {
                    flag.is_rotate = true;
                    static_parameter.a = static_parameter.vertical_a;
                }
            }
            //施加力  旋转踏板
            if (((static_parameter.s_now - static_parameter.s_last).magnitude > 0.000001))
            {
                float s = utils.cal_force();
                //Debug.Log("力：" + utils.cal_force());
                // Debug.Log("施加力前feet0.1:" + static_parameter.right_small_leg.GetChild(0).position);
                //Debug.Log("施加力前pedal0.1:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);
                static_parameter.s_last = static_parameter.s_now;
                //施加力
                if (flag.is_rotate == false)//当在后轮还在平路上
                {
                    static_parameter.human.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100, 0, 0), ForceMode.Force);
                    root.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100, 0, 0), ForceMode.Force);
                }

                //后轮不在平路上
                else
                {
                    if (flag.is_changespeed_direction == false)
                    {
                        static_parameter.root.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(root.gameObject.GetComponent<Rigidbody>().velocity.x * (float)Math.Cos(Math.PI * static_parameter.vertical_a / 180), root.gameObject.GetComponent<Rigidbody>().velocity.x * (float)Math.Sin(Math.PI * static_parameter.vertical_a / 180), 0);
                        ///static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(root.gameObject.GetComponent<Rigidbody>().velocity.x * (float)Math.Cos(Math.PI * static_parameter.vertical_a / 180), root.gameObject.GetComponent<Rigidbody>().velocity.x * (float)Math.Sin(Math.PI * static_parameter.vertical_a / 180), 0);
                        static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = static_parameter.root.gameObject.GetComponent<Rigidbody>().velocity;
                        flag.is_changespeed_direction = true;
                    }

                    root.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100 * (float)Math.Cos(Math.PI * static_parameter.vertical_a / 180), utils.cal_force() * 100 * (float)Math.Sin(Math.PI * static_parameter.vertical_a / 180), 0), ForceMode.Force);
                    static_parameter.human.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100 * (float)Math.Cos(Math.PI * static_parameter.vertical_a / 180), utils.cal_force() * 100 * (float)Math.Sin(Math.PI * static_parameter.vertical_a / 180), 0), ForceMode.Force);


                }
                //  Debug.Log("施加力后转踏板前feet0.2:" + static_parameter.right_small_leg.GetChild(0).position);
                // Debug.Log("施加力后旋转踏板前pedal0.2:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);
                //旋转踏板
                if (static_parameter.P != 0)
                {
                    static_parameter.root.GetChild(5).transform.Rotate(new Vector3(0, (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                }
                // Debug.Log("施加力后转踏板后feet0.2:" + static_parameter.right_small_leg.GetChild(0).position);
                // Debug.Log("施加力后旋转踏板后pedal0.2:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);
                static_parameter.root.GetChild(0).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_ahead), 0));
                static_parameter.root.GetChild(1).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                static_parameter.rotate_all = static_parameter.rotate_all + (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back);
            }
            else
            {
                root.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            //static_parameter.right_big_leg.GetComponent<lap_rotate>().lap_rotate_update2();
            //static_parameter.left_big_leg.GetComponent<lap_rotate>().lap_rotate_update2();
            static_parameter.right_big_leg.GetComponent<lap_rotate>().rotate();
            static_parameter.left_big_leg.GetComponent<lap_rotate>().rotate();
        }
        if (static_parameter.scene_dropdown.value == 3)
        {
            // 当处于拐角处及后面
            if (static_parameter.root.GetChild(0).position.x > 2000 - static_parameter.ahead_wheel_r_slider.value)
            {
                root.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                // 处于拐角处
                if (b_count < 30)
                {

                    if (flag.cyclehead_is_start_rotate == false)
                    {

                        Transform cycle_head = static_parameter.root.GetChild(4);//车头
                        static_parameter.root.GetChild(0).parent = cycle_head;

                        Transform yao = static_parameter.human.GetChild(2).GetChild(3);
                        //.Rotate(0, -static_parameter.left_a, 0);
                        ///----yao.parent = cycle_head;

                        cycle_head.Rotate(0, 0, -static_parameter.left_a);//旋转车头
                        Transform ahead_wheel = cycle_head.GetChild(2);//车轮
                        ahead_wheel.parent = static_parameter.root;
                        ahead_wheel.SetAsFirstSibling();
                        flag.cyclehead_is_start_rotate = true;
                        //充值手臂
                          static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3_reset();
                         static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3_reset();
                        //手臂重新握车把手
                        /// static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate>().rotate_robot_2();
                        // /static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate>().rotate_robot_2();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                        ///-yao.parent = static_parameter.human.GetChild(2);
                        ///
                    }
                    Transform rotate_point = GameObject.Find("rotate_point").transform;
                    rotate_point.position = new Vector3(static_parameter.root.GetChild(1).position.x, 0, static_parameter.root.GetChild(1).position.z);
                    static_parameter.human.parent = rotate_point;
                    static_parameter.root.parent = rotate_point;
                    float r = (float)(static_parameter.cycle_l / (Math.Tan(static_parameter.left_a / 180f * Math.PI)));
                    float b = (float)(static_parameter.V * 0.02 * 180 / r / Math.PI);
                    b_count = b_count + b;
                    static_parameter.count_b = b_count;
                    Debug.Log("r:======" + r + "v:====" + static_parameter.V + "b_count;=====" + b_count + "o:====" + new Vector3((float)(rotate_point.position.x - r * Math.Sin(b_count / 180 * Math.PI) * 100), 0, (float)(rotate_point.position.z + r * Math.Cos(b_count / 180 * Math.PI) * 100)));
                    rotate_point.RotateAround(new Vector3((float)(rotate_point.position.x - r * Math.Sin(b_count / 180 * Math.PI) * 100), 0, (float)(rotate_point.position.z + r * Math.Cos(b_count / 180 * Math.PI) * 100)), new Vector3(0, -1, 0), b);
                    static_parameter.root.parent = rotate_point.parent;
                    static_parameter.human.parent = rotate_point.parent;


                }
                //完成转弯
                else
                {
                    //自行车转弯完成摆正车头
                    if (flag.cyclehead_is_finish_rotate == false)
                    {
                        static_parameter.root.GetChild(0).parent = static_parameter.root.GetChild(4);
                        static_parameter.root.GetChild(3).Rotate(0, 0, static_parameter.left_a);//旋转车头
                        Transform ls = static_parameter.root.GetChild(3).GetChild(2);
                        ls.parent = static_parameter.root;
                        ls.SetAsFirstSibling();
                        flag.cyclehead_is_finish_rotate = true;
                        //充值手臂
                        ///static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate>().rotate_robot_reset();
                        /// static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate>().rotate_robot_reset();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3_reset();
                        static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3_reset();
                        //手臂重新握车把手
                         static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                         static_parameter.human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                    }
                    //改变速度方向
                    root.gameObject.GetComponent<Rigidbody>().velocity = new Vector3((float)(static_parameter.V * 100 * Math.Cos(b_count / 180 * Math.PI)), 0, (float)(static_parameter.V * 100 * Math.Sin(b_count / 180 * Math.PI)));
                    static_parameter.human.gameObject.GetComponent<Rigidbody>().velocity = new Vector3((float)(static_parameter.V * 100 * Math.Cos(b_count / 180 * Math.PI)), 0, (float)(static_parameter.V * 100 * Math.Sin(b_count / 180 * Math.PI)));
                    //施加力
                    {
                        static_parameter.human.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100 * (float)(Math.Cos(static_parameter.left_road_a)), 0, utils.cal_force() * 100 * (float)(Math.Sin(static_parameter.left_road_a))), ForceMode.Force);
                        root.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100 * (float)(Math.Cos(static_parameter.left_road_a)), 0, utils.cal_force() * 100 * (float)(Math.Sin(static_parameter.left_road_a))), ForceMode.Force);
                    }

                }

                //旋转踏板
                if (static_parameter.P != 0)
                {
                    static_parameter.root.GetChild(5).transform.Rotate(new Vector3(0, (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                }
                //旋转车轮
                static_parameter.root.GetChild(0).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_ahead), 0));
                static_parameter.root.GetChild(1).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                static_parameter.rotate_all = static_parameter.rotate_all + (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back);

            }
            //转弯前
            else
            {
                float s = utils.cal_force();
                //Debug.Log("力：" + utils.cal_force());
                // Debug.Log("施加力前feet0.1:" + static_parameter.right_small_leg.GetChild(0).position);
                //Debug.Log("施加力前pedal0.1:" + static_parameter.root.GetChild(5).GetChild(2).GetChild(0).position);

                //施加力
                if (flag.is_rotate == false)//当在后轮还在平路上
                {
                    static_parameter.human.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100, 0, 0), ForceMode.Force);
                    root.GetComponent<Rigidbody>().AddForce(new Vector3(utils.cal_force() * 100, 0, 0), ForceMode.Force);
                }

                //旋转踏板
                if (static_parameter.P != 0)
                {
                    static_parameter.root.GetChild(5).transform.Rotate(new Vector3(0, (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(0).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                    static_parameter.root.GetChild(5).GetChild(2).GetChild(0).Rotate(new Vector3(0, -(float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                }
                //旋转车轮
                static_parameter.root.GetChild(0).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_ahead), 0));
                static_parameter.root.GetChild(1).transform.Rotate(new Vector3(0, (float)(3.6f * static_parameter.V / Math.PI / static_parameter.r_back), 0));
                static_parameter.rotate_all = static_parameter.rotate_all + (float)(static_parameter.back_head_rate * 3.6f * static_parameter.V / Math.PI / static_parameter.r_back);
            }
            static_parameter.right_big_leg.GetComponent<lap_rotate>().rotate();
            static_parameter.left_big_leg.GetComponent<lap_rotate>().rotate();
            static_parameter.s_last = static_parameter.s_now;
        }
    }
}


