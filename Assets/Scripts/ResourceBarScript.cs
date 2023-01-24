using ObjectStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBarScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private StatsScript stats;
    [SerializeField] private string nowvalueStatName = null;
    [SerializeField] private string maxvalueStatName = null;
    [SerializeField] private float maxvalueValue = 1f;
    [SerializeField] private float minvalueValue = 0f;
    public float value;
    [SerializeField] private Color color;


    private void Start()
    {
        gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("ScreenDynamicUI").transform);
    }

    private void Update()
    {
        if (stats.ContainsStat(nowvalueStatName)) slider.value = stats.GetStatValue(nowvalueStatName);
        value = stats.GetStatValue(nowvalueStatName);


    }

    public void Destroy()
    {
        Destroy(this);
    }

    public void SetStat(StatsScript statContainer, string currentvalueStatName, float maximumvalueValue = 1, float minimumValue = 0)
    {
        stats = statContainer;
        nowvalueStatName = currentvalueStatName;
        maxvalueStatName = null;
        maxvalueValue = maximumvalueValue;
        minvalueValue = minimumValue;
        UpdateSlider();
    }

    public void SetStat(StatsScript statContainer, string currentvalueStatName, string maximumvalueStatName, float minimumValue = 0)
    {
        stats = statContainer;
        nowvalueStatName = currentvalueStatName;
        maxvalueStatName = maximumvalueStatName;
        maxvalueValue = stats.GetStatValue(maximumvalueStatName);
        minvalueValue = minimumValue;
        UpdateSlider();
    }

    public void SetMaxValue(float value = 1)
    {
       maxvalueValue = value;
       if(maxvalueStatName != null) maxvalueValue = stats.GetStatValue(maxvalueStatName);
        UpdateSlider();

    }

    public void SetValues(string targetStatName)
    {
        slider.maxValue = stats.GetStatValue(targetStatName);
        UpdateSlider();
    }

    public void SetColor(Color resourceColor)
    {
        color = resourceColor;
        UpdateColor(color);
    }

    private void UpdateColor(Color resourceColor)
    {
        slider.colors.normalColor.Equals(resourceColor);
    }

    private void UpdateSlider()
    {
        slider.minValue = minvalueValue; 
        slider.maxValue = maxvalueValue;   
    }



}
