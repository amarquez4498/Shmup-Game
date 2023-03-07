using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Starting states")]
    public float speed;
    Vector2 input;

    Rigidbody2D playerRigidbody;

    [Header("Shooting")]
    public GameObject bullet;
    public GameObject[] bulletSpawnPositions;
    private float cools;
    public float timeBetweenShots; 

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        cools = timeBetweenShots; 
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRigidbody.AddForce(input * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && cools <= 0 )
            Shoot();
        if (cools > 0) cools -= Time.deltaTime;

        
    }

    void Shoot()
    {
        for (int i = 0; i < bulletSpawnPositions.Length; i++)
            Instantiate(bullet, bulletSpawnPositions[i].transform.position, Quaternion.identity);
        cools = timeBetweenShots;
    }
}
