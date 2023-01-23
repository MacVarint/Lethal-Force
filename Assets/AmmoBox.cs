using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoBoxSize;
    public enum ammoboxType{
     STANDARD,
     AP
    }
    public enum caliber
    {
        ACP45,
        GUAGE12,
        LAPUA338,
        SOVIET762
    }

    public class Pickable
    {

    }

    public class Mouse : Pickable
    {

    }
}
