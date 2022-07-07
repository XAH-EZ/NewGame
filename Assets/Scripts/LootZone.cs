using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootZone : MonoBehaviour
{
    public GameObject loottake;
    public GameObject lootFake;
    GameObject givelootHand;
    GameObject givelootBack;
    Inv inv;
    bool colliderR;
    void Start()
    {
        inv = FindObjectOfType<Inv>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && colliderR && lootFake != null)
        {
        givelootBack = Instantiate(loottake);
        givelootBack.name = loottake.name;
        givelootHand = Instantiate(loottake);
        givelootHand.name = "Weapon1";
        inv.GiveLoot(givelootBack, givelootHand);
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
