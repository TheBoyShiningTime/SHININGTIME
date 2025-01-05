using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        
        _rigidbody.AddForce(Vector2.right * _horizontal,ForceMode2D.Impulse);
    }
}
