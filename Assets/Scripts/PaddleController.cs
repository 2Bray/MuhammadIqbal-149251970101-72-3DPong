using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    //Class Ini Bertindak Sebagai Player

    public Color PlayerColor;
    public string PlayerName;

    [SerializeField] private KeyCode[] move;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private PlayerScoreUI lifePointUI;

    private int lifePoint;
    private Rigidbody rb;

    private void Start()
    {
        name = PlayerName;

        GetComponent<MeshRenderer>().material.color = PlayerColor;
        rb = GetComponent<Rigidbody>();

        //Mengecek Agar Tidak Eror Ketika Berada Pada How To Play Scene
        if (lifePointUI) lifePointUI.SetUp(this);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        int moving = 0;
        
        if (Input.GetKey(move[0])) moving = -1;
        else if (Input.GetKey(move[1])) moving = 1;
        
        rb.velocity += moving * speed * direction;
        //direction Akan Diisi Pada Inspector
        //Karena Arah Gerak Dari Masing" Player Yang Berbeda.
    }

    public void SetLifePoint(int p)
    {
        lifePoint = p;

        //Setiap Life Point Berubah, Memerintahkan UI Untuk Mengupdate Nilainya
        lifePointUI.ShowLifePoint(lifePoint);
    }

    public int GetLifePoint() => lifePoint;
}
