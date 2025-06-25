using UnityEngine;

public class Throw : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform gunPosition;
    public float shotCooldown;
    private float reloadingTime = 0;

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if(Input.GetKey(KeyCode.F)) {

            shotCooldown = 0;
        } else {
            shotCooldown = 0.5f;
        }
    }
    
    private void Shoot() {

        reloadingTime += Time.deltaTime;

        if(reloadingTime <= shotCooldown) return;
        if(!Input.GetMouseButton(0)) return;

        reloadingTime = 0;
        GameObject b = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
        Bullet bullet = b.GetComponent<Bullet>();
                
        bullet.direction = -transform.right;
    }
}
