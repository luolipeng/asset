using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag : MonoBehaviour
{
    public static bool confirm_flag=false;
    public static bool scale_isinit_flag=false;
    public static bool is_init_V = false;
    public static bool zero_P = false;
    public static bool is_rotate = false;
    public static bool is_changespeed_direction=false;
    public static bool left_2_is_conlider = false;
    public static bool left_21_is_conlider = false;
    public static bool left_22_is_conlider = false;
    public static bool left_hand_rotate = false;
    public static bool right_hand_rotate = false;
    public static bool cyclehead_is_start_rotate = false;

    public static bool cyclehead_is_finish_rotate = false;
    public static Dictionary<string, bool> figure_flag = new Dictionary<string, bool>();
    public static Dictionary<string, bool> figure_isfinish = new Dictionary<string, bool>();
}

