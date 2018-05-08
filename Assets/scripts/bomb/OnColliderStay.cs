using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColliderStay : MonoBehaviour {
    
    public Collider2D boxcollider;
    // Use this for initialization
    // ******************************** Player离开炸弹就不能穿透炸弹 ******************************************

   
    void Start ()
    {
        boxcollider =this.GetComponent<Collider2D>();
        boxcollider.isTrigger = true ;
     
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject .tag == "Player")
        {
            boxcollider.isTrigger = false ;
            playerControl.CanSetBomb = true;
        }
    }
}
