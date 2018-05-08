using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject GameOverCavas;

     void Update()
    {
        if (playerControl .isPlayerDie )
        {
            GameOverCavas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
