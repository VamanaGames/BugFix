using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ButtonFireSpeed : MonoBehaviour
{

    public  bool IsCodePerSecond=false;
    public  bool isCodeReliability=false;
    public  bool iscoinsPurchase=false;

    public TextMeshProUGUI m_titletext;
    public TextMeshProUGUI m_contenttext;

   

    private string m_TitleCodePersecond = "Fire Speed";
    private string m_TitleCodeReliable= "Code Perfomance";
    private string m_TitleCoins = "Coins";



    private PurchaseSpeedBoost m_upgradeCoins;
    private PlayerPrefPurchase playerpref;

    private CoinsPurchaseGateWay m_accessgatedway;

    private int IncreasCodeReliability = 10;
    private int IncreaseCoins = 10;

    void Start()
    {
        IsCodePerSecond = true;
        m_accessgatedway = FindObjectOfType<CoinsPurchaseGateWay>();
        playerpref = FindObjectOfType<PlayerPrefPurchase>();
        m_upgradeCoins = FindObjectOfType<PurchaseSpeedBoost>();
        SettextTitleUi(m_TitleCodePersecond);
        setContentTextUI(playerpref.GetCodePerSecond().ToString() + " CPS");
        isCoinsPowerIncreses(1);
        //  upgradePurchaseUI();

    }

    public void OnclickedCodeShootPersecond()
    {
        isCoinsPowerIncreses(1);
        upgradePurchaseUI();

    }
    public void OnclickedCodeFireDamage()
    {
        isCoinsPowerIncreses(2);  
        upgradePurchaseUI();

    }
    public void onClickedCoinsPercent()
    {
        isCoinsPowerIncreses(3);
        upgradePurchaseUI();
    }
    public void isCoinsPowerIncreses(int value)
    {//1----speed
      //2---code
      //3-----Coins percentage
        
        if(value==1)
        {
            IsCodePerSecond = true;
            isCodeReliability = false;
            iscoinsPurchase = false;

        }
        else if(value==2)
        {

            IsCodePerSecond = false;
            isCodeReliability = true;
            iscoinsPurchase = false;

        }
        else if(value==3)
        {

            IsCodePerSecond = false;
            isCodeReliability = false;
            iscoinsPurchase = true;

        }
    }

    public void setTextforUI(string titleText,string contentText)
    {
        m_titletext.text = titleText;
        m_contenttext.text = contentText;
    }
    public  void SettextTitleUi(string titleText)
    {
        m_titletext.text = titleText;

    }
    public void setContentTextUI(string contenttext)
    {
        m_contenttext.text = contenttext;

    }


    public void SetUpgradeButtonClicks()
    {
        if(IsCodePerSecond)//no of code executed per second
        {
            UpgradeCodePersecond();
        }
        else if(isCodeReliability)//code speed persecond
        {
            updateCodeReliability();
        }
        else if(iscoinsPurchase)//1 upgrade coin value
        {
            updateCoinsPercentage();
        }

    }
    private void updateCodeReliability()
    {
        //check coins Available

        if(m_accessgatedway.ChekpaymentGatewyforCodeReliability())//add some funion later(availCoins<Playerpref.getcodeReliablity)
        {
            setCodeReliabilityUpdate();
        }
    }
    private void updateCoinsPercentage()
    {
        if(m_accessgatedway.checkPaymentGatewayforCoinsUpgrade())
        {
            SetCoinupdate();
        }
    }

    public void UpgradeCodePersecond()
    {
        //player check AvailabeCoins
        //if available acces purchase
        if (m_accessgatedway.checkPaymentgatewayforCodePerSecond())//later  you have to check avalable coins
        {
            setCodePersecondUpgrade();
        }
    }

    private void setCodePersecondUpgrade()
    {
        playerpref.SetCodePersecond(playerpref.GetCodePerSecond() + 1);//set COde persecode ui
        playerpref.SetUpgradeCodePerSecondCoins(playerpref.GetUpdateCodePersecond()//coins per check
            + m_upgradeCoins.RandomCoinsValue());
        upgradePurchaseUI();

    }
    private void setCodeReliabilityUpdate()
    {
        playerpref.SetCodeReliability(playerpref.GetCodeReliability() + IncreasCodeReliability);
        playerpref.SetUpgradeCodeReliabilityCoins(playerpref.GetUpdateCodeReliablility() + m_upgradeCoins.RandomCoinsValue());
        upgradePurchaseUI();
    }
    private void SetCoinupdate()
    {
        playerpref.SetCoinsPercentage(playerpref.GetCoinsPercentage() + IncreaseCoins);
        playerpref.SetUpgradeCoinsPercent(playerpref.GetUpdatedCoinsPercentage()
            + m_upgradeCoins.RandomCoinsValue());
        upgradePurchaseUI();
      
    }
   
    
 

   
    private void upgradePurchaseUI()
    {

        if (IsCodePerSecond)
        {
            m_upgradeCoins.setUpgradebuttontext();
            SettextTitleUi(m_TitleCodePersecond);
            setContentTextUI(playerpref.GetCodePerSecond().ToString() + " CPS");

        }
        else if (isCodeReliability)
        {
            SettextTitleUi(m_TitleCodeReliable);
            setContentTextUI(playerpref.GetCodeReliability().ToString() + " %");
            m_upgradeCoins.setUpgradebuttontext();
        }
        else if (iscoinsPurchase)
        {

            SettextTitleUi(m_TitleCoins);
            setContentTextUI(playerpref.GetCoinsPercentage().ToString() + " %");
            m_upgradeCoins.setUpgradebuttontext();
        }

    }
}
