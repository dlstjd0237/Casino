using UnityEngine;

public class ScreenSet : MonoBehaviour
{
    [SerializeField] private int _setWidth, _setHeight;

    private void Awake()
    {
        SetResolution();
    }

    private void SetResolution()
    {

        int deviceWidth = Screen.width;
        int deviceHeight = Screen.height; 

        Screen.SetResolution(_setWidth, (int)(((float)deviceHeight / deviceWidth) * _setWidth), true);
    }
}
