using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyRandomText : MonoBehaviour
{
    [SerializeField] private TextMeshPro EnemyText;
    // Start is called before the first frame update

    private FetchString fetchRand;
    void Start()
    {
        fetchRand = FindObjectOfType<FetchString>();

      EnemyText.text = fetchRand.ReturnRandomString().ToString();
    }

  
}
