using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CrawlWalk : MonoBehaviour
{
    public float duration = 0.0f;

    public AllLegControl alc;
    public walkToggleAction wta;

    private bool isRunning = false;

    public float xTrajGen1;
    public float zTrajGen1;

    public float xTrajGen2;
    public float zTrajGen2;

    public float xTrajGen3;
    public float zTrajGen3;

    public float xTrajGen4;
    public float zTrajGen4;

    public float xTrajGen5;

    public vInputRead vin;

    public inverseKinematic inki;

    public GameObject sp;

    public GameObject body;

    public Vector3 sppos;

    public float spstst = 0.0f;
    public float bdstst = 0.0f;

    public float onePhaseValue = 0f;

    public walkmotionselect wms;

    private void Start()
    {
        duration = 1.5f;
    }

    void Update()
    {
        if (wta.canWalk == true && wms.walkmotion == false)
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

    private IEnumerator RunNumber(float start, float end, float duration)
    {
        if (isRunning) yield break;
        isRunning = true;

        bdstst = body.transform.position.x;
        spstst = sp.transform.position.x;

        //Debug.Log("Start new loop");

        alc.FR.rotationSpeed1 = 500;
        alc.FR.rotationSpeed2 = 500;
        alc.FL.rotationSpeed1 = 500;
        alc.FL.rotationSpeed2 = 500;
        alc.RR.rotationSpeed1 = 500;
        alc.RR.rotationSpeed2 = 500;
        alc.RL.rotationSpeed1 = 500;
        alc.RL.rotationSpeed2 = 500;

        float v = float.Parse(vin.vInput.text);

        float[] phaseStarts = { 0f, 180f, 240f, 300f };
        float[] phaseEnds = { 180f, 240f, 300f, 360f };
        float phaseDuration = duration / 4f;

        float[] currentValues = new float[4];

        float elapsed = 0f;


        while (elapsed < duration)
        {
            sppos = sp.transform.position;
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
                //Debug.Log($"CurrentValue{i + 1}: {currentValues[i]}");
            }

            onePhaseValue = Mathf.Lerp(0f, v, elapsed / duration);
            //Debug.Log($"CurrentValue: {onePhaseValue}");

            float rd1 = currentValues[0] * (Mathf.PI / 180);
            xTrajGen1 = (v / 2) * (1 - Mathf.Cos(rd1));
            zTrajGen1 = (v / 2) * (Mathf.Sin(rd1)) * -1;
            if (currentValues[0] > 180 && currentValues[0] < 360)
            {
                zTrajGen1 = 0;
            }

            float rd2 = currentValues[1] * (Mathf.PI / 180);
            xTrajGen2 = (v / 2) * (1 - Mathf.Cos(rd2));
            zTrajGen2 = (v / 2) * (Mathf.Sin(rd2)) * -1;
            if (currentValues[1] > 180 && currentValues[1] < 360)
            {
                zTrajGen2 = 0;
            }

            float rd3 = currentValues[2] * (Mathf.PI / 180);
            xTrajGen3 = (v / 2) * (1 - Mathf.Cos(rd3));
            zTrajGen3 = (v / 2) * (Mathf.Sin(rd3)) * -1;
            if (currentValues[2] > 180 && currentValues[2] < 360)
            {
                zTrajGen3 = 0;
            }

            float rd4 = currentValues[3] * (Mathf.PI / 180);
            xTrajGen4 = (v / 2) * (1 - Mathf.Cos(rd4));
            zTrajGen4 = (v / 2) * (Mathf.Sin(rd4)) * -1;
            if (currentValues[3] > 180 && currentValues[3] < 360)
            {
                zTrajGen4 = 0;
            }

            alc.FR.SetTargetAngles(inki.inKine(xTrajGen1, 0, 2.83f + zTrajGen1).Item1, inki.inKine(xTrajGen1, 0, 2.83f + zTrajGen1).Item2);
            alc.FL.SetTargetAngles(inki.inKine(xTrajGen3, 0, 2.83f + zTrajGen3).Item1, inki.inKine(xTrajGen3, 0, 2.83f + zTrajGen3).Item2);
            alc.RR.SetTargetAngles(inki.inKine(xTrajGen2, 0, 2.83f + zTrajGen2).Item1, inki.inKine(xTrajGen2, 0, 2.83f + zTrajGen2).Item2);
            alc.RL.SetTargetAngles(inki.inKine(xTrajGen4, 0, 2.83f + zTrajGen4).Item1, inki.inKine(xTrajGen4, 0, 2.83f + zTrajGen4).Item2);

            body.transform.position = new Vector3(bdstst + onePhaseValue, body.transform.position.y, body.transform.position.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        //Debug.Log($"Final Value: {end}");

        isRunning = false;
    }
}
