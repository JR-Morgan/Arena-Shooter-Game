using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject DeathCamera;
    public GameObject MainCamera;
    public Canvas GameOverCanvas;
    // Use this for initialization
    void Start () {
        MainCamera.SetActive(true);
        DeathCamera.SetActive(false);
    }

    public void EndGame()
    {

        Debug.Log("GAME HAS ENDED");
        MainCamera.SetActive(false);
        DeathCamera.SetActive(true);
        GameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
