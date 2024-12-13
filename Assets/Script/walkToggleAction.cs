using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walkToggleAction : MonoBehaviour
{
    public Toggle actionToggle;
    public AllLegControl alc;
    public CrawlWalk crw;


    public DummyControl dmc;

    public bool canWalk;

    void Start()
    {
        if (actionToggle != null)
        {
            actionToggle.onValueChanged.AddListener(OnToggleChanged);
        }
    }

    void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            canWalk = true;
        }
        else
        {
            canWalk = false;

            alc.FR.SetTargetAngles(-45, 90);
            alc.FL.SetTargetAngles(-45, 90);
            alc.RR.SetTargetAngles(-45, 90);
            alc.RL.SetTargetAngles(-45, 90);

            dmc.DM1.SetTargetAngles(-45, 90);
            dmc.DM2.SetTargetAngles(-45, 90);
        }
    }
}
