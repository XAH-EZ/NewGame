using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogEnem : MonoBehaviour
{
    [SerializeField] ForceMode forceMode;
    Rigidbody rb, rbPlayer;
    MeshRenderer logMaterial;

    public Material normalMat, kickMat, lowkickMat;
    public GameObject player;
    public AudioSource hitSound_1, hitSound_2, hitSound_3;
    public TextMeshProUGUI valueDamage;
    private Animator anim;

    int d;
    bool normalMatOn, switchSound;
    float time;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rbPlayer = player.GetComponent<Rigidbody>();
        logMaterial = GetComponent<MeshRenderer>();
    }
    void FixedUpdate()
    { 
        time -= Time.deltaTime;
        if(time <= 0 && !normalMatOn)
        {
            logMaterial.material = normalMat;
            normalMatOn = true;
        }
    }
    public void TakeKick()
    {
        d = 40;
        valueDamage.text = d.ToString();
        anim.SetTrigger("Show");
        time = 0.8f;
        rb.AddForce(rbPlayer.rotation * Vector3.forward * 25 + Vector3.up * 45, forceMode);
        logMaterial.material = kickMat;
        normalMatOn = false;
        if(!switchSound)
        {
        hitSound_1.Play();
        switchSound = true;
        }
        else
        {
        hitSound_2.Play();
        switchSound = false;
        }
    }
    public void TakeLowKick()
    {
        d = 15;
        valueDamage.text = d.ToString();
        anim.SetTrigger("Show");
        time = 0.5f;
        rb.AddForce(rbPlayer.rotation * Vector3.forward * 15 + Vector3.up * 25, forceMode);
        logMaterial.material = lowkickMat;
        normalMatOn = false;
        hitSound_3.Play();
    }
    
}
