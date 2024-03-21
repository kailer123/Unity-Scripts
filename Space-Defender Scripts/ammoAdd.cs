using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoAdd : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    magazine mag;
    void Awake()
    {
        player = GameObject.FindWithTag("XDD");
        mag = player.GetComponent<magazine>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "XDD")
        {
            mag.leftInMag += 7;
            Destroy(gameObject);
        }
    }
}
