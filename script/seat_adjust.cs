using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seat_adjust : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform seat_down;
    public Transform seat;
    public InputField seat_adjust_inputField;
    void Start()
    {
        
    }
   public Vector3 set_seat()
    {
        seat_down.localScale = seat_down.localScale + new Vector3(0, 0, 1 / 3.5f * float.Parse(seat_adjust_inputField.text));
        Vector3 seat_move =  seat_down.GetChild(0).position- seat.position;
        seat.position = seat_down.GetChild(0).position;
        return seat_move;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
