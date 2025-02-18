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
            // �� �����Ϸ� ��? ���ƹ����ų�
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
