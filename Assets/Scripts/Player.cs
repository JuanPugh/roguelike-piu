using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private int speed = 8;

    private Rotator rotator;

    private int health = 100;

    public Vector2 movement;
    private Rigidbody2D rb;

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

        this.health -= damage;

        if (health <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public int getSpeed()
    {
        return speed;
    }

    public void setSpeed(int speed)
    {
        this.speed = speed;
    }
}
