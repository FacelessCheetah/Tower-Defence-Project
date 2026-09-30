using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject pickedTower;
    [HideInInspector]public bool inPlaceMode;
    private Ray ray;
    RaycastHit hit;
    //[SerializeField] LayerMask mask;
    [SerializeField] TowerIndecator towerIndicator;
    [SerializeField] CashManager cashManager;

    BaseTower tower;
    private void Update()
    {       
        PlaceTower();
        if (Input.GetKeyDown(KeyCode.Mouse1))//delescts the tower
        {
            inPlaceMode = false;
            towerIndicator.gameObject.SetActive(false);
        }
    }
    public void PickTower(GameObject tower)
    {
        if (cashManager.EnoughCash(tower.GetComponent<BaseTower>().towerCost))
        {
            pickedTower = tower;
            inPlaceMode = true;
            towerIndicator.gameObject.SetActive(true);
            towerIndicator.Show(pickedTower);
        }
    }
    private void PlaceTower()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && inPlaceMode == true && !EventSystem.current.IsPointerOverGameObject())
        {
            
            if(canPlace())
            {
                PlaceTowerAsync();
            } 
        }
    }

    private async void PlaceTowerAsync()
    {
        //makes sure the tower does not spawn in the ground
        Vector3 spawnPosition = hit.point;
        float towerHeight = pickedTower.GetComponent<Renderer>().bounds.size.y;
        spawnPosition.y += towerHeight / 2f;

        Instantiate(pickedTower, spawnPosition, transform.rotation);
        towerIndicator.gameObject.SetActive(false);
        cashManager.removeCash(pickedTower.GetComponent<BaseTower>().towerCost);
        await Task.Yield();
        inPlaceMode = false;
    }

    private bool canPlace()
    {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.layer == 3 && hit.normal == Vector3.up)
        {
           return true;
        }
        Debug.LogWarning("can't Place");
        return false;
        // && 
    }
}
