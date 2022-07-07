using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;

public class Inv : MonoBehaviour
{
    public TextMeshProUGUI weaponInfo;
    public GameObject holdHand;
    public GameObject swordholster1;
    public GameObject swordholster2;
    public GameObject swordholster3;
    public LootEventZone looteventzone1;
    public LootEventZone looteventzone2;
    public Animator anim_getWeapon;
    public AudioSource takeSword;
    Attack attack;

    GameObject givelootHand;
    GameObject givelootBack;
    GameObject hand, handW1, handW2, handW3;

    SwordAttackController SAController;
    public HandAttackController HAControllerLeft, HAControllerRight;

    bool holsterFull;
    bool item1, item2, item3;
    bool handFull_1, handFull_2, handFull_3;
    public bool handFull;
    bool getComp = false;

    int T1, T2, T3, TH;

    public event Action<int> SwitchItem;
    public event Action<bool> HandFull;
    
    void Start()
    {
        attack = transform.root.GetComponent<Attack>();
        swordholster1 = GameObject.Find("skeleton_2/SwordHolster1/holster1Empty");
        swordholster2 = GameObject.Find("skeleton_2/Body/SwordHolster2/holster2Empty");
        swordholster3 = GameObject.Find("skeleton_2/Body/SwordHolster3/holster3Empty");
        hand = GameObject.Find("skeleton_2/Body/Hands/ShoulderRight/ForeArmRight/BrushRight/HandWhit");
        handW1 = GameObject.Find("skeleton_2/Body/Hands/ShoulderRight/ForeArmRight/BrushRight/HandWhit1/item1");
        handW2 = GameObject.Find("skeleton_2/Body/Hands/ShoulderRight/ForeArmRight/BrushRight/HandWhit2/item2");
        handW3 = GameObject.Find("skeleton_2/Body/Hands/ShoulderRight/ForeArmRight/BrushRight/HandWhit3/item3");

        looteventzone1.TakeLoot += lootevent_takeloot;
        looteventzone2.TakeLoot += lootevent_takeloot;
        SwitchItem += take_switchItem;
        weaponInfo.text = "No weapon";
    }

    void Update()
    {
            
        if(Input.GetKeyDown(KeyCode.Alpha1) && item1 && !handFull_1)
        {
            // T1 += 1;
            // SwitchItem.Invoke(T1);
            HandFull.Invoke(true);
            anim_getWeapon.SetTrigger("TakeW1");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && item2 && !handFull_2)
        {
            // T2 += 1;
            // SwitchItem.Invoke(T2);
            HandFull.Invoke(true);
            anim_getWeapon.SetTrigger("TakeW2");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && item3 && !handFull_3)
        {
            // T3 += 1;
            // SwitchItem.Invoke(T3);
            HandFull.Invoke(true);
            anim_getWeapon.SetTrigger("TakeW3");
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            // TH += 1;
            //SwitchItem.Invoke(4);
            HandFull.Invoke(false);
            if(handFull_1)
            anim_getWeapon.SetTrigger("DownW1");
            
            if(handFull_2)
            anim_getWeapon.SetTrigger("DownW2");

            if(handFull_3)
            anim_getWeapon.SetTrigger("DownW3");

        }
        
    }
    public void PermissionAttackViaInventory()
    {
        attack.PermissionAttack();
    }

    public void OnColliderViaAnimator()
    {
        SAController.OnCollider();
    }

    public void OffColliderViaAnimator()
    {
        SAController.OffCollider();
    }

    public void OnColliderViaAnimatorForHands()
    {
        HAControllerLeft.OnCollider();
        HAControllerRight.OnCollider();
    }

    public void OffColliderViaAnimatorForHands()
    {
        HAControllerLeft.OffCollider();
        HAControllerRight.OffCollider();
    }

