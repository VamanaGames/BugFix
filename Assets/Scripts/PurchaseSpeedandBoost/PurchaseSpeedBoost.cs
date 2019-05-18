using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PurchaseSpeedBoost : MonoBehaviour
{
    private int PurchaseAmmount;


    public TextMeshProUGUI UpgradeButtonText;
    private int[] randomvalue= { 5, 7,13,17,21};
    // Start is called before the first frame update

    private ButtonFireSpeed m_checkStatus;
    private PlayerPrefPurchase upgradeoptions;
    void Start()
    {
        upgradeoptions = FindObjectOfType<PlayerPrefPurchase>();
        m_checkStatus = FindObjectOfType<ButtonFireSpeed>();

        PurchaseAmmount = 3;
        SetupdateButtonText(upgradeoptions.GetUpdateCodePersecond());
    }

 
    //upgrade bullet speed
    public int RandomCoinsValue()
    {
     
        int randNum = Random.Range(0, randomvalue.Length);
        PurchaseAmmount = randomvalue[randNum];
        return PurchaseAmmount;

    }
 
    public void setUpgradebuttontext()
    {
        if(m_checkStatus.IsCodePerSecond)
        {

            SetupdateButtonText(upgradeoptions.GetUpdateCodePersecond());
        }
        else if(m_checkStatus.isCodeReliability)
        {
            SetupdateButtonText(upgradeoptions.GetUpdateCodeReliablility());
        }
        else if(m_checkStatus.iscoinsPurchase)
        {
            
            SetupdateButtonText(upgradeoptions.GetUpdatedCoinsPercentage());
        }
    }

    public void SetupdateButtonText(int amount)
    {
        UpgradeButtonText.text = amount.ToString();
    }



}
