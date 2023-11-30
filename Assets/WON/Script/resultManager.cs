using UnityEngine;
using TMPro;

public class resultManager : MonoBehaviour
{
    [Header("���� ������Ʈ")]
    [SerializeField] TextMeshProUGUI aeMa;
    [SerializeField] TextMeshProUGUI whoVic;
    [SerializeField] GameObject beforeSceneObject;
    //����
    [SerializeField] GameObject victory2;
    [SerializeField] GameObject lose;

    [Header("������")]
    [SerializeField] int AeMa = 0;
    [SerializeField] int WhoVictory = 0;

    void Start()
    {
        beforeSceneObject = GameObject.Find("endLine");
        AeMa = beforeSceneObject.GetComponent<GameManager>().whatAeMa;
        WhoVictory = beforeSceneObject.GetComponent<GameManager>().WhoVictory;
        youWinOrLose();
        whoWin();
    }

    void youWinOrLose()
    {
        if(AeMa == WhoVictory)
        {
            aeMa.text = "�̰��";
            Instantiate(victory2, this.transform.position, this.transform.rotation);
        }
        else
        {
            aeMa.text = "����";
            Instantiate(lose, this.transform.position, this.transform.rotation);
        }
    }

    void whoWin()
    {
        string mun =  " is Win!!";
        whoVic.text = "No." + WhoVictory+mun;
    }
    void Update()
    {
        
    }
}
