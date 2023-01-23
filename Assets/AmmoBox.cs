using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int ammoCount;
    public enum AmmoboxType{
     STANDARD,
     AP
    }
    public enum Caliber
    {
        ACP45,
        GUAGE12,
        LAPUA338,
        SOVIET762
    }

    public AmmoboxType ammoboxType;

    public class Pickable
    {

    }

    public class Mouse : Pickable
    {

    }
}
