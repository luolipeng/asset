using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class leg_height : MonoBehaviour
{
    public Text text;
    private float height;
    void Start()
    {
        if (text.text == "")
            height = 176;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
