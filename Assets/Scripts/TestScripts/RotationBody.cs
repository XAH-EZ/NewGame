using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBody : MonoBehaviour
{
    
    [SerializeField] float FixSens = 1f;
    float mouse;
    float look;
    bool bodyRot;
    void FixedUpdate()
    {
        if(look >= -45)
        {
            bodyRot = true;
        }
        else
        {
            bodyRot = false;
            transform.rotation *= Quaternion.AngleAxis(+1, Vector3.left);
            look += 1;
        }
        if(look <= 45)
        {
            bodyRot = true;
        }
        else
        {
            bodyRot = false;
            transform.rotation *= Quaternion.AngleAxis(-1, Vector3.left);
            look -= 1;
        }
        if(bodyRot)
        {
        transform.rotation *= Quaternion.AngleAxis(mouse * FixSens, Vector3.left);
        look += mouse * FixSens;
        }
        

        
        
    }

    
    
    
    
}
