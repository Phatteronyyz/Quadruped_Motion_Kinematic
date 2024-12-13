using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inverseKinematic : MonoBehaviour
{
    private float gamma = 1f;
    private float r;

    public float xx,yy,zz;

    public void callin()
    {
        //inKine(xx, yy, zz);
        Debug.Log("x " + xx + " y " + yy + " z " + zz);
    }

    public Tuple<float, float> inKine(float z, float y, float x)
    {
        y = 0;
        float l1 = 2.0f, l2 = 2.0f;
        float th1, th2;

        float r = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2));

        float c = (Mathf.Pow(r,2) - Mathf.Pow(l1,2) - Mathf.Pow(l2,2)) / (2 * l1 * l2) ;
        float s = gamma * Mathf.Sqrt(1 - Mathf.Pow(c,2));

        float bta = Mathf.Atan2(l2 * s, (l2 * c) +  l1);

        float apa = Mathf.Atan2(z, x);


        th1 = apa - bta;
        th2 = Mathf.Atan2(s,c);



        th1 = (180 / Mathf.PI * th1);
        th2 = (180 / Mathf.PI * th2);

        return Tuple.Create(th1, th2);
    }
}
