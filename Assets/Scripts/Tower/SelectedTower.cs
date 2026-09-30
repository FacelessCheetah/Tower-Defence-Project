using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static BaseTower;

public class SelectedTower : MonoBehaviour
{
    [SerializeField] TowerPlacement placement;

    [Header("UI")]
    [SerializeField] GameObject towerUi;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject leftButton;
    [SerializeField] TMP_Text targetModeText;
    [SerializeField] TMP_Text kills;

    public BaseTower selectedTower;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !placement.inPlaceMode && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {              
                if (hit.transform.GetComponent<BaseTower>() != null)
                {
                    if (selectedTower != null) //if there is allready a tower selected the selected tower is first disable then the new selected tower is enebled 
                    {
                        closeTowerUI();
                        openTowerUI(hit.transform.gameObject);                        
                    }
                    else
                    {
                        openTowerUI(hit.transform.gameObject);
                    }

                }
                else//if the player does not click on a tower it closes the ui
                {
                    if (towerUi.activeInHierarchy)
                    {
                        closeTowerUI();
                    }
                }
            }
        }
        if (selectedTower != null) UpdateKillCounter();
    }
    private void openTowerUI(GameObject _tower)
    {
        towerUi.SetActive(true);
        selectedTower = _tower.GetComponent<BaseTower>(); //get the kills and the targating style of the selected tower
        selectedTower.selectTower();
        targetModeText.text = selectedTower.targetingStyle.ToString();
    }
    private void closeTowerUI()
    {
        selectedTower.deselectTower();
        towerUi.SetActive(false);
    }


    public void RightArrow()//changes the targeting style to the next one
    {
        TargetingStyle[] values = (TargetingStyle[])Enum.GetValues(typeof(TargetingStyle));
        selectedTower.targetingIndex = (selectedTower.targetingIndex + 1) % values.Length;
        selectedTower.targetingStyle = values[selectedTower.targetingIndex];

        targetModeText.text = selectedTower.targetingStyle.ToString();
    }
    public void LeftArrow()
    {
        TargetingStyle[] values = (TargetingStyle[])Enum.GetValues(typeof(TargetingStyle));
        selectedTower.targetingIndex = (selectedTower.targetingIndex - 1 + values.Length) % values.Length;
        selectedTower.targetingStyle = values[selectedTower.targetingIndex];
        targetModeText.text = selectedTower.targetingStyle.ToString();
    }
    void UpdateKillCounter()
    {
        kills.text = "Damage: " + selectedTower.damageDone.ToString();
    }
}