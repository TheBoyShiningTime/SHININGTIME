using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    private float _attDelay;
    
    private EnemyInfo _enemy;
    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<EnemyInfo>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        _attDelay -= Time.deltaTime;
        if (_attDelay < 0) _attDelay = 0;

        float distance = Vector3.Distance(transform.position, target.position);

        //거리는 추후 변경
        if (_attDelay == 0 && distance <= 30)
        {
            FaceTarget();

            if (distance <= _enemy.attRange)
            {
                AttackTarget();
            }
            else
            {
                MoveToTarget();
            }
        }

    }
    
    
    void MoveToTarget()
    {
        float dir = target.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(new Vector2(dir, 0) * _enemy.speed * Time.deltaTime);
    }
    
    void FaceTarget()
    {
        _spriteRenderer.flipX = target.position.x > transform.position.x;
    }
    
    void AttackTarget()
    {
        print("attPlayer");
    }
    
}
