using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class tiltSlider : MonoBehaviour
{
    public Slider tslider1;
    public Slider tslider2;

    public TWODOF FR;
    public TWODOF FL;
    public TWODOF RR;
    public TWODOF RL;
    public GameObject body;

    public inverseKinematic ink;

    public float thetaXDeg, thetaYDeg;  

    void Start()
    {
        tslider1.value = 0.5f;

        tslider1.onValueChanged.AddListener(OnSliderValueChanged1);

        tslider2.value = 0.5f;

        tslider2.onValueChanged.AddListener(OnSliderValueChanged2);
    }

    void OnSliderValueChanged1(float value)
    {
        float tiltedlevel1 = 0.5f - tslider1.value;

        tslider2.value = 0.5f;
        thetaXDeg = tiltedlevel1 * 30;

        Debug.Log("tilevel X : " + thetaXDeg);

        FR.rotationSpeed1 = 15;
        FR.rotationSpeed2 = 30;
        RR.rotationSpeed1 = 15;
        RR.rotationSpeed2 = 30;

        FL.rotationSpeed1 = 15;
        FL.rotationSpeed2 = 30;
        RL.rotationSpeed1 = 15;
        RL.rotationSpeed2 = 30;

        float rd = (tiltedlevel1 * 30) * (Mathf.PI / 180);
        float ofs = 1.5f * Mathf.Tan(rd);

        Debug.Log("ang : " + tiltedlevel1 * 30);
        Debug.Log("ofs : " + ofs);

        FR.SetTargetAngles(ink.inKine(0f, 0f, ofs + 2.83f).Item1, ink.inKine(0f, 0f, ofs + 2.83f).Item2);
        RR.SetTargetAngles(ink.inKine(0f, 0f, ofs + 2.83f).Item1, ink.inKine(0f, 0f, ofs + 2.83f).Item2);

        FL.SetTargetAngles(ink.inKine(0f, 0f, 2.83f - ofs).Item1, ink.inKine(0f, 0f, 2.83f - ofs).Item2);
        RL.SetTargetAngles(ink.inKine(0f, 0f, 2.83f - ofs).Item1, ink.inKine(0f, 0f, 2.83f - ofs).Item2);

        //OnSliderValueChanged3(thetaXDeg, thetaYDeg);
    }

    void OnSliderValueChanged2(float value)
    {
        float tiltedlevel2 = 0.5f - tslider2.value;

        tslider1.value = 0.5f;

        thetaYDeg = tiltedlevel2 * 30;
        Debug.Log("tilevel Y : " + thetaYDeg);

        FR.rotationSpeed1 = 15;
        FR.rotationSpeed2 = 30;
        RR.rotationSpeed1 = 15;
        RR.rotationSpeed2 = 30;

        FL.rotationSpeed1 = 15;
        FL.rotationSpeed2 = 30;
        RL.rotationSpeed1 = 15;
        RL.rotationSpeed2 = 30;

        float rd = (tiltedlevel2 * 30) * (Mathf.PI / 180);
        float ofs = 4f * Mathf.Tan(rd);

        RR.SetTargetAngles(ink.inKine(0f, 0f, ofs + 2.83f).Item1, ink.inKine(0f, 0f, ofs + 2.83f).Item2);
        RL.SetTargetAngles(ink.inKine(0f, 0f, ofs + 2.83f).Item1, ink.inKine(0f, 0f, ofs + 2.83f).Item2);

        FR.SetTargetAngles(ink.inKine(0f, 0f, 2.83f - ofs).Item1, ink.inKine(0f, 0f, 2.83f - ofs).Item2);
        FL.SetTargetAngles(ink.inKine(0f, 0f, 2.83f - ofs).Item1, ink.inKine(0f, 0f, 2.83f - ofs).Item2);

        //OnSliderValueChanged3(thetaXDeg, thetaYDeg);
    }
}
