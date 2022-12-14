using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum GoldMoveState
{
    ENDMOVE,
    GOLEFT,
    GORIGHT
}
public class GoldMove : MonoBehaviour
{
    [SerializeField] private Transform leftposition, rightposition;
    [SerializeField] private float duration = 2f;
    public GoldMoveState state = GoldMoveState.GORIGHT;
    private float durationToRight;
    private float durationToLeft;

    void Start()
    {
        float totalDistance = Vector3.Distance(transform.position, rightposition.position) + Vector3.Distance(leftposition.position, rightposition.position) * 1.5f;
        durationToRight = Vector3.Distance(transform.position, rightposition.position) / totalDistance * duration;
        durationToLeft = Vector3.Distance(transform.position, leftposition.position) / totalDistance * duration;

    }

    void Update()
    {
        if (this.isActiveAndEnabled)
        {
            switch (state)
            {
                case GoldMoveState.ENDMOVE:
                    break;
                case GoldMoveState.GOLEFT:
                    StartCoroutine(GoRight(durationToLeft));
                    break;
                case GoldMoveState.GORIGHT:
                    StartCoroutine(GoRight(durationToRight));
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator GoRight(float time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = rightposition.position;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        state = GoldMoveState.GOLEFT;
    }

    IEnumerator GoLeft(float time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = leftposition.position;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        state = GoldMoveState.GORIGHT;
    }
}
