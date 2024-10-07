using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManagerScript : MonoBehaviour
{

    public Transform player;
    public void GoToItem(ItemData item)
    {
        player.position = item.goToPoint.position;
       

    }


}
