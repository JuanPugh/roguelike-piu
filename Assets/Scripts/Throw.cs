using UnityEngine;

public class Throw : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform gunPosition;
    public float shotCooldown;
    private float reloadingTime = 0;
    private int damage = 10; 

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    
    private void Shoot() {

        reloadingTime += Time.deltaTime;

        if(reloadingTime <= shotCooldown) return;
        if(!Input.GetMouseButton(0)) return;

        reloadingTime = 0;
        GameObject b = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
        Bullet bullet = b.GetComponent<Bullet>();
        bullet.SetDamage(damage);
                
        bullet.direction = -transform.right;
    }

    public int GetDamage() { return damage; }
    public void SetDamage(int damage) { this.damage = damage; }
}
