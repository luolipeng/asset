using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class init_human : MonoBehaviour
{
    // Start is called before the first frame updatedy
    ///+public Transform body;
    public Transform right_hand;
    public Transform left_hand;
    public Transform right_big_leg;
    //public Transform right_small_leg;
   // public Transform right_null_object;
    public Transform left_big_leg;
    //public Transform left_small_leg;
   // public Transform left_null_object;
    public Transform human;
    public InputField power_inputField;
    public Text height_text;
    public InputField seat_adjust_inputField;
    public InputField speed_inputField;
    public Dropdown scene_dropdown;
    public InputField height_inputField;
    public InputField ahead_wheel_r;
    public InputField road_up_a;
    public InputField road_down_a;
    public Toggle humanis_pose;
    private int leg_height;
    //public bool flag = false;
    public Transform root;
    void Start()
    {
       
        static_parameter.road_up_a_slider = road_up_a.transform.parent.GetChild(1).GetComponent<Slider>();
        static_parameter.road_down_a_slider = road_down_a.transform.parent.GetChild(1).GetComponent<Slider>();
        static_parameter.ahead_wheel_r_slider = ahead_wheel_r.transform.parent.GetChild(1).GetComponent<Slider>();
        static_parameter.power_slider = power_inputField.transform.parent.GetChild(1).GetComponent<Slider>();
        static_parameter.speed_slider = speed_inputField.transform.parent.GetChild(1).GetComponent<Slider>();
        static_parameter.height_slider = height_inputField.transform.parent.GetChild(1).GetComponent<Slider>();
        static_parameter.seat_adjust_slider= seat_adjust_inputField.transform.parent.GetChild(1).GetComponent<Slider>();
        static_parameter.ahead_wheel_r = ahead_wheel_r;
        static_parameter.power_inputField = power_inputField;
        static_parameter.seat_adjust_inputField= seat_adjust_inputField;
        static_parameter.left_big_leg = left_big_leg;
        static_parameter.right_big_leg = right_big_leg;
        static_parameter.root = root;
        static_parameter.scene_dropdown = scene_dropdown;
        static_parameter.speed_inputField = speed_inputField;
        static_parameter.height_inputField = height_inputField;
        static_parameter.height_text = height_text;
        ///-static_parameter.body = body;
        static_parameter.right_hand = right_hand;
        static_parameter.left_hand = left_hand;
        static_parameter.human = human;
        static_parameter.right_small_leg = right_big_leg.GetChild(0);
        static_parameter.left_small_leg =left_big_leg.GetChild(0);
        static_parameter.road_down_a = road_down_a;
        static_parameter.road_up_a = road_up_a;
        static_parameter.offset = GameObject.Find("scene_all_object").transform.GetChild(0).position - static_parameter.root.position;
        static_parameter.humanis_pose = humanis_pose;

        static_parameter.cycle_l = (static_parameter.root.GetChild(0).position.x - static_parameter.root.GetChild(1).position.x)*0.01f;
        flag.figure_flag.Add("mixamorig:LeftHandMiddle1", false);
        flag.figure_flag.Add("mixamorig:LeftHandMiddle2", false);
        flag.figure_flag.Add("mixamorig:LeftHandMiddle3", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandMiddle1", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandMiddle2", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandMiddle3", false);

        flag.figure_flag.Add("mixamorig:LeftHandIndex1", false);
        flag.figure_flag.Add("mixamorig:LeftHandIndex2", false);
        flag.figure_flag.Add("mixamorig:LeftHandIndex3", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandIndex1", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandIndex2", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandIndex3", false);

        flag.figure_flag.Add("mixamorig:LeftHandPinky1", false);
        flag.figure_flag.Add("mixamorig:LeftHandPinky2", false);
        flag.figure_flag.Add("mixamorig:LeftHandPinky3", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandPinky1", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandPinky2", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandPinky3", false);

        flag.figure_flag.Add("mixamorig:LeftHandRing1", false);
        flag.figure_flag.Add("mixamorig:LeftHandRing2", false);
        flag.figure_flag.Add("mixamorig:LeftHandRing3", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandRing1", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandRing2", false);
        flag.figure_isfinish.Add("mixamorig:LeftHandRing3", false);


        
        flag.figure_flag.Add("mixamorig:RightHandMiddle1", false);
        flag.figure_flag.Add("mixamorig:RightHandMiddle2", false);
        flag.figure_flag.Add("mixamorig:RightHandMiddle3", false);
        flag.figure_isfinish.Add("mixamorig:RightHandMiddle1", false);
        flag.figure_isfinish.Add("mixamorig:RightHandMiddle2", false);
        flag.figure_isfinish.Add("mixamorig:RightHandMiddle3", false);

        flag.figure_flag.Add("mixamorig:RightHandIndex1", false);
        flag.figure_flag.Add("mixamorig:RightHandIndex2", false);
        flag.figure_flag.Add("mixamorig:RightHandIndex3", false);
        flag.figure_isfinish.Add("mixamorig:RightHandIndex1", false);
        flag.figure_isfinish.Add("mixamorig:RightHandIndex2", false);
        flag.figure_isfinish.Add("mixamorig:RightHandIndex3", false);

        flag.figure_flag.Add("mixamorig:RightHandPinky1", false);
        flag.figure_flag.Add("mixamorig:RightHandPinky2", false);
        flag.figure_flag.Add("mixamorig:RightHandPinky3", false);
        flag.figure_isfinish.Add("mixamorig:RightHandPinky1", false);
        flag.figure_isfinish.Add("mixamorig:RightHandPinky2", false);
        flag.figure_isfinish.Add("mixamorig:RightHandPinky3", false);

        flag.figure_flag.Add("mixamorig:RightHandRing1", false);
        flag.figure_flag.Add("mixamorig:RightHandRing2", false);
        flag.figure_flag.Add("mixamorig:RightHandRing3", false);
        flag.figure_isfinish.Add("mixamorig:RightHandRing1", false);
        flag.figure_isfinish.Add("mixamorig:RightHandRing2", false);
        flag.figure_isfinish.Add("mixamorig:RightHandRing3", false);
        static_parameter.power_inputField.onEndEdit.AddListener(delegate
        {
            if (static_parameter.power_inputField.text != null)
            {
                static_parameter.P = float.Parse(static_parameter.power_inputField.text);
               
            }
            if (static_parameter.P==0)
            {
                flag.zero_P = true;
            }
            else
            {
                flag.zero_P = false;
            }
           
        });
    }
    //public void init2(string init_or_reset)
    //{
    //    if (init_or_reset == "init")
    //        重置所有的父物体为场景
    //    {
    //        leg_height = int.Parse(static_parameter.height_inputField.text);
    //    }
    //    else
    //    {
    //        leg_height = 165;
    //    }

    //    right_small_leg.parent = static_parameter.human;
    //    left_small_leg.parent = static_parameter.human;
    //    body.parent = static_parameter.human;

    //    if (flag.scale_isinit_flag == false)
    //    {
    //        static_parameter.big_leg_scale_origin = right_big_leg.localScale;
    //        static_parameter.small_leg_scale_origin = right_small_leg.localScale;
    //        static_parameter.body_scale_origin = body.localScale;
    //        static_parameter.hand_scale_origin = left_hand.localScale;
    //        flag.scale_isinit_flag = true;
    //        static_parameter.r_ahead = float.Parse(static_parameter.ahead_wheel_r.text) * 0.01f;
    //        static_parameter.r_back = float.Parse(static_parameter.back_wheel_r.text) * 0.01f;
    //    }

    //    float scale_ahead_wheel = (float.Parse(static_parameter.ahead_wheel_r.text) - 33.5f) / 33.5f;
    //    root.GetChild(0).localScale = root.GetChild(0).localScale + new Vector3(scale_ahead_wheel, 0, scale_ahead_wheel);
    //    float scale_back_wheel = (float.Parse(static_parameter.back_wheel_r.text) - 33.5f) / 33.5f;
    //    root.GetChild(1).localScale = root.GetChild(1).localScale + new Vector3(scale_back_wheel, 0, scale_back_wheel);

    //    float scale = (leg_height - 165f) / 165f;
    //    right_big_leg.localScale = static_parameter.big_leg_scale_origin + new Vector3(0, static_parameter.big_leg_scale_origin.y * scale, 0);
    //    left_big_leg.localScale = static_parameter.big_leg_scale_origin + new Vector3(0, static_parameter.big_leg_scale_origin.y * scale, 0);
    //    right_small_leg.position = right_null_object.position;
    //    left_small_leg.position = left_null_object.position;
    //    right_small_leg.localScale = static_parameter.small_leg_scale_origin + new Vector3(static_parameter.small_leg_scale_origin.x * scale, 0, 0);
    //    left_small_leg.localScale = static_parameter.small_leg_scale_origin + new Vector3(static_parameter.small_leg_scale_origin.x * scale, 0, 0);
    //    right_small_leg.parent = right_big_leg;
    //    left_small_leg.parent = left_big_leg;
    //    body.localScale = static_parameter.body_scale_origin + new Vector3(0, 0, static_parameter.body_scale_origin.z * scale);
    //    right_hand.position = body.GetChild(0).position;
    //    left_hand.position = body.GetChild(1).position;
    //    Transform right_small_hand = right_hand.GetChild(1);//+
    //    right_small_hand.parent = static_parameter.human; //+
    //    right_hand.localScale = static_parameter.hand_scale_origin + new Vector3(0, 0, static_parameter.hand_scale_origin.z * scale);
    //    right_small_hand.position = right_hand.GetChild(0).position;//+
    //    right_small_hand.localScale = static_parameter.hand_scale_origin + new Vector3(0, 0, static_parameter.hand_scale_origin.z * scale);//+
    //    right_small_hand.parent = right_hand;

    //    Transform left_small_hand = left_hand.GetChild(1);//+
    //    left_small_hand.parent = static_parameter.human; //+
    //    left_hand.localScale = static_parameter.hand_scale_origin + new Vector3(0, 0, static_parameter.hand_scale_origin.z * scale);
    //    left_small_hand.position = left_hand.GetChild(0).position;//+
    //    left_small_hand.localScale = static_parameter.hand_scale_origin + new Vector3(0, 0, static_parameter.hand_scale_origin.z * scale);//+
    //    left_small_hand.parent = left_hand;

    //    static_parameter.root.Translate(new Vector3(0, float.Parse(static_parameter.ahead_wheel_r.text) - 33.5f, 0), Space.World);
    //    static_parameter.human.Translate(new Vector3(0, float.Parse(static_parameter.ahead_wheel_r.text) - 33.5f, 0), Space.World);
    //}
    //public void init2(string init_or_reset)
    //{
    //    if (init_or_reset=="init")
    //    //重置所有的父物体为场景
    //    {
    //        leg_height = int.Parse(static_parameter.height_inputField.text);
    //    }
    //    else
    //    {
    //        leg_height = 165;
    //    }

    //    right_small_leg.parent = static_parameter.human;
    //    left_small_leg.parent = static_parameter.human;
    //    body.parent = static_parameter.human;

    //    if (flag.scale_isinit_flag == false)
    //    {
    //        static_parameter.big_leg_scale_origin = right_big_leg.localScale;
    //        static_parameter.small_leg_scale_origin = right_small_leg.localScale;
    //        static_parameter.body_scale_origin = body.localScale;
    //        static_parameter.hand_scale_origin = left_hand.localScale;
    //        flag.scale_isinit_flag = true;
    //        static_parameter.r_ahead = float.Parse(static_parameter.ahead_wheel_r.text) * 0.01f;
    //        static_parameter.r_back = float.Parse(static_parameter.back_wheel_r.text) * 0.01f;
    //    }

    //    float scale_ahead_wheel = (float.Parse(static_parameter.ahead_wheel_r.text) - 33.5f) / 33.5f;
    //    root.GetChild(0).localScale = root.GetChild(0).localScale + new Vector3(scale_ahead_wheel, 0, scale_ahead_wheel);
    //    float scale_back_wheel = (float.Parse(static_parameter.back_wheel_r.text) - 33.5f) / 33.5f;
    //    root.GetChild(1).localScale = root.GetChild(1).localScale + new Vector3(scale_back_wheel, 0, scale_back_wheel);

    //    float scale = (leg_height - 165f) / 165f;
    //    right_big_leg.localScale = static_parameter.big_leg_scale_origin + new Vector3(0, static_parameter.big_leg_scale_origin.y * scale, 0);
    //    left_big_leg.localScale = static_parameter.big_leg_scale_origin + new Vector3(0, static_parameter.big_leg_scale_origin.y * scale, 0);
    //    right_small_leg.position = right_null_object.position;
    //    left_small_leg.position = left_null_object.position;
    //    right_small_leg.localScale = static_parameter.small_leg_scale_origin + new Vector3(static_parameter.small_leg_scale_origin.x * scale, 0, 0);
    //    left_small_leg.localScale = static_parameter.small_leg_scale_origin + new Vector3(static_parameter.small_leg_scale_origin.x * scale, 0, 0);
    //    right_small_leg.parent = right_big_leg;
    //    left_small_leg.parent = left_big_leg;
    //    body.localScale = static_parameter.body_scale_origin + new Vector3(0, 0, static_parameter.body_scale_origin.z*scale);
    //    right_hand.position = body.GetChild(0).position;
    //    left_hand.position = body.GetChild(1).position;
    //    Transform right_small_hand = right_hand.GetChild(1);//+
    //    right_small_hand.parent = static_parameter.human; //+
    //    right_hand.localScale= static_parameter.hand_scale_origin + new Vector3(0, 0, static_parameter.hand_scale_origin.z * scale);
    //    right_small_hand.position = right_hand.GetChild(0).position;//+
    //    right_small_hand.localScale = static_parameter.hand_scale_origin + new Vector3(0, 0, static_parameter.hand_scale_origin.z * scale);//+
    //    right_small_hand.parent = right_hand;

    //    Transform left_small_hand = left_hand.GetChild(1);//+
    //    left_small_hand.parent = static_parameter.human; //+
    //    left_hand.localScale = static_parameter.hand_scale_origin + new Vector3(0, 0, static_parameter.hand_scale_origin.z * scale);
    //    left_small_hand.position = left_hand.GetChild(0).position;//+
    //    left_small_hand.localScale = static_parameter.hand_scale_origin + new Vector3(0, 0, static_parameter.hand_scale_origin.z * scale);//+
    //    left_small_hand.parent = left_hand;

    //    static_parameter.root.Translate(new Vector3(0, float.Parse(static_parameter.ahead_wheel_r.text) - 33.5f, 0), Space.World);
    //    static_parameter.human.Translate(new Vector3(0,float.Parse(static_parameter.ahead_wheel_r.text) - 33.5f, 0), Space.World);
    //}

}
