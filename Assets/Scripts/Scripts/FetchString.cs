using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchString : MonoBehaviour
{

    private string CodeSnippets = "Hi Hello world [] {}";
    private string BigEnemyTexts = "Runtime-Error Logic-Error Syntax-Error  Compilation-Error";

    private string[] arrayword;
    private string[] bigenemyname;
    // Start is called before the first frame update
    void Awake()
    {
        arrayword = CodeSnippets.Split(' ');
        bigenemyname = BigEnemyTexts.Split(' ');
    }

    public string ReturnRandomString()
    {
        //
//        return arrayword[Random.Range(0, PlayerPrefs.GetInt("Current Level")];

        return arrayword[Random.Range(0, arrayword.Length)];
      }
    public string ReturnforBigEnemyName()
    {

        return bigenemyname[Random.Range(0, bigenemyname.Length)];
    }

   }
