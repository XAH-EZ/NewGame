using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float FixSpeed = 5f;
    [SerializeField] float FixSens = 1f;
    [SerializeField] float FixSensHead = 1f;
    [SerializeField] float FixSensBody = 1f;
    [SerializeField] float FixJump = 6f;
    [SerializeField] ForceMode forceMode;
    [SerializeField] ForceMode forceModeJump;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject mainCam;
    public Animator animatorLegs;
    public Animator animatorHandRight;
    public Animator animatorHandLeft;
    public Animator animatorHands;
    
    Rigidbody rb;
    GameObject head;
    GameObject body;
    public Quaternion savePosition;
    
    float _forward;
    float _sideways;
    float mouse;
    float turn_x;
    float turn_y;
    float turn_body_y;
    float mouseX;
    float mouseY;
    float mouseBody;
    float vY;
    float timeJump;
    float timeJumpAnim;
    int ch, chL, _cam1;
    bool camActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        head = GameObject.Find("Head");
        body = GameObject.Find("Body");
        
    }

    void FixedUpdate()
    {
        if(!(Input.GetKey(KeyCode.LeftAlt)))
        {
        mouse = Input.GetAxis("Mouse X");
        rb.rotation *= Quaternion.AngleAxis(mouse * FixSens, Vector3.up);

        //Head
        mouseX = Input.GetAxis("Mouse Y");
        if (mouseX < 0)
        {
            if(turn_x <= 45)
            turn_x += Mathf.Abs(mouseX)*FixSensHead;
        }
        if (mouseX > 0)
        {
            if(turn_x >= -45)
            turn_x -= Mathf.Abs(mouseX)*FixSensHead;
        }
        if(!camActive)
        {
        mouseY = Input.GetAxis("Mouse X");
        if (mouseY > 0)
        {
            if(turn_y <= 15)
            turn_y += Mathf.Abs(mouseY)*FixSensHead;
        }
        if (mouseY < 0)
        {
            if(turn_y >= -15)
            turn_y -= Mathf.Abs(mouseY)*FixSensHead;
        }
        }
        head.transform.localRotation = Quaternion.Euler(turn_x, 0, turn_y);

        //Body
        mouseBody = Input.GetAxis("Mouse Y");
        if (mouseBody < 0)
        {
            if(turn_body_y <= 45)
            turn_body_y += Mathf.Abs(mouseBody)*FixSensBody;
        }
        if (mouseBody > 0)
        {
            if(turn_body_y >= -45)
            turn_body_y -= Mathf.Abs(mouseBody)*FixSensBody;
        }
        body.transform.localRotation = Quaternion.Euler(turn_body_y - 90, 0, 0);
           }

        _forward = Input.GetAxis("Vertical");
        _sideways = Input.GetAxis("Horizontal");
        rb.AddForce(rb.rotation * new Vector3(_sideways * FixSpeed, 0, _forward * FixSpeed), forceMode);
        animatorLegs.SetFloat("Walk", _forward);
        animatorHands.SetFloat("Walk", _forward);
        
    }
    void Update()
    {
        //Jump
        vY = Mathf.Abs(rb.velocity.y);
        timeJump -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && vY <= 0.2 && timeJump <= 0)
        {   
            animatorLegs.SetTrigger("Jump");
            animatorHands.SetTrigger("Jump");
            rb.AddForce(Vector3.up * FixJump, forceModeJump);
            timeJump = 1.5f;
        }
        

        if(!(Input.GetKey(KeyCode.LeftAlt)))
        {
        savePosition = head.transform.rotation;
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            _cam1 += 1;
        }
        if(_cam1 == 1)
        {
            mainCam.SetActive(false);
            cam1.SetActive(true);
        }
        if(_cam1 == 2)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            camActive = true;
            turn_y = 0;
        }
        if(_cam1 == 3)
        {
            cam2.SetActive(false);
            cam3.SetActive(true);
            camActive = false;
        }
        if(_cam1 == 4)
        {
            cam3.SetActive(false);
            mainCam.SetActive(true);
            _cam1 = 0;
        }
    
    }
     
}
