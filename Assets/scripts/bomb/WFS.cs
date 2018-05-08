using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFS : Fire  {

    public GameObject Fire;
    public int FirePower;
    public AudioSource Sound;
    //public AudioClip ExplosionEffect;

    private void Awake()
    {
        FirePower = Buffboard.FirPowerMax;
    }
	// Use this for initialization
	void Start () 
    {
        Sound = GameObject.Find("Sound").GetComponent<AudioSource>();  
        StartCoroutine(Bommm());
	}
	
    IEnumerator Bommm()
    {
        yield return new WaitForSeconds(3f);

        Explosion(gameObject , Fire); 
    }

    void Explosion(GameObject gobj_bomb, GameObject gobj_fire)
    {
        //Debug.Log("WFS:" + FirePower);
        InsFire(gobj_fire ,FirePower);
        playerControl.CanBomb--;
        Sound.Play(); 
        Destroy(gobj_bomb);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "fire")
        {
            Explosion(gameObject, Fire);
        }
    }

    //
    //解决人物站在炸弹上时，isTrigger为true，无法被fire引爆
    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fire")
        {
            Explosion(gameObject, Fire);
        }
    }
}
