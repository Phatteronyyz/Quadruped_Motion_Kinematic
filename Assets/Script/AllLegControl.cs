using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLegControl : MonoBehaviour
{
    public Transform body;

    public TWODOF FR;
    public TWODOF FL;
    public TWODOF RR;
    public TWODOF RL;

    public SliderValueReader sli;

    public GameObject eBody;

    public GameObject FRJ0;
    public GameObject FRTJ0;
    public GameObject FRED;

    public GameObject FLJ0;
    public GameObject FLTJ0;
    public GameObject FLED;

    public GameObject RRJ0;
    public GameObject RRTJ0;
    public GameObject RRED;

    public GameObject RLJ0;
    public GameObject RLTJ0;
    public GameObject RLED;

    public GameObject eTBody;

    private void Start()
    {
        SetHomePosition();
    }

    void Update()
    {
        Vector3 bodyPosition = body.position;

        eBody.transform.position = bodyPosition;
        eBody.transform.rotation = body.rotation;

        eTBody.transform.position = bodyPosition;

        Vector3 FRjoint1Position = FR.joint1.position;
        Vector3 FRendEffectorPosition = FR.endEffector.position;

        FRJ0.transform.position = FRjoint1Position;
        FRED.transform.position = FRendEffectorPosition;
        FRTJ0.transform.position = FRjoint1Position;
        FRJ0.transform.rotation = FR.joint1.rotation;
        FRED.transform.rotation = FR.endEffector.rotation;

        Vector3 FLjoint1Position = FL.joint1.position;
        Vector3 FLendEffectorPosition = FL.endEffector.position;

        FLJ0.transform.position = FLjoint1Position;
        FLED.transform.position = FLendEffectorPosition;
        FLTJ0.transform.position = FLjoint1Position;
        FLJ0.transform.rotation = FL.joint1.rotation;
        FLED.transform.rotation = FL.endEffector.rotation;

        Vector3 RRjoint1Position = RR.joint1.position;
        Vector3 RRendEffectorPosition = RR.endEffector.position;

        RRJ0.transform.position = RRjoint1Position;
        RRED.transform.position = RRendEffectorPosition;
        RRTJ0.transform.position = RRjoint1Position;
        RRJ0.transform.rotation = RR.joint1.rotation;
        RRED.transform.rotation = RR.endEffector.rotation;

        Vector3 RLjoint1Position = RL.joint1.position;
        Vector3 RLendEffectorPosition = RL.endEffector.position;

        RLJ0.transform.position = RLjoint1Position;
        RLED.transform.position = RLendEffectorPosition;
        RLTJ0.transform.position = RLjoint1Position;
        RLJ0.transform.rotation = RL.joint1.rotation;
        RLED.transform.rotation = RL.endEffector.rotation;
    }

    public void SetHomePosition()
    {
        FR.rotationSpeed1 = 45;
        FR.rotationSpeed2 = 90;
        FL.rotationSpeed1 = 45;
        FL.rotationSpeed2 = 90;
        RR.rotationSpeed1 = 45;
        RR.rotationSpeed2 = 90;
        RL.rotationSpeed1 = 45;
        RL.rotationSpeed2 = 90;

        FR.SetTargetAngles(-45, 90);
        FL.SetTargetAngles(-45, 90);
        RR.SetTargetAngles(-45, 90);
        RL.SetTargetAngles(-45, 90);

        Debug.Log("Home position set!");

    }

    public void SetStand()
    {

        FR.rotationSpeed1 = 45;
        FR.rotationSpeed2 = 90;
        FL.rotationSpeed1 = 45;
        FL.rotationSpeed2 = 90;
        RR.rotationSpeed1 = 45;
        RR.rotationSpeed2 = 90;
        RL.rotationSpeed1 = 45;
        RL.rotationSpeed2 = 90;

        FR.SetTargetAngles(0, 0);
        FL.SetTargetAngles(0, 0);
        RR.SetTargetAngles(0, 0);
        RL.SetTargetAngles(0, 0);

        Debug.Log("Stand position set!");
    }

    public void ResetPos()
    {
        body.transform.position = new Vector3(-3f, 6.17f, 1.7f);
        body.transform.rotation = Quaternion.Euler(90, 0, 0);
        SetHomePosition();
    }
}
