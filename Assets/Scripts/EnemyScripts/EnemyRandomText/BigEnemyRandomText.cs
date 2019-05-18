using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BigEnemyRandomText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro m_Bigenemyname;
    private FetchString fetchRandoom;
    void Start()
    {
        fetchRandoom = FindObjectOfType<FetchString>();
        m_Bigenemyname.SetText(fetchRandoom.ReturnforBigEnemyName());
    }

   


}
