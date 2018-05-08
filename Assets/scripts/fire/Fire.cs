using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour 
{
    //private float firelength;

    //public bool fireTouchBomb = false;
    public void InsFire(GameObject fire, int FirPowerMax)
    {
        //playerControl firepower = new playerControl(); 
        LayerMaskName layerMask = new LayerMaskName();
        //原地炸弹火
        Instantiate(fire,transform .position , Quaternion.identity);
        
        for (int i = 1; i <= FirPowerMax ; i++) //右炸弹火
        {
            //hit block
            RaycastHit2D hit = Physics2D.Raycast(transform .position , Vector2.right, i, layerMask.layerMask_Block);
            RaycastHit2D hit_wall = Physics2D.Raycast(transform.position, Vector2.right, i , layerMask.layerMask_Wall);
            //if (!hit .collider && i== 1 )
            //{
            //    Instantiate(fire, transform.position + Vector3.right * i, Quaternion.identity);
            //}
            if (!hit.collider && !hit_wall .collider )
            {
                Instantiate(fire, transform.position + Vector3.right * i, Quaternion.identity);
            }
            else if (hit_wall.collider)
            {
                Instantiate(fire, transform.position + Vector3.right * i, Quaternion.identity);
                break;
            }
            //else if (hit_wall.collider && i==firepower.FirPowerMax)
            //{
            //    Instantiate(fire, transform.position + Vector3.right * i, Quaternion.identity);
            //    break;
            //}
            else break;
        }
        for (int i = 1; i <= FirPowerMax; i++) //左炸弹火
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, i, layerMask.layerMask_Block);
            RaycastHit2D hit_wall = Physics2D.Raycast(transform.position, Vector2.left , i, layerMask.layerMask_Wall);

            if (!hit.collider&& !hit_wall.collider)
            {
                Instantiate(fire, transform.position + Vector3.left  * i, Quaternion.identity);
            }
            else if (hit_wall.collider)
            {
                Instantiate(fire, transform.position + Vector3.left * i, Quaternion.identity);
                break;
            }
            else break;
        }
        for (int i = 1; i <= FirPowerMax; i++) //上炸弹火
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, i, layerMask.layerMask_Block);
            RaycastHit2D hit_wall = Physics2D.Raycast(transform.position, Vector2.up , i, layerMask.layerMask_Wall);
            if (!hit.collider&& !hit_wall.collider)
            {
                Instantiate(fire, transform.position + Vector3.up * i, Quaternion.identity);
            }
            else if (hit_wall.collider)
            {
                Instantiate(fire, transform.position + Vector3.up * i, Quaternion.identity);
                break;
            }
            else break;
        }
        for (int i = 1; i <= FirPowerMax; i++) //下炸弹火
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, i, layerMask.layerMask_Block);
            RaycastHit2D hit_wall = Physics2D.Raycast(transform.position, Vector2.down , i, layerMask.layerMask_Wall);
            if (!hit.collider&& !hit_wall.collider)
            {
                Instantiate(fire, transform.position + Vector3.down  * i, Quaternion.identity);
            }
            else if (hit_wall.collider)
            {
                Instantiate(fire, transform.position + Vector3.down * i, Quaternion.identity);
                break;
            }
            else break;
        }

       
    }
    
}
