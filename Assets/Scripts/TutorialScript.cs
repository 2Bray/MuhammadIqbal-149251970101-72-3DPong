using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    //Class Pada How To Play

    [SerializeField] private GameObject[] tutor;
    [SerializeField] private GameObject[] tryIt;

    private bool coba = false;

    //Method Untuk Menukar Game Object Yang Digunakan
    public void TryIt()
    {
        coba = !coba;

        foreach (GameObject go in tryIt)
        {
            go.SetActive(coba);
        }

        foreach(GameObject go in tutor)
        {
            go.SetActive(!coba);
        }
    }
}
