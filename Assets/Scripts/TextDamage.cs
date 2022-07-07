using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDamage : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.rotation = player.transform.rotation;
    }
}
