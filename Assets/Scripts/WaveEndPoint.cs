using UnityEngine;
using UnityEngine.UI;

public class WaveEndPoint : MonoBehaviour
{ 
    [SerializeField] LivesSystem livesSystem;
    [SerializeField] WaveSystem waveSystem;
    private void OnCollisionEnter(Collision collision)
    {
        livesSystem.updateHealth(collision.transform.GetComponent<BadGuy>().health);
        collision.transform.GetComponent<BadGuy>().RemoveTargatingTowers();
        waveSystem.RemoveEnemy(collision.gameObject);
        Destroy(collision.gameObject);
        
        
    }
}
