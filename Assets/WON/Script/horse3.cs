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
        while (true)
        {
            int movement = Random.Range(65, 70);
            transform.position += new Vector3(0, movement, 0) * Time.deltaTime;
            print(movement);
            sec = Random.Range(2f, 3f);//1~2
            yield return new WaitForSeconds(sec);
        }
    }
}
