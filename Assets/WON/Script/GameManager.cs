using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("���� ������Ʈ")]
    [SerializeField] TextMeshProUGUI aeMa; //��1��ǥ�� �ؽ�Ʈ
    [SerializeField] GameObject beforeSceneObject;

    [Header("������")]
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
         aeMa.text = "����� ��1�� : �׼�1";
        if (whatAeMa == 2)
            aeMa.text = "����� ��1�� : �׼�2";
        if (whatAeMa == 3)
            aeMa.text = "����� ��1�� : �׼�3";
        if (whatAeMa == 4)
            aeMa.text = "����� ��1�� : �׼�4";
        if (whatAeMa == 5)
            aeMa.text = "����� ��1�� : ��";
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
            print("��1�¸�");
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse2")
        {
            WhoVictory = 2;
            print("��2�¸�");
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse3")
        {
            WhoVictory = 3;
            print("��3�¸�");
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse4")
        {
            WhoVictory = 4;
            print("��4�¸�");
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse5")
        {
            WhoVictory = 5;
            print("��5�¸�");
            Invoke("sceneMove", 3f);
        }
    }
}
