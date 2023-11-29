using UnityEngine.SceneManagement;
using UnityEngine;

public class selectManager : MonoBehaviour
{
    [Header("버튼들")]
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject button4;
    [SerializeField] GameObject button5;

    [Header("기타")]
    public int howAema = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "select")
        {
            if (button1.GetComponent<HB1>().horse1 == true)
            {
                howAema = 1;
                DontDestroyOnLoad(gameObject);
                SceneManager.LoadScene("dfd");
            }
            if (button2.GetComponent<HB2>().horse2 == true)
            {
                howAema = 2;
                DontDestroyOnLoad(gameObject);
                SceneManager.LoadScene("dfd");
            }
            if (button3.GetComponent<HB3>().horse3 == true)
            {
                howAema = 3;
                DontDestroyOnLoad(gameObject);
                SceneManager.LoadScene("dfd");
            }
            if (button4.GetComponent<HB4>().horse4 == true)
            {
                howAema = 4;
                DontDestroyOnLoad(gameObject);
                SceneManager.LoadScene("dfd");
            }
            if (button5.GetComponent<HB5>().horse5 == true)
            {
                howAema = 5;
                DontDestroyOnLoad(gameObject);
                SceneManager.LoadScene("dfd");
            }
        }
    }
}
