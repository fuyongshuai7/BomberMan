using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour {

    
    public GameObject bomb;
    public Collider2D ChildCollider;
    public static int CanBomb; //能放的炸弹数
    static public bool CanSetBomb;
    static public bool isPlayerDie;
    private void Awake()
    {
        CanBomb = 0;
        isPlayerDie = false;
        Buffboard.BomeAmountMax = 1;
        Buffboard.SpeedMax = .5f;
        Buffboard.FirPowerMax = 1;
    }
    void Start ()
    { 
        //bomb = GameObject .Find ("bomb");
        ChildCollider = this.gameObject.GetComponentInChildren<Collider2D>();
        CanSetBomb = true;
       // Debug.Log(CanSetBomb);

    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Buffboard.SpeedMax * 0.1f, Input.GetAxisRaw("Vertical") * Buffboard.SpeedMax * 0.1f, 0f);
    }


    // Update is called once per frame
    void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // Debug.Log(CanSetBomb);
            if (Buffboard.BomeAmountMax - CanBomb >= 1 && CanSetBomb) //可放炸弹数用完不可放炸弹
            {
                Instantiate(bomb, new Vector3(Mathf.RoundToInt(ChildCollider.transform.position.x), Mathf.RoundToInt( ChildCollider.transform.position.y), Mathf.RoundToInt( ChildCollider.transform.position.z)), Quaternion.identity);
                CanBomb += 1;
                CanSetBomb = false;
            }
        }
	}
    public void Buff(GameObject buff)    //吃到buff，判断buff种类，给予对应加成
    {
        if(buff .tag == "BomeAmount")   //加炸弹数上限
        {
            Buffboard.BomeAmountMax += 1;
            if (Buffboard.BomeAmountMax >= 5)
            {
                Buffboard.BomeAmountMax = 5;
            }
            
            Destroy(buff);
        }
        if(buff.tag == "Speed")         //速度上限
        {
            Buffboard.SpeedMax += 0.2f;
            if (Buffboard.SpeedMax >= 2)
            {
                Buffboard.SpeedMax = 2;
            }
            Destroy(buff);
        }
        if (buff.tag == "FirePower")    //炸弹威力上限
        {
            Buffboard.FirPowerMax++;
            if (Buffboard.FirPowerMax >= 8)
            {
                Buffboard.FirPowerMax = 8;
            }
            Destroy(buff);
        }
       
    }
    void OnTriggerEnter2D(Collider2D  collision)
    {       
            Buff(collision.gameObject);
            //Debug.Log("tag:"+collision.collider .tag); 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.tag == "fire" || collision.rigidbody.tag == "Enemy")
        {
            isPlayerDie = true;
            Destroy(gameObject);
        }

    }
}
