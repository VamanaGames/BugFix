using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtralife : MonoBehaviour
{
    private bool callonlyOnce;
    public GameObject PlayerReviveObject;

    private GameManagerController m_rebirth;

    private void Start()
    {
        m_rebirth = FindObjectOfType<GameManagerController>();
    }
    void Update()
    {
       if(m_rebirth.GetRebirth())
        {
            if(!callonlyOnce)
            {
                PlayerReviveObject.SetActive(true);
                callonlyOnce = !callonlyOnce;
            }
        }
    }

}
