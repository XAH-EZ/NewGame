using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    
    [SerializeField] float FixSens = 1f;
    Move move;
    GameObject head;
    
    float turn_x;
    float turn_y;
    float mouseX;
    float mouseY;
    void Start()
    {
        move = FindObjectOfType<Move>();
        head = GameObject.Find("Head");
    }
    void FixedUpdate()
    {
        
    if(Input.GetKey(KeyCode.LeftAlt))
    {
        Rotate();
    }
    void Rotate()
    {
        mouseX = Input.GetAxis("Mouse Y");
        if (mouseX < 0)
        {
            if(turn_x >= -45)
            turn_x += mouseX*FixSens;
        }
        if (mouseX > 0)
        {
            if(turn_x <= 45)
            turn_x += mouseX*FixSens;
        }
        mouseY = Input.GetAxis("Mouse X");
        if (mouseY > 0)
        {
            if(turn_y <= 60)
            turn_y += Mathf.Abs(mouseY)*FixSens;
        }
        if (mouseY < 0)
        {
            if(turn_y >= -60)
            turn_y -= Mathf.Abs(mouseY)*FixSens;
        }
        head.transform.localRotation = Quaternion.Euler(-turn_x, 0, turn_y);
    }

    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            turn_x = 0;
            turn_y = 0;
            head.transform.rotation = move.savePosition;
        }
    }        
}
