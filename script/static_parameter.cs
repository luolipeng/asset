using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class static_parameter : MonoBehaviour
{

    public static Vector3 big_leg_scale_origin;
    public static Vector3 small_leg_scale_origin;
    public static Vector3 body_scale_origin;
    public static Vector3 hand_scale_origin;
    public static Vector3 right_hand_scale_origin;
    public static Transform right_big_leg;
    public static Transform body;
    public static Transform human;
    public static InputField height_inputField;
    public static InputField seat_adjust_inputField;
    public static Transform left_big_leg;
    public static Transform root;
    public static InputField power_inputField;
    public static InputField speed_inputField;
    public static Dropdown scene_dropdown;
    public static Text height_text;
    public static Text speed_text;
    public static Transform right_hand;
    public static Transform left_hand;
    public static Transform right_small_leg;
    public static Transform left_small_leg;
    public static float rotate_all=0;
    public static InputField ahead_wheel_r;
    public static InputField back_wheel_r;
    public static InputField road_up_a;
    public static InputField road_down_a;
    public static Toggle humanis_pose;

    public static Slider road_up_a_slider;
    public static Slider road_down_a_slider;
    public static Slider ahead_wheel_r_slider;
    public static Slider back_wheel_r_slider;
    public static Slider power_slider;
    public static Slider speed_slider;
    public static Slider height_slider;
    public static Slider seat_adjust_slider;

    public static float P = 0f;//推荐值350
    public static float V0 = 6f;
    public static float Fg;
    public static Vector3 s_last;
    public static Vector3 s_now;
    public static double a=0;
    public static float back_head_rate=0.3f;
    internal static float p=1.226f;
    internal static double r_ahead=0.35;
    internal static double r_back = 0.35;
    public static float M_human_cycle=72;
    internal static float g=9.8f;
    internal static float C_r=0.004f;
    internal static float C_d=0.5f;
    public static float Ir = 0.08f;
    public static float If = 0.08f;
    internal static float A=0.5f;
    internal static float V=0;
    internal static float Cw=0.0397f;
    internal  static float human_last;
    internal static float human_now;
    public static float vertical_a = 0f;
    public static float ls_a = 0f;
    public static float last_a = 0f;
    public static float left_a =10f;
    public static float left_road_a = (float)(30/180*Math.PI);
    public static float cycle_l;
    public static float count_b;

    public static Vector3 offset;

}
