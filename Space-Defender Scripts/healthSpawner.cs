using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class healthSpawner : MonoBehaviour
{
    public GameObject healthPack;
    void Awake()
    {

    }
    void OnDestroy()
    {
        Instantiate(healthPack, new Vector2(transform.position.x, transform.position.y), new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w));
    }
}
