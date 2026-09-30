using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class BlockPath : MonoBehaviour
{
    [SerializeField]NavMeshSurface meshSurface;
    [SerializeField] GameObject PathBLocker;
    [SerializeField]CashManager cashManager;
    [SerializeField] WaveSystem waveSystem;
    [SerializeField] int cost;
    private void Start()
    {
        if (PathBLocker.activeInHierarchy == true)
        {
            PathBLocker.SetActive(false);
        }
        meshSurface.BuildNavMesh();
    }
    private void OnMouseDown()
    {
        if(cost <= cashManager.cash && waveSystem.waveActive != true)
        {
            cashManager.removeCash(cost);
            PathBLocker.SetActive(true);
            gameObject.transform.position = new Vector3(0, -4f, 0);//makes it so the block is hiden from few. Its done like this due to this being refenced in the wavesystem.
            meshSurface.BuildNavMesh();
        }
       
    }
}
