using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horse5 : MonoBehaviour
{
    //1º¸ 0~1.3cm
    float sec;
    void Start()
    {
        StartCoroutine(Moving());
    }


    IEnumerator Moving()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            int movement = Random.Range(0, 13);
            transform.position += new Vector3(0, movement, 0) * Time.deltaTime;
            sec = Random.Range(0.1f, 0.2f);//0.1~0.2
            yield return new WaitForSeconds(sec);
        }
    }
}
