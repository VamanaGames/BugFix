using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUiCoinsScore : MonoBehaviour
{

    public TextMeshProUGUI CoinsScoreText;
    public TextMeshProUGUI DiamondsScoreText;
    public TextMeshProUGUI HeartsScoreText;
    private PlayerCoinsPrefs UpdateScore;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore = FindObjectOfType<PlayerCoinsPrefs>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinsScoreText.SetText(UpdateScore.GetModifiedAvailCoins().ToString());
        DiamondsScoreText.SetText(UpdateScore.GetAvailableDiamonds().ToString());
        HeartsScoreText.SetText(UpdateScore.GetAvailableHearts().ToString());

    }
}
