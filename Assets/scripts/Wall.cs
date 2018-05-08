using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : BuffFall {
    //private BuffFall rbuff;
    //private void Awake()
    //{
    //    rbuff = gameObject.AddComponent<BuffFall>();   
    //}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.tag == "fire")
        {
            int r = Random.Range(0, 5); //20%出buff
            if (r == 0)
            {
                RandomBuff(transform.position);
            }
            Destroy(gameObject);
        }
        
    }

  
}



