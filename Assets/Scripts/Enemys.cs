using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType")]
//[CreateAssetMenu(fileName = "Enemys", menuName = "Scriptable Objects/Enemys")]
public class Enemys : ScriptableObject
{
    public float enemyCost;
    public float enemyHealth;
    public float enemySpeed;
}
