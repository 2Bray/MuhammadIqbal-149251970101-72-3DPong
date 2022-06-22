using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    //Class Untuk Garis Gawang Player

    public PaddleController player;

    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.color = player.PlayerColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(changeColor());

            //Memberitahu ScoreManager Gawang Player Kemasukan Bola
            ScoreManager.Instance.gotGoal(this);
            //Menonaktifkan Bola
            other.GetComponent<BallController>().DeactiveBall();
        }
    }

    //Mengganti Warna Sesaat
    //Sebagai Feedback Gawang Kemasukan Bola
    private IEnumerator changeColor()
    {
        mr.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        mr.material.color = player.PlayerColor;
    }

    //Dieksekusi Ketika lifePoint Player Bernilai 0
    public void KO() => StartCoroutine(ko());

    private IEnumerator ko()
    {
        //Menonaktifkan Player Paddle
        player.gameObject.SetActive(false);

        //Mengubah Garis Gawang Menjadi Tembok.
        transform.localScale += Vector3.up;
        transform.position += Vector3.up * 0.5f;

        GetComponent<Collider>().isTrigger = false;

        yield return new WaitForSeconds(0.5f);
        mr.material.color = Color.white;
    }
}
