using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] float FixSens = 1f;
    GameObject body;
    float mouse;
    float look;
    bool bodyRot;
    float turn_body_y;
    void Start()
    {
        body = GameObject.Find("Body");
    }
    void FixedUpdate()
    {
        if(!(Input.GetKey(KeyCode.LeftAlt)))
        {
        mouse = Input.GetAxis("Mouse Y");
        if (mouse < 0)
        {
            if(turn_body_y <= 45)
            turn_body_y += Mathf.Abs(mouse)*FixSens;
        }
        if (mouse > 0)
        {
            if(turn_body_y >= -45)
            turn_body_y -= Mathf.Abs(mouse)*FixSens;
        }
        body.transform.localRotation = Quaternion.Euler(turn_body_y - 90, 0, 0);
        }
        
        
    }
}
