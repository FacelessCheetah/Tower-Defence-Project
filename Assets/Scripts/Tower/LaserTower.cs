using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LaserTower : BaseTower
{
    [Header("Laser Tower")]
    [SerializeField] private LayerMask layerMask;
    private float maxDistance = 1000;
    [SerializeField]LineRenderer lineRenderer;
    public override void shoot()
    {
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask);
        StartCoroutine(RenderLine());
        foreach (RaycastHit hit in hits)
        {
            hit.transform.GetComponent<BadGuy>().TakeDamage(damage, this);
        }
    }
    IEnumerator RenderLine()
    {
        float oldspeed = rotateSpeed;
        rotateSpeed = 0.00001f;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(1, Vector3.forward * maxDistance);
        yield return new WaitForSeconds(0.5f);
        lineRenderer.enabled = false;
        rotateSpeed = oldspeed;
        yield return null;
    }
}
