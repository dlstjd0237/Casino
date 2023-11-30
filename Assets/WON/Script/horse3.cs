using System.Collections;
using UnityEngine;

public class horse3 : MonoBehaviour
{
    //3º¸ 7cm
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
            int movement = Random.Range(70, 75);
            transform.position += new Vector3(0, movement, 0) * Time.deltaTime;
            sec = Random.Range(1.2f, 2.5f);//1.2~2.5
            yield return new WaitForSeconds(sec);
        }
    }
}
