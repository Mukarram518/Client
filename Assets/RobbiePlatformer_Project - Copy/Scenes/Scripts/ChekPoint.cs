using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RespawnOnDeath.lastChekPointPos = transform.position;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
