using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{   
    [SerializeField] float distance = 1f;
    public GameObject fpp;
    public GameObject tpp;
    void Start()
    {
    
    }

    
    void FixedUpdate()
    {
        transform.position = tpp.transform.position - tpp.transform.forward * distance;
        transform.forward = tpp.transform.position - transform.position;
    }
    
}
