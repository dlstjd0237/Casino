using UnityEngine;
using System.Collections;

public class horse1 : MonoBehaviour
{
    //1º¸ 1~3.2cm
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
            int movement = Random.Range(10, 32);
            transform.position += new Vector3(0, movement, 0) * Time.deltaTime;
            sec = Random.Range(0.4f, 0.6f);//0.4~0.6
            yield return new WaitForSeconds(sec);
        } 
    }

}
