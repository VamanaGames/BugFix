using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPannel : MonoBehaviour
{

    public GameObject Volumebutton;
    public GameObject MusicButton;
    public GameObject CreditsPanelButton;
   //public GameObject CreditsPannel;

    private bool ToggleButton;
    // Start is called before the first frame update
    void Start()
    {
        DeactivePanel();
    }

   
    private void DeactivePanel()
    {
        Volumebutton.SetActive(false);
        MusicButton.SetActive(false);
        CreditsPanelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ActiveSettigsPannel()
    {
        Volumebutton.SetActive(true);
        MusicButton.SetActive(true);
        CreditsPanelButton.SetActive(true);
    }
    public void ToggleSettingsPannel()
    {
        if(!ToggleButton)
        {
            ActiveSettigsPannel();
            ToggleButton = !ToggleButton;
        }
        else if(ToggleButton)
        {
            DeactivePanel();

            ToggleButton = !ToggleButton;
        }
    }
}
