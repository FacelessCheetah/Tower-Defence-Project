using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public enum TargetingStyle 
    { 
        First,
        Last,
        Strong,
    }
    public int towerCost;
   
    [Header("tower")]
    //[SerializeField] protected float range;
    [SerializeField] protected Transform firePoint;
    [SerializeField]protected float firerate = 1;
    protected float currentTime; //the current time for the fire rate
    [SerializeField]protected int damage;
    [HideInInspector]public int damageDone = 0;
    [SerializeField] protected GameObject towerRangeGameObject;
    [SerializeField] protected float rotateSpeed;

    [Header("enemy")]
    [SerializeField] protected FindEnemy findEnemy;
    [SerializeField]protected GameObject target;
    public List<BadGuy> enemiesInRange = new List<BadGuy>();
    public TargetingStyle targetingStyle = TargetingStyle.First;
    [HideInInspector]public int targetingIndex = 0; //index for the targetingStyle
    protected Vector3 direction;

    [HideInInspector]protected int towerKills;
    protected void Start()
    {
      currentTime = firerate;
      damageDone = 0;
    }
    protected void Update()
    {
        currentTime += Time.deltaTime;
        if (target != null) //makes sure there is a target to rotated to
        {
            rotateToTarget();
            if (currentTime >= firerate)
            {
                shoot();
                currentTime = 0;
            }
        }
    }
    protected void rotateToTarget()
    {
        direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
    float GetDistanceToDestination()
    {
        //enemiesInRange
        return 1;
    }
    public void GetTarget()
    {
        if(enemiesInRange.Count != 0)
        { 
            switch (targetingStyle)
            {
                case TargetingStyle.First:
                    target = enemiesInRange.OrderBy(e => e.distance).First().gameObject;
                    break;
                case TargetingStyle.Last:
                    target = enemiesInRange.OrderBy(e => e.distance).Last().gameObject;
                    break;
                case TargetingStyle.Strong:
                    target = enemiesInRange.OrderBy(e => e.health).Last().gameObject;
                    break;
            }
        }

    }
    public virtual void shoot()
    {
        
    }
    public void selectTower()
    {
        towerRangeGameObject.GetComponent<Renderer>().enabled = true;
        Debug.Log("tower hase been selected: " + gameObject.name);
    }
    public void deselectTower()
    {
        towerRangeGameObject.GetComponent<Renderer>().enabled = false;
    }

}
