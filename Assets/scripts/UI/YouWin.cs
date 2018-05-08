using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour {

    public GameObject YouWinCavas;

    void Update()
    {
        if (EnemyMove.isEnemyDie)
        {
            YouWinCavas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
