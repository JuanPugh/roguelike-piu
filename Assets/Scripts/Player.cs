using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed = 8;
    [SerializeField] private int health = 100;
    [SerializeField] private int max_health = 100;
    [SerializeField] private int exp = 0;
    [SerializeField] private int max_exp = 100;

    private Camera main_camera;

    public Vector2 movement;
    private Rigidbody rb;

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
        rb = GetComponent<Rigidbody>();
        main_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LookAtMouse();

        if(Input.GetKey(KeyCode.T))
        {
            Time.timeScale = 0;
        }

    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        //rb.AddForce(movement * Time.deltaTime * speed, ForceMode2D.Impulse);

        movement *= Time.deltaTime * speed;
        transform.position += new Vector3(movement.x, 0, movement.y);
    }

    private void LookAtMouse()
    {
        (bool success, Vector3 mousePos) = GetMousePosition();

        if(success)
        {
            Vector3 direction = mousePos - transform.position;
            direction.y = 0;
            transform.forward = direction;
        }
    }

    private (bool, Vector3) GetMousePosition()
    {
        Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, 1))
        {
            return (true, hitInfo.point);

        } else
        {

            return (false, Vector3.zero);
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


    void OnCollisionEnter(Collision collision)
    {

        GameObject collider = collision.collider.gameObject;
        if (collider.CompareTag("Enemy"))
        {
            HandleDamage(collider.GetComponent<Enemy>().GetDamage());
        }
    }
}
