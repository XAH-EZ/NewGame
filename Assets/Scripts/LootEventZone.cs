using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LootEventZone : MonoBehaviour
{
    public GameObject loottake;
    public GameObject lootFake;
    bool colliderR;

    public event Action<GameObject> TakeLoot;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && colliderR && lootFake != null)
        {
            TakeLoot.Invoke(loottake);
            Destroy(lootFake);
            lootFake = null;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        colliderR = true;
    }
    void OnTriggerExit(Collider col)
    {
        colliderR = false;
    }

}
