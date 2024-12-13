using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class SliderValueReader : MonoBehaviour
{
    public Slider sqslider;

    public TWODOF FR;
    public TWODOF FL;
    public TWODOF RR;
    public TWODOF RL;

    public inverseKinematic ink;
    void Start()
    {
        sqslider.value = 0.5f;

        sqslider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        Debug.Log(value);
        FR.rotationSpeed1 = 45;
        FR.rotationSpeed2 = 90;
        FL.rotationSpeed1 = 45;
        FL.rotationSpeed2 = 90;
        RR.rotationSpeed1 = 45;
        RR.rotationSpeed2 = 90;
        RL.rotationSpeed1 = 45;
        RL.rotationSpeed2 = 90;

        float ofs = (2 * value) +2;

        FR.SetTargetAngles(ink.inKine(0f, 0f, ofs).Item1, ink.inKine(0f, 0f, ofs).Item2);
        FL.SetTargetAngles(ink.inKine(0f, 0f, ofs).Item1, ink.inKine(0f, 0f, ofs).Item2);
        RR.SetTargetAngles(ink.inKine(0f, 0f, ofs).Item1, ink.inKine(0f, 0f, ofs).Item2);
        RL.SetTargetAngles(ink.inKine(0f, 0f, ofs).Item1, ink.inKine(0f, 0f, ofs).Item2);
    }
}
