using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelCompletePannel : MonoBehaviour
{
    public TextMeshProUGUI CurrentLevel;
    public TextMeshProUGUI NextLevel;
    
    // Start is called before the first frame update

     private PlayerCurrentNextPref m_level;
    void Start()
    {
        m_level = FindObjectOfType<PlayerCurrentNextPref>();
        Setlevel();
    }

    private void Setlevel()
    {
        CurrentLevel.SetText((m_level.GetPlayerCurrentLevel()-1).ToString());
        NextLevel.SetText((m_level.GetPlayerNextLevel()-1).ToString());
    }
    // Update is called once per frame
    void Update()
    {
        Setlevel();

    }
}
