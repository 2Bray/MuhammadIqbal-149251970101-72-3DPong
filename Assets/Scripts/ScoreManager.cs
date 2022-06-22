using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;
    public static ScoreManager Instance { 
        get {
            instance = instance == null ? FindObjectOfType<ScoreManager>() : instance;

            return instance;
        }
    }

    [SerializeField] PaddleController[] players;
    [SerializeField] private int lifePoint;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text playerWin;
    private bool gameOver = false;

    private void Start()
    {
        //Saat Game Akan Dimulai, Mereset Kembali Variable Static
        instance = null;

        setupLifePoint();
    }

    //Inisiasi Life Point Untuk Seluruh Player
    private void setupLifePoint()
    {
        foreach (PaddleController player in players)
            player.SetLifePoint(lifePoint);
    }

    //Method Akan Dieksekusi Setiap Bola Masuk Ke Gawang Salah Satu Player
    public void gotGoal(PlayerLine line)
    {
        if (gameOver) return;

        //Mengurangi Life Point Player Yang Gawangnya Kemasukan Bola
        line.player.SetLifePoint(line.player.GetLifePoint()-1);
        //Mengecek Apakah Player Yang Kebobolan Masih Memiliki Life Point
        if (line.player.GetLifePoint() == 0)
        {
            //Jika Life Point 0 Maka Eliminasi Player
            line.KO();
            cekGameOver();
        }
    }

    //Method Untuk Mengecek Apakah Game Over ?
    private void cekGameOver()
    {
        PaddleController winner = null;
        int idx = 0;

        foreach (PaddleController player in players)
            if (player.GetLifePoint() > 0)
            {
                winner = player;
                idx++;
            }

        if (idx > 1) return;
        //Jika Hanya Terdapat 1 Pemain Tersisa Maka Game Over

        gameOver = true;
        playerWin.text = winner.PlayerName + " Win !!!";
        playerWin.color = winner.PlayerColor;
        gameOverPanel.SetActive(true);
    }

    public bool GameOver() => gameOver;
}
