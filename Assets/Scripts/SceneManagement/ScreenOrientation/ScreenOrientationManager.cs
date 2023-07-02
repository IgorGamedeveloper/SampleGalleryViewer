using UnityEngine;

public class ScreenOrientationManager : MonoBehaviour
{
    [Header("���������� ������ ������� �����:")]
    [SerializeField] private ScreenOrientation _targetOrientation = ScreenOrientation.Portrait;



    public void Awake()
    {
        Screen.orientation = _targetOrientation;
    }
}
