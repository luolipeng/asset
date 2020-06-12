using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public class utils
{
    public static Vector3 getls(Transform transform1)
    {
        System.Type transformType = transform1.GetType();

        PropertyInfo m_propertyInfo_rotationOrder = transformType.GetProperty("rotationOrder", BindingFlags.Instance | BindingFlags.NonPublic);

        object m_OldRotationOrder = m_propertyInfo_rotationOrder.GetValue(transform1, null);

        MethodInfo m_methodInfo_GetLocalEulerAngles = transformType.GetMethod("GetLocalEulerAngles", BindingFlags.Instance | BindingFlags.NonPublic);

        Vector3 value = (Vector3)m_methodInfo_GetLocalEulerAngles.Invoke(transform1, new object[] { m_OldRotationOrder });

        //Debug.Log("反射调用GetLocalEulerAngles方法获得的值：" + value.ToString());
        float s = value.z;
        Vector3 sd = new Vector3(value.x, value.y, value.z);
        //string temp = value.ToString();

        ////将字符串第一个和最后一个去掉

        //temp = temp.Remove(0, 1);

        //temp = temp.Remove(temp.Length - 1, 1);

        ////用‘，’号分割

        //string[] tempVector3;

        //tempVector3 = temp.Split(',');

        ////将分割好的数据传给Vector3

        // Vector3 vector3 = new Vector3(float.Parse(tempVector3[0]), float.Parse(tempVector3[1]), float.Parse(tempVector3[2]));
        return new Vector3(value.x, value.y, value.z);
    }
    // Start is called before the first frame update
    public static void init_component()
    {
        move Move = static_parameter.root.GetComponent<move>();
        static_parameter.speed_text= static_parameter.speed_inputField.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
       // Move.right_big_lap = static_parameter.human.GetChild(4);
        //Move.right_small_lap = static_parameter.human.GetChild(4).GetChild(1);
       // Move.left_big_lap = static_parameter.human.GetChild(3);
        //Move.left_small_lap = static_parameter.human.GetChild(3).GetChild(1);

        static_parameter.root.GetChild(0).GetComponent<back_wheel_rotate>().textspeed = static_parameter.speed_text;
        static_parameter.root.GetChild(1).GetComponent<back_wheel_rotate>().textspeed = static_parameter.speed_text;
        static_parameter.root.GetChild(5).GetComponent<back_wheel_rotate>().textspeed = static_parameter.speed_text;
        static_parameter.root.GetChild(6).GetComponent<seat_adjust>().seat_adjust_inputField = static_parameter.seat_adjust_inputField;

        Transform human = static_parameter.human;
        //添加组件
 


        init_human Init_human= human.GetChild(0).GetComponent<init_human>();
        Init_human.height_inputField = static_parameter.height_inputField;
        Init_human.height_text = static_parameter.speed_text;
        Init_human.seat_adjust_inputField = static_parameter.seat_adjust_inputField;
        Init_human.speed_inputField = static_parameter.speed_inputField;
        Init_human.scene_dropdown = static_parameter.scene_dropdown;
        Init_human.root = static_parameter.root;

        Init_human.power_inputField = static_parameter.power_inputField;
        Init_human.ahead_wheel_r = static_parameter.ahead_wheel_r;
  
        Init_human.road_up_a = static_parameter.road_up_a;
        Init_human.road_down_a = static_parameter.road_down_a;
        human.GetChild(1).GetComponent<hand_rotate>().cycle_head = static_parameter.root.GetChild(4).GetChild(0);
        human.GetChild(2).GetComponent<hand_rotate>().cycle_head = static_parameter.root.GetChild(4).GetChild(1);
        human.GetChild(3).GetComponent<lap_rotate>().pedal_board = static_parameter.root.GetChild(5).GetChild(0).GetChild(0);
        human.GetChild(4).GetComponent<lap_rotate>().pedal_board = static_parameter.root.GetChild(5).GetChild(2).GetChild(0);
    }
    public static void change_color(Transform tran)
    {
        
         Material mat= tran.GetComponent<Renderer>().material;
      
         float sd=Math.Abs( utils.getls(static_parameter.root.GetChild(5)).x);
         Debug.Log(mat.color);
         mat.color = new Color(1+sd, 0.5f-(90-sd)/180f, 0.5f - (90 - sd) / 180f, 1);
    }
    public static void change_color2(Transform tran)
    {
        Material mat = tran.GetComponent<Renderer>().material;
        float sd = Math.Abs(utils.getls(static_parameter.root.GetChild(5)).x);

        mat.color = new Color(0.5f, 0.01f, 0.01f, 1f);
    }
    public static float cal_force()
    {
        
       // float Fg_sina = static_parameter.M_human_cycle*(float)(Math.Sin(Math.PI * static_parameter.a / 180))*static_parameter.g;
        float Fg_sina = 0;
        float Ff = static_parameter.M_human_cycle * static_parameter.g * (float)(Math.Cos(Math.PI * static_parameter.a / 180))*static_parameter.C_r;
        float Fw = 0.5f * static_parameter.C_d * static_parameter.A * static_parameter.p * static_parameter.V * static_parameter.V;
        float Fd = 1/2f * static_parameter.Cw * static_parameter.p * static_parameter.V * static_parameter.V * (float)(Math.PI * Math.Pow(static_parameter.r_ahead, 2))+ 3 / 8f * static_parameter.Cw * static_parameter.p * static_parameter.V * static_parameter.V * (float)(Math.PI * Math.Pow(static_parameter.r_back, 2));
        //float F = (float)(static_parameter.P * 0.985 /( (static_parameter.s_now - static_parameter.s_last)/0.02 )- Fg_sina - Ff - Fw - Fd);
        float F = (float)static_parameter.P - Fg_sina - Ff - Fw - Fd;
        return F;  
     }
    public static float cal_a()
    {
        //float l3 = static_parameter.root.GetChild(0).position.x - 2000;
        float l3 = 2000 - static_parameter.root.GetChild(1).position.x;
        double l4 =static_parameter.root.GetChild(0).position.x - static_parameter.root.GetChild(1).position.x;
        double x = Math.Sqrt(l4 * l4 -l3*l3+ l3 * l3 * Math.Cos(Math.PI * static_parameter.vertical_a / 180)) - l3 * Math.Cos(Math.PI * static_parameter.vertical_a / 180);
        double cos_a = (x * x - l3 * l3 - l4 * l4) / (-2 * l3 * l4);
        float a =(float)(Math.Acos(cos_a) * (180 / Math.PI));
        return a;
    }
    public static Vector3 cal_cycle_head_new(Transform cycle_head,double sz_length)
    {
        Vector3 cycle_xl = cycle_head.GetChild(0).position - cycle_head.position;
        float b = cycle_xl.x / cycle_xl.z;
        Vector3 cycle_cz_xl = new Vector3(-1, 0, b);
        Vector3 nor_cycle_cz_xl = cycle_cz_xl / cycle_cz_xl.magnitude;
        Vector3 cycle_head_new = cycle_head.position + (float)sz_length * nor_cycle_cz_xl;
        return cycle_head_new;


    }
    public static Vector3 cal_cycle_head_cz(Transform cycle_head, double sz_length)
    {
        Vector3 cycle_xl = cycle_head.GetChild(0).position - cycle_head.position;
        float b = cycle_xl.x / cycle_xl.z;
        Vector3 cycle_cz_xl = new Vector3(-1, 0, b);
        Vector3 nor_cycle_cz_xl = cycle_cz_xl / cycle_cz_xl.magnitude;
        return (float)sz_length * nor_cycle_cz_xl;


    }
    public static Vector3 cal_cz(Vector3 xl)
    {
        float b = xl.x / xl.z;
        Vector3 cz_xl = new Vector3(-1, 0, b);
        return cz_xl;
    }
    public void init_human_pose()
    {
        Transform human = static_parameter.human;
        Transform left_leg = human.GetChild(2).GetChild(0);
        left_leg.Rotate(-90, 0, 0);
        left_leg.GetChild(0).Rotate(90, 0, 0);
        Transform right_leg = human.GetChild(2).GetChild(1);
        right_leg.Rotate(-90, 0, 0);
        right_leg.GetChild(0).Rotate(90, 0, 0);
        Transform yao = human.GetChild(2).GetChild(2);
        yao.Rotate(30, 0, 0);
        yao.GetChild(0).Rotate(30, 0, 0);
        Transform left_hand = human.GetChild(2).GetChild(2).GetChild(1).GetChild(0).GetChild(0);
        left_hand.Rotate(0, 90, -30);

        Transform right_hand = human.GetChild(2).GetChild(2).GetChild(1).GetChild(2).GetChild(0);
        right_hand.Rotate(0, 90, 30);
 

    }
}
