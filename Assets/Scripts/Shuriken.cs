using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 20;
    private float distance = 0;

    private int damage = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = speed * Time.deltaTime * direction;
        distance += velocity.magnitude;
        transform.position += velocity;

        if (distance > 10)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    public int GetDamage() { return damage; }

    public void SetDamage(int d) { damage = d; }
}
