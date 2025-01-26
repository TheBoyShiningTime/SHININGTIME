using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody2D _rigidbody;
    
    [Header("Information")]
    [SerializeField] float maxHp;
    [SerializeField] float nowHp;
    [SerializeField] float att;
    public float speed;
    public float attRange;

    

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SetEnemyStatus(100,100,10,2);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SetEnemyStatus(float _hp, float _nowHp, float _att, float _speed)
    {
        maxHp = _hp;
        nowHp = _nowHp;
        att = _att;
        speed = _speed;
    }
    
}
