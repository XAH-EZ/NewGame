using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // float mouse;
    // float look;
    // float lookX;
    void FixedUpdate()
    {
        // mouse = Input.GetAxis("Mouse Y");
        // if(look >= -45)
        // {
        //     head.transform.rotation *= Quaternion.AngleAxis(mouse * FixSens, Vector3.left);
        //     look -= Mathf.Abs(mouse) * FixSens;
        // }
        // else
        // {
        //     head.transform.rotation *= Quaternion.AngleAxis(+1, Vector3.left);
        //     look += 1;
        // }
        // if(look <= 45)
        // {
        //     head.transform.rotation *= Quaternion.AngleAxis(mouse * FixSens, Vector3.left);
        //     look += Mathf.Abs(mouse) * FixSens;
        // }
        // else
        // {
        //     head.transform.rotation *= Quaternion.AngleAxis(-1, Vector3.left);
        //     look -= 1;
        // }
        // /* поворот головой по горизонтали */
        // mouse = Input.GetAxis("Mouse X");
        // if(lookX >= -60)
        // {
        //     head.transform.rotation *= Quaternion.AngleAxis(mouse * FixSens, Vector3.up);
        //     lookX += mouse * FixSens;
        // }
        // else
        // {
        //     head.transform.rotation *= Quaternion.AngleAxis(+1, Vector3.up);
        //     lookX += 1;
        // }
        // if(lookX <= 60)
        // {
        //     head.transform.rotation *= Quaternion.AngleAxis(mouse * FixSens, Vector3.up);
        //     lookX += mouse * FixSens;
        // }
        // else
        // {
        //     head.transform.rotation *= Quaternion.AngleAxis(-1, Vector3.up);
        //     lookX -= 1;
        // }
    }
    
}


// [SerializeField] float FixSens = 1f;
//     [SerializeField] Transform Head;
//     float mouse;
//     float look;
//     bool bodyRot;
//     void FixedUpdate()
//     {
//         if(!(Input.GetKey(KeyCode.LeftAlt)))
//         {
//         mouse = Input.GetAxis("Mouse Y");
//         if(look >= -45)
//         {
//             bodyRot = true;
//         }
//         else
//         {
//             bodyRot = false;
//             transform.rotation *= Quaternion.AngleAxis(+1, Vector3.left);
//             Head.transform.rotation *= Quaternion.AngleAxis(+1, Vector3.left);
//             look += 1;
//         }
//         if(look <= 45)
//         {
//             bodyRot = true;
//         }
//         else
//         {
//             bodyRot = false;
//             transform.rotation *= Quaternion.AngleAxis(-1, Vector3.left);
//             Head.transform.rotation *= Quaternion.AngleAxis(-1, Vector3.left);
//             look -= 1;
//         }
//         if(bodyRot)
//         {
//         transform.rotation *= Quaternion.AngleAxis(mouse * FixSens, Vector3.left);
//         Head.transform.rotation *= Quaternion.AngleAxis(mouse * FixSens, Vector3.left);
//         look += mouse * FixSens;
//         }
//         }
        
        
//     }