using JetBrains.Annotations;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage;
    public GameObject owner;
    public BaseTower tOwner;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BadGuy>() == true)
        {
            collision.gameObject.GetComponent<BadGuy>().TakeDamage(damage, tOwner);
        }
        Destroy(gameObject);
    }
}
