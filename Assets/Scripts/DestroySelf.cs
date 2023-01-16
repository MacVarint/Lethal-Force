using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    float time = 1;
    private void Start()
    {
        DestroyAfter(time);
    }
    public void DestroyAfter(float t)
    {
        Destroy(gameObject, t);
    }
}
