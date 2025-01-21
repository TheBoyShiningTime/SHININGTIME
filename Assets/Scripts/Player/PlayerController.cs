using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    [Header("Information")]
    [SerializeField] float maxHp;
    [SerializeField] float nowHp;
    [SerializeField] float att;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    
    private bool _isJumping;
    private bool _isUseSkill;
    private bool _isRolling;
    private bool _isAttacking;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Move()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        
        if (_isRolling==false&&_isAttacking==false)
        {
            _rigidbody.velocity = new Vector2(_horizontal*speed, _rigidbody.velocity.y);

            if (_horizontal != 0)
            {
                if(_isJumping==false)_animator.SetBool("isPlayerRun", true);
                _spriteRenderer.flipX = _horizontal < 0;
            }
            else
            {
                _animator.SetBool("isPlayerRun", false);
            }
        }
        else _animator.SetBool("isPlayerRun", false);
    }

    void Jump()
    {
        if (_isJumping == false&&Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            _isJumping = true;
            _animator.SetBool("isPlayerJump", true);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(AttackCo()); 
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isJumping = false;
            _animator.SetBool("isPlayerJump", false);
        }
    }

    IEnumerator AttackCo()
    {
        _rigidbody.velocity = new Vector2(0,_rigidbody.velocity.y);
        _isAttacking = true;
        _animator.SetTrigger("isPlayerAttack");
        print("att");
        yield return new WaitForSeconds(1.5f);
        _isAttacking = false;
    }
    
}
