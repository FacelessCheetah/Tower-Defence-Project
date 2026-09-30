using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using static UnityEngine.UI.GridLayoutGroup;

public class BadGuy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destinnation;
    public float distance;
    public int cost;
    public int health;
    public float waveSpeed;
    [HideInInspector]public List<GameObject> towersThatTargetMe = new List<GameObject>();
    CashManager cashManager;
    WaveSystem waveSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        destinnation = GameObject.FindWithTag("endPoint").transform;
        cashManager = FindFirstObjectByType<CashManager>();
        waveSystem = FindFirstObjectByType<WaveSystem>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinnation.position);
    }
    public void UpdateWaveSpeed(int speed)
    {
        Time.timeScale = speed;
    }
    private void FixedUpdate()
    {
        GetRemainingDistance();
    }
    public void GetRemainingDistance()
    {
        Vector3[] points = agent.path.corners;
        float _distance = 0;
        for (int i = 0; i < points.Length - 1; i++)
            _distance += Vector3.Distance(points[i], points[i + 1]);
        if (_distance <= 1)
            _distance = 1000;//somtimes the _distance is 0 when first instantiated which causes probles with the targatin.
        distance = _distance;
    }
    
    public void TakeDamage(int damage, BaseTower towerThatHitMe)
    {
        health -= damage;
        towerThatHitMe.damageDone += damage;
        if (health <= 0)
        {
            RemoveTargatingTowers();
            waveSystem.RemoveEnemy(gameObject);
            cashManager.addCash(1);
            Destroy(gameObject);
        }
        
    }
    public void RemoveTargatingTowers()
    {
        //makes it so the towers target is not null
        for (int i = 0; i < towersThatTargetMe.Count; i++)
        {
            BaseTower tower = towersThatTargetMe[i].GetComponent<BaseTower>();
            tower.enemiesInRange.Remove(this);
            tower.GetTarget();
        }
    }
}
