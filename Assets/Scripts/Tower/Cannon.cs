using UnityEngine;

public class Cannon : BaseTower
{
    [Header("Cannon")]
    public GameObject bullet;
    public override void shoot()
    {
        GameObject spawnedBullet = Instantiate(bullet, transform.position, transform.rotation);
        spawnedBullet.GetComponent<Rigidbody>().AddForce(direction * 200, ForceMode.Force);
        spawnedBullet.gameObject.GetComponent<bullet>().damage = damage;
        spawnedBullet.gameObject.GetComponent<bullet>().owner = gameObject;
        spawnedBullet.gameObject.GetComponent<bullet>().tOwner = this;
    }
}
