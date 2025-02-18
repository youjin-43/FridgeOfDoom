using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    #region SINGLETON
    private static InGameUIManager instance;
    public  static InGameUIManager Instance
    {
        get
        {
            return instance;
        }
        private set 
        {
            // 왜 접근하려 함? 돌아버린거냐
        }
    }

    void SingletonInitialize()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    [SerializeField] private UI_ControlIndicator UI_ControlIndicator;
    [SerializeField] private UI_Minimap          UI_Minimap;
    [SerializeField] private UI_Timer            UI_Timer;

    public UI_ControlIndicator ControlIndicator => UI_ControlIndicator;
    public UI_Minimap         Minimap           => UI_Minimap;
    public UI_Timer           Timer             => UI_Timer;

    void Awake()
    {
        SingletonInitialize();
    }
}
