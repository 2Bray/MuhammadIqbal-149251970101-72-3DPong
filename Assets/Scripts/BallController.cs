using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private BallSpawnerManager spawnManager;
    
    private Rigidbody rb;
    private MeshRenderer mr;
    private Collider col;

    //Mengambil Refrensi Rigidbody Dari Object Ini
    public Rigidbody GetRigidBody()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        return rb;
    }

    //Mengambil Refrensi MeshRenderer Dari Object Ini
    public MeshRenderer GetMeshRenderer()
    {
        if (mr == null) mr = GetComponent<MeshRenderer>();
        return mr;
    }

    //Mengambil Refrensi Collider Dari Object Ini
    public Collider GetCollider()
    {
        if (col == null) col = GetComponent<Collider>();
        return col;
    }

    //Menonaktifkan Bola, Akan di eksekusi ketika bola mengenai garis gawang
    public void DeactiveBall() => StartCoroutine(deactiveBall());

    //Bola Tidak langsung menghilang, Bola akan tetap pada field selama 2sec
    private IEnumerator deactiveBall()
    {
        //Mematikan collider pada bola. Agar Bola Tidak Dapat Memantul Lagi.
        col.enabled = false;

        yield return new WaitForSeconds(2f);
        spawnManager.CekActiveBall();

        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
