using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackController : MonoBehaviour
{
    private Attack attack;
    private Collider bladeCol;

    private void Start()
    {
        attack = transform.root.GetComponent<Attack>();
        bladeCol = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        LogEnem logEnem;
        logEnem = col.gameObject.GetComponent<LogEnem>();
        if(logEnem != null && attack.IsAttack)
        {
        attack.FinishAttack();    
        logEnem.TakeKick();
        }
    }
    public void OffCollider()
    {
        bladeCol.enabled = false;
    }
    public void OnCollider()
    {
        bladeCol.enabled = true;
    }
}
