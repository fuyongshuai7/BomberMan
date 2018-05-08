using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTest : MonoBehaviour {
    //
    //1.声明关于事件的委托
    //
    public delegate void LearnEvent(string st);
    //
    //2.声明事件
    //
    public event LearnEvent MyEvent;
    //
    //3.编写触发事件的函数
    //
    public void LearningEvent(string st)
    {
        if (MyEvent != null)
        {
            MyEvent(st);
        }
    }
    //
    //4.创建事件处理程序
    //
    public void startLearnEvent(string st)
    {
        Debug.Log(st);
    }
    //
    //5.实例化委托
    //
    private void Start()
    {
        MyEvent += new LearnEvent(startLearnEvent);//5.实例化委托
        LearningEvent("正在学习Event...");//触发事件
    }
}
public class eventTest2
{
    //1.声明一个委托
    public delegate void LearnEventEventHandler(string st);
    //2.声明事件
    public event LearnEventEventHandler MyEvent;
    //3.编写触发事件的函数
    public void EventTrigger(string st)
    {
        if (MyEvent != null)
        {
            MyEvent(st);
        }
    }
    //4.创建事件处理程序
    public void StartEvent(string st)
    {
        Debug.Log(st);

    }
    //5.实例化事件
    void Awake()
    {
        MyEvent += new LearnEventEventHandler(StartEvent);
        MyEvent("Start Event...");

    }
}


public class BombEvent
{
    public delegate void WhenBombExplosionEventHandler(GameObject gobj_bomb, GameObject gobj_fire);

    public event WhenBombExplosionEventHandler WhenBombExplosion;

    public void BombExplosion(GameObject gobj_bomb ,GameObject gobj_fire)
    {
        if (WhenBombExplosion != null)
        {
            WhenBombExplosion(gobj_bomb ,gobj_fire);
        }
    }

    public void WhenBombExlosion(GameObject gobj_bomb, GameObject gobj_fire)
    {
        GameObject.Destroy(gobj_bomb);
        Fire fire = new Fire();
        //fire.InsFire(gobj_fire);
        playerControl.CanBomb--;
    }

    //Enumerator Bommm()
    //{
    //  yield return new WaitForSeconds(bombseconds);
    //  WhenBombExplosion += new WhenBombExplosionEventHandler(WhenBombExplosion);
    //  BombExplosion(gobj_bomb, gobj_fire);
    //}
}

