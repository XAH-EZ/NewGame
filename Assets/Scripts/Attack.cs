using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : MonoBehaviour
{
    public Animator animatorHands;
    int ch, chL;
    bool sword_on = false;
    private bool _isAttack, permissionOn;
    public Inv inv;
    public event Action<int, int> SwitchAttackHands;
    public event Action<int, int> SwitchAttackSword;

    void Start()
    {
        permissionOn = true;
        inv.HandFull += hand_full_switch;
        SwitchAttackHands += _switch_attack;
        SwitchAttackSword += _switch_attack_sword;
    }
    
    public void PermissionAttack()
    {
        permissionOn = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !sword_on && permissionOn)
        {
            permissionOn = false;
            ch += 1;
            chL += 1;
            SwitchAttackHands.Invoke(ch, chL);
            _isAttack = true;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && sword_on && permissionOn)
        {
            permissionOn = false;
            ch += 1;
            chL += 1;
            SwitchAttackSword.Invoke(ch, chL);
            _isAttack = true;
        }
    
    }

    private void _switch_attack(int a, int b)
    {
        if(a == 1 && b == 1)
        {
            animatorHands.SetTrigger("HitL");
            ch = 0;
        }
        if(a == 1 && b == 2)
        {
            animatorHands.SetTrigger("HitR");
            chL = 0;
            ch = 0;
        }
    }

    private void _switch_attack_sword(int a, int b)
    {
        if(a == 1 && b == 1)
        {
            animatorHands.SetTrigger("HitSword1");
            ch = 0;
        }
        if(a == 1 && b == 2)
        {
            animatorHands.SetTrigger("HitSword2");
            chL = 0;
            ch = 0;
        }
    }
    private void hand_full_switch(bool a)
    {
        sword_on = a;
    }

    public void FinishAttack()
    {
        _isAttack = false;
    }
    
    public bool IsAttack { get => _isAttack;}
}
