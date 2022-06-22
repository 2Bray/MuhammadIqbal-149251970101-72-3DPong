using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //Class Ini Akan Dieksekusi Oleh Button

    public void ChangeSceneTo(string name) => SceneManager.LoadScene(name);

    public void ExitGame() => Application.Quit();
}
