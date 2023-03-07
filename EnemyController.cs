using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemyRigidbody;
    PlayerController player;
    public float xSpeed, ySpeed;

    public GameObject bullet;
    public float timeBetweenAttackLow = 0.5f;
    public float timeBetweenAttackHigh = 2f;

    float attackCools; 

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        attackCools = Random.Range(timeBetweenAttackLow, timeBetweenAttackHigh);

        
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0f;
        if (player != null)
            if (player.transform.position.x > transform.position.x) //enemy is on the left
                x = xSpeed;
            else if (player.transform.position.x < transform.position.x) //right
                x = -xSpeed;
        enemyRigidbody.AddForce(new Vector2(x, -ySpeed) * Time.deltaTime);

        if (attackCools > 0)
            attackCools -= Time.captureDeltaTime;
        else
            Attack();
    }

    void Attack()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        attackCools = Random.Range(timeBetweenAttackLow, timeBetweenAttackHigh);
    }
}
