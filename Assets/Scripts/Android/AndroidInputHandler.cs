using IMG.SceneManagement;
using UnityEngine;

public class AndroidInputHandler : MonoBehaviour    //  ���������� ����� ������ ������� ���������
{
    private SceneLoader _loader;

    private KeyCode _backKey = KeyCode.Escape;
    private KeyCode _menuKey = KeyCode.Menu;

    public enum ButtonAction
    {
        None,
        Back,
        Exit
    }

    [Header("�������� ������ '�����':")]
    [SerializeField] private ButtonAction _backButtonAction = ButtonAction.Back;

    [Space(10f)]
    [Header("�������� ������ '����':")]
    [SerializeField] private ButtonAction _menuButtonAction = ButtonAction.None;






    private void OnEnable()
    {
        _loader = FindObjectOfType<SceneLoader>();
        Debug.Log($"AndroidInput: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name} {_loader.name}");
    }

    private void Update()
    {
        if (Input.GetKey(_backKey) == true)
        {
            DoButtonAction(_backButtonAction);
        }

        if (Input.GetKey(_menuKey) == true)
        {
            DoButtonAction(_menuButtonAction);
        }
    }

    private void DoButtonAction(ButtonAction buttonAction)
    {
        switch (buttonAction)
        {
            case ButtonAction.None:
                break;

            case ButtonAction.Back:
                GoToPreviousScene();
                break;

            case ButtonAction.Exit:
                AplicationQuit();
                break;

            default:
                break;
        }
    }

    public void TestGoPrevious()
    {
        GoToPreviousScene();
    }

    private void GoToPreviousScene()
    {
        if (_loader != null)
        {
            _loader.StartLoadPreviousScene();
        }
        else
        {
            Debug.LogError("����������� ��������� �����!");
        }
    }

    private void AplicationQuit()
    {
        Application.Quit();
    }
}
