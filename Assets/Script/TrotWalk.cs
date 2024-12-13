using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrotWalk : MonoBehaviour
{
    public float duration = 0.0f;
    public vInputRead vin;
    public walkToggleAction wta;

    public float xTrajGen1;
    public float zTrajGen1;
    public float xTrajGen2;
    public float zTrajGen2;

    public GameObject sp;

    public GameObject body;

    public Vector3 sppos;

    public float spstst = 0.0f;
    public float bdstst = 0.0f;

    private bool isRunning = false;

    public inverseKinematic inki;

    public AllLegControl alc;

    public DummyControl dmc;

    public float onePhaseValue = 0f;

    public walkmotionselect wms;

    void Start()
    {
        duration = 1.5f;

    }

    void Update()
    {
        if (wta.canWalk == true && wms.walkmotion == true)
        {
            if (!isRunning)
            {
                StartCoroutine(RunNumber(0, 360, duration));
            }
        }
        else if (wta.canWalk == false)
        {
            isRunning = false;
            StopAllCoroutines();
        }
    }

    public void callStartCoroutine()
    {
        // duration = float.Parse(vin.vInput.text);
        StartCoroutine(RunNumber(0, 360, duration));
    }
    private IEnumerator RunNumber(float start, float end, float duration)
    {
        if (isRunning) yield break;
        isRunning = true;

        bdstst = body.transform.position.x;

        alc.FR.rotationSpeed1 = 500;
        alc.FR.rotationSpeed2 = 500;
        alc.FL.rotationSpeed1 = 500;
        alc.FL.rotationSpeed2 = 500;
        alc.RR.rotationSpeed1 = 500;
        alc.RR.rotationSpeed2 = 500;
        alc.RL.rotationSpeed1 = 500;
        alc.RL.rotationSpeed2 = 500;

        float v = float.Parse(vin.vInput.text);

        float[] phaseStarts = { 0f, 90f, 180f, 270f };
        float[] phaseEnds = { 90f, 180f, 270f, 360f };
        float phaseDuration = duration / 4f;

        float[] currentValues = new float[4];

        Vector3 DM1footpos = dmc.DM1ED.transform.localPosition;
        Vector3 DM2footpos = dmc.DM2ED.transform.localPosition;
        Vector3 FRfootpos = alc.FRED.transform.localPosition;
        // Debug.Log(dmc.DM1ED.transform.localPosition);

        float elapsed = 0f;

        while (elapsed < duration)
        {
            int phaseIndex = Mathf.FloorToInt((elapsed / duration) * 4);
            phaseIndex = Mathf.Clamp(phaseIndex, 0, 3);

            float phaseStart = phaseStarts[phaseIndex];
            float phaseEnd = phaseEnds[phaseIndex];

            float phaseElapsed = (elapsed - phaseIndex * phaseDuration) / phaseDuration;

            for (int i = 0; i < currentValues.Length; i++)
            {
                int adjustedPhaseIndex = (phaseIndex + i) % 4;
                float adjustedPhaseStart = phaseStarts[adjustedPhaseIndex];
                float adjustedPhaseEnd = phaseEnds[adjustedPhaseIndex];

                currentValues[i] = Mathf.Lerp(adjustedPhaseStart, adjustedPhaseEnd, phaseElapsed);
                Debug.Log($"CurrentValue{i + 1}: {currentValues[i]}");
            }

            onePhaseValue = Mathf.Lerp(0f, v, elapsed / duration);

            float rd1 = currentValues[0] * (Mathf.PI / 180);
            xTrajGen1 = (v / 2) * (1 - Mathf.Cos(rd1));
            zTrajGen1 = (v / 2) * (Mathf.Sin(rd1)) * -1;
            if (currentValues[0] > 180 && currentValues[0] < 360)
            {
                zTrajGen1 = 0;
            }

            float rd2 = currentValues[2] * (Mathf.PI / 180);
            xTrajGen2 = (v / 2) * (1 - Mathf.Cos(rd2));
            zTrajGen2 = (v / 2) * (Mathf.Sin(rd2)) * -1;
            if (currentValues[2] > 180 && currentValues[2] < 360)
            {
                zTrajGen2 = 0;
            }

            alc.FR.SetTargetAngles(inki.inKine(xTrajGen2, 0, 2.83f + zTrajGen2).Item1, inki.inKine(xTrajGen2, 0, 2.83f + zTrajGen2).Item2);
            alc.FL.SetTargetAngles(inki.inKine(xTrajGen1, 0, 2.83f + zTrajGen1).Item1, inki.inKine(xTrajGen1, 0, 2.83f + zTrajGen1).Item2);
            alc.RR.SetTargetAngles(inki.inKine(xTrajGen1, 0, 2.83f + zTrajGen1).Item1, inki.inKine(xTrajGen1, 0, 2.83f + zTrajGen1).Item2);
            alc.RL.SetTargetAngles(inki.inKine(xTrajGen2, 0, 2.83f + zTrajGen2).Item1, inki.inKine(xTrajGen2, 0, 2.83f + zTrajGen2).Item2);

            body.transform.position = new Vector3(bdstst + onePhaseValue, body.transform.localPosition.y, body.transform.localPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        isRunning = false;
    }


}