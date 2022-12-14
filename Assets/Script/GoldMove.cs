using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GoldMoveState
{
    MOVEGOLD
}



public class GoldMove : MonoBehaviour
{
    [SerializeField] private Transform leftposition, rightposition;
    [SerializeField] private float duration;
    public GoldMoveState state = GoldMoveState.MOVEGOLD;
    private float durationToDistance;


    void Start()
    {
        float totalDistance = Vector3.Distance(transform.position, rightposition.position) + Vector3.Distance(leftposition.position, rightposition.position) * 1.5f;
        durationToDistance = Vector3.Distance(transform.position, rightposition.position) / totalDistance * duration;

    }

    void Update()
    {
        if (this.isActiveAndEnabled)
        {
            switch (state)
            {
                case GoldMoveState.MOVEGOLD:
                    StartCoroutine(MoveGold(duration));
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator MoveGold(float time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = new Vector3(Random.Range(leftposition.transform.position.x, rightposition.transform.position.x), Random.Range(leftposition.transform.position.y, rightposition.transform.position.y), 0);
        durationToDistance = Vector3.Distance(startingPos, finalPos) / Vector3.Distance(transform.position, rightposition.position) + Vector3.Distance(leftposition.position, rightposition.position) * 1.5f * duration;
        float elapsedTime = 0;

        while (elapsedTime < durationToDistance)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / durationToDistance));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }


}
