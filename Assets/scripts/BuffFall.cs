using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFall : MonoBehaviour {

    public GameObject Buff_BomeAmount;
    public GameObject Buff_Speed;
    public GameObject Buff_FirePower;

    protected  void RandomBuff(Vector3 Pos)
    {
        GameObject buff = null;
        int r = Random.Range(0, 3);
        switch (r)
        {
            case 0: buff = Buff_BomeAmount;
                break;
            case 1:buff = Buff_Speed;
                break;
            case 2:buff = Buff_FirePower;
                break;
            default :break;
        }
        Instantiate(buff ,Pos ,Quaternion .identity);
    }
}
