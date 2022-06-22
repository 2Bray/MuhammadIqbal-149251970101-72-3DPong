using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerManager : MonoBehaviour
{
    [SerializeField] private BallSpawner[] pos;
    [SerializeField] private BallController[] ballPool;

    [SerializeField] private float spawnTime;
    
    private float timer;
    private ScoreManager scoreManager;

    private void Start()
    {
        timer = spawnTime;
        scoreManager = ScoreManager.Instance;
    }

    private void Update()
    {
        if (scoreManager.GameOver()) return;

        timer += Time.deltaTime;
        if (timer >= spawnTime) spawnBall();
    }

    //Method Akan Dieksekusi Jika Sudah Waktunya Untuk Menspawn Bola
    private void spawnBall()
    {
        //Mencari Bola Yang Sedang Tidak Aktif.
        foreach (BallController ball in ballPool)
        {
            //Jika Ada Bola Yang Sedang Tidak Aktif, Lempar Bola Tersebut.
            //Jika Seluruh Bola Aktif, Timer Hanya Direset
            if (!ball.gameObject.activeInHierarchy)
            {
                pos[Random.Range(0, pos.Length)].ThrowBall(ball);
                break;
            }
        }

        timer -= spawnTime;
    }

    //Method Akan Dieksekusi Setiap Ada Bola Yang Di Nonaktifkan.
    public void CekActiveBall()
    {
        if (scoreManager.GameOver()) return;

        StartCoroutine(cekActiveBall());
    }

    private IEnumerator cekActiveBall()
    {
        yield return new WaitForSeconds(0.5f);

        foreach (BallController ball in ballPool)
        {
            //Jika Terdapat Bola Yang Aktif Maka Keluar
            if (ball.gameObject.activeInHierarchy) yield break;
        }

        //Jika Tidak Ada Bola Yang Aktif Maka Spawn Ball
        spawnBall();
    }
}
