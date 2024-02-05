using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Watch : MonoBehaviour, ISeasonListener
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Vector3 localAxis;
    [SerializeField] private float deltaAngle;
    [SerializeField] private float speedRotation;

    public void SeasonChangeAction (SeasonType seasonType)
    {
        switch(seasonType)
        {
            case SeasonType.Spring:
                {
                    DeltaRotate(arrow, localAxis, deltaAngle, speedRotation);
                    break;
                }
            case SeasonType.Summer:
                {
                    DeltaRotate(arrow, localAxis, deltaAngle, speedRotation);
                    break;
                }
            case SeasonType.Autumn:
                {
                    DeltaRotate(arrow, localAxis, deltaAngle, speedRotation);
                    break;
                }
            case SeasonType.Winter:
                {
                    DeltaRotate(arrow, localAxis, deltaAngle, speedRotation);
                    break;
                }
            default:
                break;
        }
    }

    void DeltaRotate (GameObject arrow, Vector3 localAxis, float deltaAngle, float speedRotation)
    {
        StartCoroutine(c_RotateDelta(arrow, localAxis, deltaAngle, speedRotation));
    }

    IEnumerator c_RotateDelta (GameObject arrow, Vector3 localAxis, float deltaAngle, float speedRotation)
    {
        float total = 0.0f;

        if(deltaAngle < 0.0f)
        {
            localAxis = -localAxis;
            deltaAngle = -deltaAngle;
        }

        while(true)
        {
            float d = speedRotation * Time.deltaTime;

            total += d;

            if(total > deltaAngle)
            {
                arrow.transform.Rotate(localAxis, deltaAngle - (total - d));

                yield break;
            }
            else
                arrow.transform.Rotate(localAxis, d);

            yield return null;
        }
    }
}
