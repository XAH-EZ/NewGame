using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagnit : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movement;
    public GameObject player;
    public float speed = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.AddForce((player.transform.position - transform.position)*speed);
    }
}
