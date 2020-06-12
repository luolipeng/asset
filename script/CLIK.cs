using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CLIK : MonoBehaviour
{
    public void parameter_confirm()
    {
        if (static_parameter.height_inputField.text != "")
        {

            if (int.Parse(static_parameter.height_inputField.text) > 100)
            {

                ///- GameObject.Find("body_cycle3").GetComponent<init_human>().init("init");
                //GameObject.Find("left_hand").GetComponent<hand_rotate>().rotate();
                //static_parameter.body.gameObject.GetComponent<init_human>().init("init");
                //Debug.Log(static_parameter.height_inputField.text);
                // Vector3 seat_move = static_parameter.root.GetChild(6).GetComponent<seat_adjust>().set_seat();
                ///-static_parameter.left_hand.parent.position = static_parameter.left_hand.parent.position + seat_move;
                //static_parameter.left_hand.GetComponent<hand_rotate>().rotate_robot_2();

              //  static_parameter.root.GetChild(4).Rotate(new Vector3(0, -10f, 0), Space.World);
                //static_parameter.right_hand.GetComponent<hand_rotate>().rotate_robot_2();
                static_parameter.left_hand.GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                static_parameter.right_hand.GetComponent<hand_rotate_horizontal>().rotate_robot_3();
                static_parameter.right_big_leg.GetComponent<lap_rotate>().enabled = true;
                static_parameter.left_big_leg.GetComponent<lap_rotate>().enabled = true;
                Invoke("confirm_day", 5);
                // static_parameter.root.GetChild(5).GetComponent<back_wheel_rotate>().enabled = true;
                // static_parameter.root.GetChild(0).GetComponent<back_wheel_rotate>().enabled = true;
                // static_parameter.root.GetChild(1).GetComponent<back_wheel_rotate>().enabled = true;

                int s = static_parameter.scene_dropdown.value;
                float vertical_a = 0;
                switch (s)
                {
                    case 0:
                        vertical_a = 0;
                        //   GameObject.Find("road_all").transform.GetChild(1).gameObject.SetActive(false);
                        break;
                    case 1:
                        GameObject.Find("road_all").transform.GetChild(1).gameObject.SetActive(true);
                        vertical_a = float.Parse(static_parameter.road_up_a.text);
                        GameObject.Find("road_all").transform.GetChild(1).Rotate(new Vector3(0, 0 - vertical_a, 0));
                        break;
                    case 2:
                        GameObject.Find("road_all").transform.GetChild(1).gameObject.SetActive(true);

                        vertical_a =0-float.Parse(static_parameter.road_down_a.text);
                        GameObject.Find("road_all").transform.GetChild(1).Rotate(new Vector3(0, 0-vertical_a, 0));
                        break;

                }

                static_parameter.vertical_a = vertical_a;
                Debug.Log(s + "gggggggggg");
                flag.confirm_flag = true;

            }

        }

    }
    //public void parameter_confirm1()
    //{
    //    if (static_parameter.height_inputField.text != "")
    //    {

    //        if (int.Parse(static_parameter.height_inputField.text) > 100)
    //        {

    //            GameObject.Find("body_cycle3").GetComponent<init_human>().init("init");
    //    //GameObject.Find("left_hand").GetComponent<hand_rotate>().rotate();
    //    //static_parameter.body.gameObject.GetComponent<init_human>().init("init");
    //           //Debug.Log(static_parameter.height_inputField.text);
    //            Vector3 seat_move = static_parameter.root.GetChild(6).GetComponent<seat_adjust>().set_seat();
    //            static_parameter.left_hand.parent.position = static_parameter.left_hand.parent.position + seat_move;
    //            static_parameter.left_hand.GetComponent<hand_rotate>().rotate2();
    //            static_parameter.right_hand.GetComponent<hand_rotate>().rotate2();
    //            static_parameter.right_big_leg.GetComponent<lap_rotate>().enabled = true;
    //            static_parameter.left_big_leg.GetComponent<lap_rotate>().enabled = true;
    //            static_parameter.root.GetComponent<move>().enabled = true;
    //            // static_parameter.root.GetChild(5).GetComponent<back_wheel_rotate>().enabled = true;
    //            // static_parameter.root.GetChild(0).GetComponent<back_wheel_rotate>().enabled = true;
    //            // static_parameter.root.GetChild(1).GetComponent<back_wheel_rotate>().enabled = true;

    //            int s = static_parameter.scene_dropdown.value;
    //            float vertical_a = 0;
    //            switch(s)
    //            {
    //                case 0:
    //                    vertical_a = 0;
    //                 //   GameObject.Find("road_all").transform.GetChild(1).gameObject.SetActive(false);
    //                    break;
    //                case 1:
    //                    GameObject.Find("road_all").transform.GetChild(1).gameObject.SetActive(true);
    //                    vertical_a = float.Parse(static_parameter.road_up_a.text);
    //                    GameObject.Find("road_all").transform.GetChild(1).Rotate(new Vector3(0, 0-vertical_a, 0));
    //                    break;
    //                case 2:
    //                    GameObject.Find("road_all").transform.GetChild(1).gameObject.SetActive(true);

    //                    vertical_a =0-float.Parse(static_parameter.road_down_a.text);
    //                    GameObject.Find("road_all").transform.GetChild(1).Rotate(new Vector3(0, 0-vertical_a, 0));
    //                    break;
                        
    //            }

    //            static_parameter.vertical_a = vertical_a;
    //            Debug.Log(s + "gggggggggg");
    //            flag.confirm_flag = true;
               
    //        }

    //    }

    //}
    /// <summary>
     //重置待处理flag
    /// </summary>
    public void parameter_cancel( )
    {
        static_parameter.height_inputField.text = "";
        static_parameter.speed_inputField.text = "";
        static_parameter.ahead_wheel_r.text = "";
        static_parameter.back_wheel_r.text = "";
        static_parameter.power_inputField.text = "";
        static_parameter.road_down_a.text = "";
        static_parameter.road_up_a.text = "";
        static_parameter.scene_dropdown.value = 0;
        static_parameter.seat_adjust_inputField.text = "";
        //GameObject.Find("body").GetComponent<init_human>().init("reset");
         GameObject Prefab = (GameObject)Resources.Load("Prefabs/cycle_human_update");
        GameObject cycle_and_human =Instantiate(Prefab);
        Destroy(static_parameter.root.gameObject);
        Destroy(static_parameter.human.gameObject);
        static_parameter.root = cycle_and_human.transform.GetChild(0);
        static_parameter.human = cycle_and_human.transform.GetChild(1);
        cycle_and_human.transform.GetChild(0).parent = cycle_and_human.transform.parent;
        cycle_and_human.transform.GetChild(0).parent = cycle_and_human.transform.parent;
        Destroy(cycle_and_human);
        utils.init_component();
        flag.confirm_flag = false;
        flag.is_init_V = false;
        //float sds = static_parameter.vertical_a;
        //Debug.Log(float.Parse(static_parameter.road_up_a.text) + "hggggg");
        GameObject.Find("road_all").transform.GetChild(1).Rotate(new Vector3(0, static_parameter.vertical_a, 0));
        GameObject.Find("road_all").transform.GetChild(1).gameObject.SetActive(false);
        


    }

    public void confirm_day()
    {
        static_parameter.root.GetComponent<move>().enabled = true;
    }
    public void test()
    {
        static_parameter.human.GetChild(2).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate>().rotate_robot_2();
    }
    public void open_slow_motion()
    {
        Time.timeScale = 0.1F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    public void close_slow_motion()
    {
        Time.timeScale = 1F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    public void testcz()
    {
        
        static_parameter.human.GetChild(2).GetChild(2).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<hand_rotate>().rotate_robot_reset();
    }
    public void gl()
    {

        GameObject.Find("xbot1").transform.GetChild(0).GetComponent<hight_light>().glcs();
        //GameObject.Find("cubecs").transform.GetComponent<hight_light>().glcs();
    }
}
