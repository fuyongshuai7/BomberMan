using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //public Transform PlayerPos;
    private Vector2 Director;
    //private float ChangeTargetTime;
    //private float FixedTime;
    //private int Horizontal;
    //private  int Vertical;
    //private Vector2 RandomTarget;
    private int Distance;
    private LayerMaskName layerMask;
    private int NoTargetDirector; 
    public static bool isEnemyDie;
    private void Awake()
    {
        isEnemyDie = false;
        layerMask = new LayerMaskName();
        Distance = 26;
        //ChangeTargetTime = 0;
        //FixedTime = 5f;
        NoTargetDirector = Random.Range(0, 3);
        //Horizontal = Random.Range(-13, 13);
        //Vertical = Random.Range(-9, 9);
        //RandomTarget = new Vector2(Horizontal, Vertical);
    }
    //private void Start()
    //{
    //    InvokeRepeating("ChangeDirector", 0f, 1f);
    //}
    private void FixedUpdate()
    {
        EnemyBehaviour();
    }
    private void Update()
    {
        HaveTarget();
       // Debug.Log(HaveTarget());
    }
    private bool HaveTarget()
    {
        //
        //RaycastHit2D -> layerMask_Player
        //
        RaycastHit2D hit_up = Physics2D.Raycast(transform.position,Vector2 .up, Distance , layerMask.layerMask_Player);
        RaycastHit2D hit_down = Physics2D.Raycast(transform.position, Vector2.down,Distance, layerMask.layerMask_Player);
        RaycastHit2D hit_left = Physics2D.Raycast(transform.position, Vector2.left,Distance, layerMask.layerMask_Player);
        RaycastHit2D hit_right = Physics2D.Raycast(transform.position, Vector2.right,Distance, layerMask.layerMask_Player);
        //
        //RaycastHit2D -> layerMask_Block
        //
        RaycastHit2D hit_up_block = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.up, layerMask.layerMask_Block);
        RaycastHit2D hit_down_block = Physics2D.Raycast(transform.position, Vector2.down, 1, layerMask.layerMask_Block);
        RaycastHit2D hit_left_block = Physics2D.Raycast(transform.position, Vector2.left, 1, layerMask.layerMask_Block);
        RaycastHit2D hit_right_block = Physics2D.Raycast(transform.position, Vector2.right, 1, layerMask.layerMask_Block);

        if (hit_up.collider && !hit_up_block)
        {
            Director = Vector2.up;
            return true;
        }
        if (hit_down.collider && !hit_down_block)
        {
            Director = Vector2.down;
            return true;
        }
        if (hit_left.collider && !hit_left_block)
        {
            Director = Vector2.left;
            return true;
        }
        if (hit_right.collider && !hit_right_block)
        {
            Director = Vector2.right;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void NoTargetMove()
    {

        RaycastHit2D hit_up_block = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.up*0.5f, layerMask.layerMask_Block);
        RaycastHit2D hit_down_block = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.down*0.5f, layerMask.layerMask_Block);
        RaycastHit2D hit_left_block = Physics2D.Linecast(transform.position , (Vector2)transform.position + Vector2.left*0.5f, layerMask.layerMask_Block);
        RaycastHit2D hit_right_block = Physics2D.Linecast(transform.position , (Vector2)transform.position + Vector2.right*0.5f, layerMask.layerMask_Block);

        RaycastHit2D hit_up_wall = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.up * 0.5f, layerMask.layerMask_Wall );
        RaycastHit2D hit_down_wall = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.down * 0.5f, layerMask.layerMask_Wall);
        RaycastHit2D hit_left_wall = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.left * 0.5f, layerMask.layerMask_Wall);
        RaycastHit2D hit_right_wall = Physics2D.Linecast(transform.position, (Vector2)transform.position + Vector2.right * 0.5f, layerMask.layerMask_Wall);

        //Debug.Log(NoTargetDirector);
        //Debug.Log(Mathf.Abs(transform.position.y - Mathf.RoundToInt(transform.position.y)));
        //Debug.Log(Mathf.Abs(transform.position.x - Mathf.RoundToInt(transform.position.x)));

        switch (NoTargetDirector)
        {
            case 0:
                if (!hit_up_block && !hit_up_wall)
                {
                    transform.Translate(Vector2.up * Time.deltaTime * 1.5f);
                }
                if (Mathf.Abs(transform.position.y - Mathf.RoundToInt(transform.position.y))< 0.01f|| hit_up_block || hit_up_wall)
                {
                    ChangeDirector();
                    
                }
                break;
            case 1:
                if (!hit_down_block && !hit_down_wall)
                {
                    transform.Translate(Vector2.down * Time.deltaTime*1.5f);
                }
                if (Mathf.Abs(transform.position.y - Mathf.RoundToInt(transform.position.y)) < 0.01f || hit_down_block || hit_down_wall)
                {
                    ChangeDirector();
                }
                break;
            case 2:
                if (!hit_left_block && !hit_left_wall)
                {
                    transform.Translate(Vector2.left * Time.deltaTime*1.5f);
                }
                if (Mathf.Abs(transform.position.x - Mathf.RoundToInt(transform.position.x )) < 0.01f || hit_left_block || hit_left_wall)
                {
                    ChangeDirector();
                }
                break;
            case 3:
                if (!hit_right_block && !hit_right_wall)
                {
                    transform.Translate(Vector2.right * Time.deltaTime*1.5f);
                }
                if (Mathf.Abs(transform.position.x - Mathf.RoundToInt(transform.position.x)) < 0.01f || hit_right_block || hit_right_wall)
                {
                    ChangeDirector();
                }
                break;

        }
    }

    private void ChangeDirector()
    {
        NoTargetDirector = Random.Range(0, 4);
    }

    private void GotoTarget()
    {
        transform.Translate(Director*Time .deltaTime*3f );
    }
    //
    //Enemy行为
    //
    public void EnemyBehaviour()
    {
        if (HaveTarget())
        {
            GotoTarget();
        }
        else
        {
            NoTargetMove();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider .tag == "fire")
        {
            isEnemyDie = true;
            Destroy(this.gameObject);
        }
    }
}