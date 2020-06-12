using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hight_light : MonoBehaviour
{
    // Start is called before the first frame update
    private HighlightableObject mho;
    void Start()
    {
        
    }
    private void Awake()
    {
        mho = GetComponent<HighlightableObject>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
     void OnMouseOver()
    {
        mho.ConstantOn(Color.red);
    }
public void glcs()
    {
        mho.ConstantOn(Color.red);
    }
    private void OnMouseExit()
    {
        mho.ConstantOff();
    }
}
