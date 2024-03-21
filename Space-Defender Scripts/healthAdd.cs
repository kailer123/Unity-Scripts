using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthAdd : MonoBehaviour
{
    GameObject player;
    health hp;

    private void Awake()
    {
        player = GameObject.FindWithTag("XDD");
        hp = player.GetComponent<health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "XDD")
        {
            hp._health += 20;
            Destroy(gameObject);
        }
    }
} 
