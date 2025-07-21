using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public int health = 20;
    public int speed = 5;
    public int exp = 10;

    private Rotator rotator;
    private Transform player;
    

    public int damage;

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
        rotator = GetComponent<Rotator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) return;
        
        rotator.LookAt(player.position);
        transform.position += speed * Time.deltaTime * -transform.right;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.collider.gameObject;
        if (collider.CompareTag("Proyectile")) {

            var bulletDmg = collider.GetComponent<Bullet>().GetDamage();
            HandleDamage(bulletDmg);
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
