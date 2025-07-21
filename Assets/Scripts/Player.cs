using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed = 8;
    [SerializeField] private int health = 100;
    [SerializeField] private int max_health = 100;
    [SerializeField] private int exp = 0;
    [SerializeField] private int max_exp = 100;

    private Rotator rotator;

    public Vector2 movement;
    private Rigidbody2D rb;

    public int getHealth() { return health; }

    public int getMaxHealth() { return max_health; }
    public void setMaxHealth(int h) {

        if (health == max_health)
        {
            health = h;
        }
        max_health = h; 
    }

    public int getExp() { return exp; }
    public int getMaxExp() { return max_exp; }

    public int getSpeed() { return speed; }

    public void setSpeed(int speed) { this.speed = speed; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rotator = GetComponent<Rotator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LookAtMouse();

    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        //rb.AddForce(movement * Time.deltaTime * speed, ForceMode2D.Impulse);

        movement *= Time.deltaTime * speed;
        transform.position += new Vector3(movement.x, movement.y, 0);
    }

    private void LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotator.LookAt(mousePos);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject collider = collision.collider.gameObject;
        if (collider.CompareTag("Enemy"))
        {
            HandleDamage(collider.GetComponent<Enemy>().GetDamage());
        }
    }

    private void HandleDamage(int damage)
    {

        health -= damage;
        EventManager.OnPlayerDamaged(health);

        if (health <= 0)
        {
            EventManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }


    // The function checks if the player leveled up, if it did, then levels up and sums the overflow of xp.
    // also increases the max exp by 25%
    private void CheckExp() 
    { 
        if(exp >= max_exp)
        {
            int diff = exp - max_exp;
            exp = diff;
            max_exp += max_exp / 4;
            CheckExp(); //When killing a boss it can overpass a lvl
            EventManager.OnPlayerUpgrade();
            EventManager.OnPlayerGainExp(this.exp);
        }            
    }

    public void AddExp(int exp)
    {
        this.exp += exp;
        CheckExp();
        EventManager.OnPlayerGainExp(this.exp);
    }
}
