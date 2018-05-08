using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskName  {

    public LayerMask layerMask_Block = 1 << 10;
    public LayerMask layerMask_Player = 1 << 9;
    public LayerMask layerMask_Map = 1 << 8;
    public LayerMask layerMask_Bomb = 1 << 11;
    public LayerMask layerMask_Enemy = 1 << 13;
    public LayerMask layerMask_Wall = 1 << 14;
}
