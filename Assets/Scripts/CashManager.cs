using TMPro;
using UnityEditor;
using UnityEngine;
public class CashManager : MonoBehaviour
{
    [SerializeField] TMP_Text cashText;
    public int cash = 4;
    private void Start()
    {
        UpdateCashText();
    }
    public void UpdateCashText()
    {
        cashText.text = "Money: £" + cash;
    }
    public void addCash(int amount)
    {
        cash += amount;
        UpdateCashText();
    }
    public void removeCash(int amount)
    {
        cash -= amount;
        UpdateCashText();
    }
    public bool EnoughCash(int towerCost)
    {
        if(cash >= towerCost)
        {
            return true;
        }
        else
        {
            Debug.LogWarning("you dont have enough cash");
            return false;
        }
    }
}
