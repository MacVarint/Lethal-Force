using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoText : MonoBehaviour
{
    public int minValue;
    public int maxValue;
    public TMP_Text text;

    private void Awake()
    {
       text = GetComponent<TMP_Text>(); 
    }
    // Update is called once per frame
 
    public void UpdateText(int minValue, int maxValue)
    {
        string AmmoCount = minValue.ToString();
        AmmoCount += " / ";
        AmmoCount += maxValue.ToString();
        text.text = AmmoCount;
    }
}
