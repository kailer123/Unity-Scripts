using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESP32Script : MonoBehaviour
{
    private void Update()
    {
        transform.position += transform.up * 10 * Time.deltaTime;

        if (transform.position.y < -100 || transform.position.y > 100 || transform.position.x < -100 || transform.position.x > 100)
        {
            Destroy(this.gameObject);
        }
    }
}
