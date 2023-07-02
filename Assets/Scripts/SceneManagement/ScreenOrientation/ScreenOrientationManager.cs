using UnityEngine;

public class ScreenOrientationManager : MonoBehaviour
{
    [Header("Ориентация экрана текущей сцены:")]
    [SerializeField] private ScreenOrientation _targetOrientation = ScreenOrientation.Portrait;



    public void Awake()
    {
        Screen.orientation = _targetOrientation;
    }
}
