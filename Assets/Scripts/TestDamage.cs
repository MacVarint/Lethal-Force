using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class TestDamage : MonoBehaviour
{
    [SerializeField] private Vignette vignette;

    private void Start()
    {
        vignette = GetComponent<Vignette>();    
    }
    private void Update()
    {
        vignette.intensity.value = 2;
    }
}
