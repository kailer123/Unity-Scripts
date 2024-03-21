using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float _health = 100;

    private void Update()
    {
        _health = Mathf.Clamp(_health, 0, 100);
    }
}
