using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : MonoBehaviour
{
    [SerializeField] BaseTower tower;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            BadGuy badGuy = other.GetComponent<BadGuy>();
            //badGuy.GetRemainingDistance();
            tower.enemiesInRange.Add(badGuy);//adds the enemie to the towers list of enemies
            tower.GetTarget(); //updates the towers target
            other.gameObject.GetComponent<BadGuy>().towersThatTargetMe.Add(transform.parent.gameObject);//adds the a ref to this tower to the enemie that just enter it range.
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            tower.enemiesInRange.Remove(other.GetComponent<BadGuy>());
            tower.GetTarget();
            other.gameObject.GetComponent<BadGuy>().towersThatTargetMe.Remove(transform.parent.gameObject);
        }
    }
    
}
