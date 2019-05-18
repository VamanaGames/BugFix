using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class RanodmDiamonds : MonoBehaviour
{

  //  private Sprite diamondSprited;
    private int[] RandvalueofDiamonds = { 50, 60, 70, 80, 55, 90 };//this is for big enemy died thos coins showing the collectble coins
    public TextMeshProUGUI Randomtext;
    private PlayerCoinsPrefs m_diamonds;
    // Start is called before the first frame update
    void Start()
    {
        m_diamonds = FindObjectOfType<PlayerCoinsPrefs>();
        setText();
    }
    private void setText()
    {
        //set player diamods
        int randvalue = getrandomigEnemyvalues();
        setAvailDiamonds(randvalue);
       
        //make callable function to set player data;
        Randomtext.SetText(randvalue.ToString());
    }
    private int getrandomigEnemyvalues()
    {
         return RandvalueofDiamonds[Random.Range(0, RandvalueofDiamonds.Length)];
    }
    private void setAvailDiamonds(int value)
    {
        m_diamonds.SetAvailDiamonds(m_diamonds.GetAvailableDiamonds() + value);
    }

}
