using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreUI : MonoBehaviour
{
    //UI Untuk Masing" Player

    private PaddleController player;
    private Text lifePointText;

    public void SetUp(PaddleController p)
    {
        player = p;

        lifePointText = GetComponent<Text>();
        
        name = player.PlayerName;
        lifePointText.color = player.PlayerColor;
    }

    public void ShowLifePoint(int point) =>
        lifePointText.text = player.PlayerName +": "+ point;
}
