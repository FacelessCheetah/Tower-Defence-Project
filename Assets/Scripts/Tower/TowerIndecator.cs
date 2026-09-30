using UnityEngine;

public class TowerIndecator : MonoBehaviour //towerIndecator is only one when you are in placement mode
{
    [SerializeField]TowerPlacement placement;
    [Header("")]
    [SerializeField] Color placeGreen;
    [SerializeField] Color placeRed;
    Ray ray;
    //[HideInInspector]public bool cantPlace = false;
    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.layer == 3 && hit.normal == Vector3.up)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = placeGreen;
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = placeRed;
            }
            Vector3 spawnPosition = hit.point;
            float towerHeight = gameObject.GetComponent<Renderer>().bounds.size.y;
            spawnPosition.y += towerHeight / 2f;
            gameObject.transform.position = spawnPosition;
        }
    }
    public void Show(GameObject towerIndicator)
    {
        //towerIndicator = _towerIndicator;
        gameObject.GetComponent<MeshFilter>().mesh = towerIndicator.GetComponent<MeshFilter>().sharedMesh;
    }
    //public void OnTriggerStay(Collider other)
    //{
    //    if(other.CompareTag("tower"))
    //    {
    //        cantPlace = true;
    //    }
    //    else
    //    {
    //        cantPlace = false
    //    }
        
    //}
    

}
