using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleAndRotateSlider : MonoBehaviour
{

    private Slider scaleSlider;
    private Slider rotateSlider;

    public float minScaleValue;
    public float maxScaleValue;

    public float minRotValue;
    public float maxRotValue;

    void Start()
    {

        scaleSlider = GameObject.Find("ScaleSlider").GetComponent<Slider>();
        scaleSlider.minValue = minScaleValue;
        scaleSlider.maxValue = maxScaleValue;

        scaleSlider.onValueChanged.AddListener(ScaleListener);

        rotateSlider = GameObject.Find("RotateSlider").GetComponent<Slider>();
        rotateSlider.minValue = minRotValue;
        rotateSlider.maxValue = maxRotValue;

        rotateSlider.onValueChanged.AddListener(RotateListener);
    }

    private void RotateListener(float value)
    {
        this.gameObject.transform.localEulerAngles = new Vector3(transform.rotation.x, value, transform.rotation.z);
    }

    private void ScaleListener(float value)
    {
        this.gameObject.transform.localScale = new Vector3(value, value, value);
    }
}
