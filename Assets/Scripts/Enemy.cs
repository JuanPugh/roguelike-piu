using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;
    public int speed = 5;
    public int exp = 10;
    public int damage;

    [SerializeField] private Transform player;
    
    private void OnEnable()
    {
        EventManager.PlayerDeath += OnPlayerDeath;
    }
    private void OnDisable()
    {
        EventManager.PlayerDeath -= OnPlayerDeath;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        Move();
    }

    void LookAtPlayer()
    {
        if (player == null) return;
        var direction = player.position - transform.position;
        transform.forward = direction;
    }

    void Move()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.collider.gameObject;
        if (collider.CompareTag("Proyectile"))
        {

            var colliderDmg = collider.GetComponent<Shuriken>().GetDamage();
            HandleDamage(colliderDmg);
            Destroy(collider);

        }
    }

    public void HandleDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            player.GetComponent<Player>().AddExp(exp);
            GameObject.Destroy(gameObject);
        }
    }

    public int GetDamage() { return damage; }

    private void OnPlayerDeath()
    {

        Destroy(this);
    }

}
