using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float bulletSpeed = 20;
    private float distance = 0;
    private float rotation = 0;

    private int damage = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = bulletSpeed * Time.deltaTime * direction;
        distance += velocity.magnitude;
        transform.position += velocity;

        if (rotation + 10 >= 360)
        {

            rotation = 0;
        }
        else
        {
            rotation += 10;
        }

        transform.eulerAngles = new Vector3(0, 0, rotation);

        if (distance > 10)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    public void UpgradeDamage()
    {
        damage += 10;
    }
}
