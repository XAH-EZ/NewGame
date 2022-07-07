using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float FixJump = 0.3f;
    [SerializeField] ForceMode forceMode;
    Rigidbody rb;
    public GameObject Skillet;
    bool ground = false;
    void Start()
    {
        rb = Skillet.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && ground)
        {
            rb.AddForce(Vector3.up * FixJump, forceMode);
            ground = false;
        }
        Debug.Log(ground);
    }
    void OnCollisionEnther(Collision col)
    {
        if(col.gameObject.CompareTag("ground"))
        {
            ground = true;
        }
    }
}
