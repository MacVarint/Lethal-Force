using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewHeightScript : MonoBehaviour
{
    public Vector3 viewHeight;
    public void SetViewHeight(Vector3 pos)
    {
        transform.localPosition = viewHeight;
        transform.localPosition += pos;
    }

    public void ResetViewHeight()
    {
        transform.localPosition = viewHeight;
    }

 
}
