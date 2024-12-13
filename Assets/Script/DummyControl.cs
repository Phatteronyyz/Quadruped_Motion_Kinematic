using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyControl : MonoBehaviour
{
    public TWODOF DM1;
    public TWODOF DM2;

    public GameObject DM1J0;
    public GameObject DM1ED;
    public GameObject DM2J0;
    public GameObject DM2ED;

    public GameObject DM1TJ0;
    public GameObject DM2TJ0;
    void Start()
    {
        DM1.SetTargetAngles(-45, 90);
        DM2.SetTargetAngles(-45, 90);
    }

    void Update()
    {
        Vector3 FRjoint1Position = DM1.joint1.position;
        Vector3 FRendEffectorPosition = DM1.endEffector.position;

        Vector3 RRjoint1Position = DM2.joint1.position;
        Vector3 RRendEffectorPosition = DM2.endEffector.position;

        DM1J0.transform.position = FRjoint1Position;
        DM1ED.transform.position = FRendEffectorPosition;
        DM1J0.transform.rotation = DM1.joint1.rotation;
        DM1ED.transform.rotation = DM1.endEffector.rotation;

        DM2J0.transform.position = RRjoint1Position;
        DM2ED.transform.position = RRendEffectorPosition;
        DM2J0.transform.rotation = DM2.joint1.rotation;
        DM2ED.transform.rotation = DM2.endEffector.rotation;

        DM1TJ0.transform.position = FRjoint1Position;
        DM2TJ0.transform.position = RRjoint1Position;
    }
}
