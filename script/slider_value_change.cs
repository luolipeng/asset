using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slider_value_change : MonoBehaviour
{
    // Start is called before the first frame update
   public void height_change()
    {
        float height = (float)(static_parameter.height_slider.value);
        static_parameter.human.localScale = new Vector3(height / 1.8f, height / 1.8f, height / 1.8f);
    }
    public void seat_change()
    {
        Transform seat = static_parameter.root.GetChild(6);
        Transform seat_down = static_parameter.root.GetChild(8);
        seat_down.localScale =new Vector3(1, 1,1+static_parameter.seat_adjust_slider.value/4.491f);
        Vector3 seat_move = seat_down.GetChild(0).position - seat.position;
        seat.position = seat_down.GetChild(0).position;
        if(static_parameter.humanis_pose.isOn==true)
        {
            static_parameter.human.Translate(seat_move, Space.World);
        }
        //return seat_move;
  
    }
    public void wheel_change()
    {
        Vector3 change_last = static_parameter.root.position;
        Transform ahead_wheel = static_parameter.root.GetChild(0);
        ahead_wheel.localScale = new Vector3(0.92458f+(static_parameter.ahead_wheel_r_slider.value - 35f) / 35f, 1, 0.92458f + (static_parameter.ahead_wheel_r_slider.value - 35f) / 35f);
        Transform back_wheel = static_parameter.root.GetChild(1);
        back_wheel.localScale = new Vector3(0.92458f + (static_parameter.ahead_wheel_r_slider.value - 35f) / 35f, 1, 0.92458f + (static_parameter.ahead_wheel_r_slider.value - 35f) / 35f);
        static_parameter.root.position = new Vector3(static_parameter.root.position.x, static_parameter.ahead_wheel_r_slider.value - 35f, static_parameter.root.position.z);
        Vector3 change_now = static_parameter.root.position;
        if (static_parameter.humanis_pose.isOn == true)
        {
            static_parameter.human.Translate(change_now-change_last, Space.World);
        }
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
        Transform yao = human.GetChild(2).GetChild(3);
        yao.Rotate(30, 0, 0);
        yao.GetChild(0).Rotate(30, 0, 0);
        Transform left_hand = human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
        left_hand.Rotate(0, 90, -40);

        Transform right_hand = human.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetChild(2).GetChild(0);
        right_hand.Rotate(0, -90, 40);

        Vector3 offset= human.GetChild(2).GetChild(2).position-static_parameter.root.GetChild(6).GetChild(0).position;
        static_parameter.human.Translate(-offset,Space.World);
    }

}
