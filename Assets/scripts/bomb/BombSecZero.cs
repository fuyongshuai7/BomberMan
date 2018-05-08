using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSecZero : MonoBehaviour {
	/*
	 * 
	 * fire消失时间，脚本放在fire上.....................................

	*/

    
    private  float firesec = 0.3f;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Firesec());
	}
	
    IEnumerator Firesec()
    {
        yield return new WaitForSeconds(firesec);
        Destroy(this.gameObject);
    }
}
