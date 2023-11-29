using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("霸烙 坷宏璃飘")]
    [SerializeField] TextMeshProUGUI aeMa; //局1付钎矫 咆胶飘
    [SerializeField] GameObject beforeSceneObject;

    [Header("函荐盖")]
    int whatAeMa = 0;
    int WhoVictory = 0;


    void Start()
    {
        beforeSceneObject = GameObject.Find("selectManager");
        whatAeMa = beforeSceneObject.GetComponent<selectManager>().howAema;
        aeMaSelect();
    }
    void aeMaSelect()
    {
        if(whatAeMa == 1)
         aeMa.text = "寸教狼 局1付 : 雷己1";
        if (whatAeMa == 2)
            aeMa.text = "寸教狼 局1付 : 雷己2";
        if (whatAeMa == 3)
            aeMa.text = "寸教狼 局1付 : 雷己3";
        if (whatAeMa == 4)
            aeMa.text = "寸教狼 局1付 : 雷己4";
        if (whatAeMa == 5)
            aeMa.text = "寸教狼 局1付 : 怪";
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "scene1")
        {
            Destroy(gameObject,10f);
        }
    }

    void sceneMove()
    {
        //SceneManager.LoadScene("end");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "horse1")
        {
            WhoVictory = 1;
            print("富1铰府");
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse2")
        {
            WhoVictory = 2;
            print("富2铰府");
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse3")
        {
            WhoVictory = 3;
            print("富3铰府");
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse4")
        {
            WhoVictory = 4;
            print("富4铰府");
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse5")
        {
            WhoVictory = 5;
            print("富5铰府");
            Invoke("sceneMove", 3f);
        }
    }
}
