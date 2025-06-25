using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20;
    public int speed = 5;

    private Rotator rotator;
    private Transform player;
    

    public int damage;

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
        transform.position += -transform.right * speed * Time.deltaTime;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");

        GameObject collider = collision.collider.gameObject;
        if (collider.CompareTag("Proyectile")) {

            var bulletDmg = collider.GetComponent<Bullet>().GetDamage();
            HandleDamage(bulletDmg);
            GameObject.Destroy(collider);

        }
    }

    public void HandleDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public int GetDamage()
    {
        return this.damage;
    }
}
