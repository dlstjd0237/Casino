using System.Collections;
using UnityEngine;

public class horse2 : MonoBehaviour
{
    //1º¸ 2cm
    float sec;
    void Start()
    {
        StartCoroutine(Moving());
    }


    IEnumerator Moving()
    {
        while (true)
        {
            transform.position += new Vector3(0, 20, 0) * Time.deltaTime;
            print("moving");
            sec = Random.Range(0.4f, 0.5f);//0.4~0.5
            yield return new WaitForSeconds(sec);
        }
    }
}
