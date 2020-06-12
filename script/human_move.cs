using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class human_move : MonoBehaviour
{

    public float speed = 3.0F;//速度


    public GameObject Hip_L;
    public GameObject Hip_R;
    public float rotateSpeed = 3.0F;

    private Transform tran;

    private Animator m_animator;

    CharacterController controller;
    Vector3 getRotation(Transform transform1)
    {
        System.Type transformType = transform1.GetType();

        PropertyInfo m_propertyInfo_rotationOrder = transformType.GetProperty("rotationOrder", BindingFlags.Instance | BindingFlags.NonPublic);

        object m_OldRotationOrder = m_propertyInfo_rotationOrder.GetValue(transform1, null);

        MethodInfo m_methodInfo_GetLocalEulerAngles = transformType.GetMethod("GetLocalEulerAngles", BindingFlags.Instance | BindingFlags.NonPublic);

        object value = m_methodInfo_GetLocalEulerAngles.Invoke(transform1, new object[] { m_OldRotationOrder });

        //Debug.Log("反射调用GetLocalEulerAngles方法获得的值：" + value.ToString());

        string temp = value.ToString();

        //将字符串第一个和最后一个去掉

        temp = temp.Remove(0, 1);

        temp = temp.Remove(temp.Length - 1, 1);

        //用‘，’号分割

        string[] tempVector3;

        tempVector3 = temp.Split(',');

        //将分割好的数据传给Vector3

        Vector3 vector3 = new Vector3(float.Parse(tempVector3[0]), float.Parse(tempVector3[1]), float.Parse(tempVector3[2]));
        return vector3;
    }


    void Start()
    {

        tran = gameObject.GetComponent<Transform>();

        m_animator = gameObject.GetComponent<Animator>();

        controller = GetComponent<CharacterController>();

    }



    void Update()
    {



        float h = Input.GetAxis("Horizontal");//返回-1到1的实数值，可以来构造向量

        float v = Input.GetAxis("Vertical");//竖直方向



        transform.Rotate(0, h * rotateSpeed, 0);//AD键水平旋转



        Vector3 forward = transform.TransformDirection(Vector3.forward);//这是将世界坐标系变为局部坐标系，和controller.SimpleMove(forward * curSpeed);

        //对应不然人转向之后，向前走还是侧起走



        float curSpeed = speed * v;



        //竖直方向，按下WS键，人物播放向前走动画，并前进。

        if (Mathf.Abs(v) > 0.1)//判断是否按下键WS

        {


            m_animator.speed =1f;
            if (Input.GetKey(KeyCode.W))

                tran.Translate(Vector3.forward * 0.1f);

           else if (Input.GetKey(KeyCode.S))

                tran.Translate(Vector3.back * 0.1f);
            Debug.Log("L" + getRotation(Hip_L.transform));
            Debug.Log("L_Z" + getRotation(Hip_L.transform.GetChild(0).transform));
        }

        else

        {
           
            Vector3 Hip_L_Rotation = getRotation(Hip_L.transform);
            Vector3 Hip_R_Rotation = getRotation(Hip_R.transform);
            if((-2.855 - Hip_L_Rotation.z<=0.1)& (-1.505 - Hip_R_Rotation.z <= 0.1))
            {
                m_animator.speed = 0f;

            }
        }



    }

}

