using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void WhenBombExplosionEventHandler(GameObject gobj_bomb, GameObject gobj_fire);

public class WaitForSec : Fire{
    /*
	 * 
	 * 炸弹爆炸要等的秒数,脚本放在bome上.........................
	
	*/
    public event WhenBombExplosionEventHandler WhenBombExplosion;


    public float bombseconds = 3f;
    public GameObject gobj_fire;
    public playerControl FirPower;
    //private Fire fire_touch_bomb;
    // public GameObject bomb;
    private void Awake()
    {
        WhenBombExplosion += new WhenBombExplosionEventHandler(StartBombExplosion);
        FirPower = new playerControl();
    }
    void Start ()
    {
        StartCoroutine(Bommm());
    }
    
    IEnumerator Bommm()
    {

        yield return new WaitForSeconds(bombseconds);
        
        BombExplosion(this.gameObject, gobj_fire);
        WhenBombExplosion -= new WhenBombExplosionEventHandler(StartBombExplosion);
        /*
        Destroy(this.gameObject);
		F_fire.InsFire (go_fire);
        playerControl.CanBomb --;
        */
    }
    public void BombExplosion(GameObject gobj_bomb, GameObject gobj_fire)
    {
        if(WhenBombExplosion != null)
        {
            WhenBombExplosion(gobj_bomb, gobj_fire);
        }
    }

    private void StartBombExplosion(GameObject gobj_bomb, GameObject gobj_fire)
    {
        //Fire fire = gameObject.AddComponent<Fire>();
        InsFire(gobj_fire, Buffboard.FirPowerMax);
        playerControl.CanBomb--;
        Destroy(gobj_bomb);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "fire")
        {
            BombExplosion(this.gameObject, gobj_fire);
            WhenBombExplosion -= new WhenBombExplosionEventHandler(StartBombExplosion);
        }
    }
    //
    //解决人物站在炸弹上时，isTrigger为true，无法被fire引爆
    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other .tag == "fire")
        {
            BombExplosion(this.gameObject, gobj_fire);
            WhenBombExplosion -= new WhenBombExplosionEventHandler(StartBombExplosion);
        }
    }
}
