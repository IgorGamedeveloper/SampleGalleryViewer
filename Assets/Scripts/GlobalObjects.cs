using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlobalObjects : MonoBehaviour  //  ’–¿Õ»À»Ÿ≈ Õ≈ ”Õ»◊“Œ∆¿ﬁŸ»’—ﬂ Œ¡‹≈ “Œ¬ (œ–»—”“—“¬”ﬁŸ»’ ¬  ¿∆ƒŒ… —÷≈Õ≈)
{
    public static GlobalObjects Instance { get; private set; }

    [SerializeField] private Camera _camera;
    [SerializeField] private EventSystem _eventSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        CheckObject<Camera>(ref _camera);
        CheckObject<EventSystem>(ref _eventSystem);
    }

    private void CheckObject<T>(ref T targetObject) where T : Component
    {
        if (targetObject == null) 
        { 
            targetObject = FindAnyObjectByType<T>() as T;

            if (targetObject == null) 
            {
                targetObject = new Object() as T;
            }
        }
    }
}
