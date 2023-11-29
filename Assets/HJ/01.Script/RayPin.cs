using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPin : MonoBehaviour
{
    [SerializeField] float distance;

    public string RayDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);

        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);

        string hitname = hit.collider.gameObject.name;

        if (hit.collider != null)
        {
            Debug.Log("충돌한 오브젝트: " + hitname);
        }
        else if(hit.collider == null)
        {
            hitname = "+5000";
        }

        return hitname;
    }
}
