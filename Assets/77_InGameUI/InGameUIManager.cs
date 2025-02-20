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

    public UI_Minimap          Minimap        { get; private set; }
    public UI_Timer            Timer          { get; private set; }
    public UI_GameStatus       GameStatus     { get; private set; }
    public UI_SkillIndicator   SkillIndicator { get; private set; }

    void Awake()
    {
        SingletonInitialize();

        // UI �Ҵ�
        Minimap        = transform.GetChild(0).GetComponent<UI_Minimap>();
        Timer          = transform.GetChild(1).GetComponent<UI_Timer>();
        GameStatus     = transform.GetChild(2).GetComponent<UI_GameStatus>();
        SkillIndicator = transform.GetChild(3).GetComponent<UI_SkillIndicator>();
    }

    #region TIMER
    /// <summary>
    /// ���尡 ���۵� �� ȣ���� �ּ���
    /// </summary>
    /// <param name="time">���� ���ѽð� �Դϴ�.</param>
    public void StartTimer(float time)
    {
        Timer.StartTimer(time);
    }
    #endregion


    #region GAME STATUS

    #endregion

    #region SKILL INDICATOR
    /// <summary>
    /// �÷��̾ ��ų�� ����ϸ� UI�� �����ǰ� �ϴ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="key">� Ű(Ű����)�� ��ų�� ����߳���?</param>
    /// <param name="time">�� ��ų�� ��Ÿ���� �����ΰ���?</param>
    public void UseSkill(KeyCode key, float time)
    {
        SkillIndicator.StartCooldownEffect(key, time);
    }

    /// <summary>
    /// �÷��̾ ��ų�� ����ϸ� UI�� �����ǰ� �ϴ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="button">� ��ư(���콺)�� ��ų�� ����߳���?</param>
    /// <param name="time">�� ��ų�� ��Ÿ���� �����ΰ���?</param>
    public void UseSkill(int button, float time)
    {
        SkillIndicator.StartCooldownEffect(button, time);
    }

    /// <summary>
    /// �ܰ� ������ ������ �� ȣ���� �ּ���
    /// </summary>
    public void AddDagger(int count = 1)
    {
        if(count == 0)
        {
            return;
        }

        SkillIndicator.DaggerCountOn(count);
    }
    #endregion
}