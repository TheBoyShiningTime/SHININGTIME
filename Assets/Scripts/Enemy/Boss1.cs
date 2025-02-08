using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private int nowPattern=0;
    private float patternTimer=5.0f;
    private float distance=0;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    
    [Header("Information")]
    [SerializeField] Transform target;
    [SerializeField] float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
    }
    
    
    IEnumerator DashAttack()
    {
        print("DashAttack");
        float dir = target.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        _spriteRenderer.flipX = target.position.x > transform.position.x;
        yield return new WaitForSeconds(1.0f);

        _rigidbody2D.AddForce(Vector2.right * moveSpeed*2);

            


        
    }
}
