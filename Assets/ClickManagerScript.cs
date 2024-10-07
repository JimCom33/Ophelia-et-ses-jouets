using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManagerScript : MonoBehaviour
{

    float moveSpeed = 3;
    float moveAccuracy = 0.15f;


    public Transform player;
    public void GoToItem(ItemData item)
    {

        StartCoroutine(MoveToPoint(item.goToPoint.position));
       

    }

    public IEnumerator MoveToPoint(Vector2 point)
    {

        // set direction
        Vector2 positionDifference = point - (Vector2)player.position;

        // stop when we are near the point
        while (positionDifference.magnitude > moveAccuracy)
        {


            // move in direction frame by frame
            player.Translate(moveSpeed*positionDifference.normalized*Time.deltaTime);
            yield return null;

            // set direction
            positionDifference = point - (Vector2)player.position;

        }

        player.position = point;

        yield return null;

    }

}