    private void lootevent_takeloot(GameObject receivedloot)
    {
        givelootBack = Instantiate(receivedloot);
        givelootBack.name = receivedloot.name;

        givelootHand = Instantiate(receivedloot);

        if(!holsterFull)
        {
        givelootBack.transform.position = swordholster2.transform.position;
        givelootBack.transform.rotation = swordholster2.transform.rotation;
        givelootBack.transform.SetParent(swordholster2.transform);
        swordholster2 = givelootBack;

        givelootHand.transform.position = handW2.transform.position;
        givelootHand.transform.rotation = handW2.transform.rotation;
        givelootHand.transform.SetParent(handW2.transform);
        handW2 = givelootHand;
        givelootHand.name = "Weapon2";
        handW2.SetActive(false);

        holsterFull = true;
        item2 = true;
        }
        else
        {
        givelootBack.transform.position = swordholster3.transform.position;
        givelootBack.transform.rotation = swordholster3.transform.rotation;
        givelootBack.transform.SetParent(swordholster3.transform);
        swordholster3 = givelootBack;

        givelootHand.transform.position = handW3.transform.position;
        givelootHand.transform.rotation = handW3.transform.rotation;
        givelootHand.transform.SetParent(handW3.transform);
        handW3 = givelootHand;
        givelootHand.name = "Weapon3";
        handW3.SetActive(false);
        item3 = true;
        }
    }

    public void GiveLoot(GameObject obj1, GameObject obj2)
    {
        obj1.transform.position = swordholster1.transform.position;
        obj1.transform.rotation = swordholster1.transform.rotation;
        obj1.transform.SetParent(swordholster1.transform);
        swordholster1 = obj1;

        obj2.transform.position = handW1.transform.position;
        obj2.transform.rotation = handW1.transform.rotation;
        obj2.transform.SetParent(handW1.transform);
        handW1 = obj2;
        handW1.SetActive(false);
        item1 = true;
    }

    private void take_switchItem(int a)
    {
        if(a == 1)
        {
            takeSword.Play();
            SAController = handW1.GetComponent<SwordAttackController>();
            handW1.SetActive(true);

            if(item2) 
            handW2.SetActive(false);

            if(item3)
            handW3.SetActive(false);

            swordholster1.SetActive(false);
            swordholster2.SetActive(true);
            swordholster3.SetActive(true);

            handFull_1 = true;
            handFull_2 = false;
            handFull_3 = false;

            handFull = true;
            //T1 = 0;
            weaponInfo.text = "First sword";
            
        }
        if(a == 2)
        {
            takeSword.Play();
            SAController = handW2.GetComponent<SwordAttackController>();
            
            if(item1)
            handW1.SetActive(false);

            handW2.SetActive(true);

            if(item3)
            handW3.SetActive(false);

            swordholster1.SetActive(true);
            swordholster2.SetActive(false);
            swordholster3.SetActive(true);
            handFull_1 = false;
            handFull_2 = true;
            handFull_3 = false;

            handFull = true;
            weaponInfo.text = "Second sword";
            //T2 = 0;
            
        }
        if(a == 3)
        {
            takeSword.Play();
            SAController = handW3.GetComponent<SwordAttackController>();

            if(item1)
            handW1.SetActive(false);

            handW2.SetActive(false);

            handW3.SetActive(true);

            swordholster1.SetActive(true);
            swordholster2.SetActive(true);
            swordholster3.SetActive(false);

            handFull_1 = false;
            handFull_2 = false;
            handFull_3 = true;

            handFull = true;
            weaponInfo.text = "Third sword";
            //T3 = 0;
            
        }
        if(a == 4 && (handFull_1 || handFull_2 || handFull_3))
        {
            
            handW1.SetActive(false);
            if(item2)
            {
            handW2.SetActive(false);
            }
            if(item3)
            {
            handW3.SetActive(false);
            }
            swordholster1.SetActive(true);
            swordholster2.SetActive(true);
            swordholster3.SetActive(true);

            handFull_1 = false;
            handFull_2 = false;
            handFull_3 = false;

            handFull = false;
            weaponInfo.text = "No weapon";
            // T1 = 0;
            // T2 = 0;
            // T3 = 0;
            // TH = 0;
        }

    }

}
