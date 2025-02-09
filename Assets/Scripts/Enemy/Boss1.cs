using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyInfo
{
    private int nowPattern=0;
    private float patternTimer=5.0f;
    private float distance=0;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    
    [Header("Information")]
    [SerializeField] Transform target;
    [SerializeField] float dashSpeed;
    [SerializeField] GameObject bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        StartCoroutine(BossPatternController());
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
    }


    IEnumerator BossPatternController()
    {
        while (true)
        {
            nowPattern=Random.Range(0,3);

            switch (nowPattern)
            {
                case 0:
                    StartCoroutine(DashAttack());
                    break;
                case 1:
                    StartCoroutine(ShootStraight());
                    break;
                case 2:
                    StartCoroutine(ShootCircular());
                    break;
            }
            
            yield return new WaitForSeconds(patternTimer);
        }
    }
    
    
    IEnumerator DashAttack()
    {
        print("DashAttack");
        float dir = target.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        _spriteRenderer.flipX = target.position.x > transform.position.x;
        yield return new WaitForSeconds(1.0f);

        _rigidbody2D.AddForce(Vector2.right * dashSpeed);
        
        /*
         Vector2 startPosition = transform.position;
        Vector2 targetPosition = player.position;
        float dashTime = 0.5f;
        float elapsedTime = 0;

        while (elapsedTime < dashTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / dashTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
         */
        
    }
    IEnumerator ShootStraight()
    {
        print("ShootStraight");
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * 5f; // 탄환 속도 5
        yield return new WaitForSeconds(1f);
    }
    
    IEnumerator ShootCircular()
    {
        print("ShootCircular");
        int bulletCount = 12;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = rotation * Vector2.right * 4f; // 탄환 속도 4
        }
        yield return new WaitForSeconds(3.0f);
    }
    
}
