using System.Collections;
using UnityEngine;

public class horse2 : MonoBehaviour
{
    //1�� 2cm
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
            transform.position += new Vector3(0, 20, 0) * Time.deltaTime;
            sec = Random.Range(0.4f, 0.6f);//0.4~0.6
            yield return new WaitForSeconds(sec);
        }
    }
}
