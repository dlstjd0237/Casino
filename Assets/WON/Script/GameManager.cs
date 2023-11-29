using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("���� ������Ʈ")]
    [SerializeField] TextMeshProUGUI aeMa; //��1��ǥ�� �ؽ�Ʈ
    [SerializeField] GameObject beforeSceneObject;

    [Header("������")]
    public int whatAeMa = 0;
    public int WhoVictory = 0;
    bool ming = false;


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
        if (SceneManager.GetActiveScene().name == "result")
        {
            Destroy(gameObject,10f);
        }
    }

    void sceneMove()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("result");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "horse1" && ming == false)
        {
            WhoVictory = 1;
            print("��1�¸�");
            ming = true;
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse2" && ming == false)
        {
            WhoVictory = 2;
            print("��2�¸�");
            ming = true;
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse3" && ming == false)
        {
            WhoVictory = 3;
            print("��3�¸�");
            ming = true;
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse4" && ming == false)
        {
            WhoVictory = 4;
            print("��4�¸�");
            ming = true;
            Invoke("sceneMove", 3f);
        }
        if (collision.collider.tag == "horse5" && ming == false)
        {
            WhoVictory = 5;
            print("��5�¸�");
            ming = true;
            Invoke("sceneMove", 3f);
        }
    }
}
