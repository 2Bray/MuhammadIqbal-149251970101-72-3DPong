using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 posBall;
    [SerializeField] private Vector3 dirBall;

    [SerializeField] private Color warningColor;
    private MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    public void ThrowBall(BallController ball)
    {
        StartCoroutine(throwBall(ball));
    }

    //Hitung Mundur Proses Spawn Ball
    private IEnumerator throwBall(BallController ball)
    {
        ball.GetCollider().enabled = false;
        ball.GetMeshRenderer().enabled = false;
        
        ball.transform.localPosition = posBall;
        ball.gameObject.SetActive(true);

        mr.material.color = warningColor;
        yield return new WaitForSeconds(1);
        mr.material.color = Color.white;

        ball.GetCollider().enabled = true;
        ball.GetMeshRenderer().enabled = true;
        
        //Menambahkan Angka Random Sebagai Direction Pada Bola,
        //Agar Arah Pelemparan Bola Tidak Monoton
        Vector3 rand = new Vector3(Random.Range(0f, 0.1f), 0, Random.Range(0f, 0.1f));

        ball.GetRigidBody().velocity = (dirBall + rand) * 10;
    }
}
