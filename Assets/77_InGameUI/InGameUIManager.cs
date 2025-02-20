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

    public UI_Minimap          Minimap        { get; private set; }
    public UI_Timer            Timer          { get; private set; }
    public UI_GameStatus       GameStatus     { get; private set; }
    public UI_SkillIndicator   SkillIndicator { get; private set; }

    void Awake()
    {
        SingletonInitialize();

        // UI 할당
        Minimap        = transform.GetChild(0).GetComponent<UI_Minimap>();
        Timer          = transform.GetChild(1).GetComponent<UI_Timer>();
        GameStatus     = transform.GetChild(2).GetComponent<UI_GameStatus>();
        SkillIndicator = transform.GetChild(3).GetComponent<UI_SkillIndicator>();
    }

    #region TIMER
    /// <summary>
    /// 라운드가 시작될 때 호출해 주세요
    /// </summary>
    /// <param name="time">라운드 제한시간 입니다.</param>
    public void StartTimer(float time)
    {
        Timer.StartTimer(time);
    }
    #endregion


    #region GAME STATUS

    #endregion

    #region SKILL INDICATOR
    /// <summary>
    /// 플레이어가 스킬을 사용하면 UI와 연동되게 하는 함수입니다.
    /// </summary>
    /// <param name="key">어떤 키(키보드)의 스킬을 사용했나요?</param>
    /// <param name="time">그 스킬의 쿨타임은 몇초인가요?</param>
    public void UseSkill(KeyCode key, float time)
    {
        SkillIndicator.StartCooldownEffect(key, time);
    }

    /// <summary>
    /// 플레이어가 스킬을 사용하면 UI와 연동되게 하는 함수입니다.
    /// </summary>
    /// <param name="button">어떤 버튼(마우스)의 스킬을 사용했나요?</param>
    /// <param name="time">그 스킬의 쿨타임은 몇초인가요?</param>
    public void UseSkill(int button, float time)
    {
        SkillIndicator.StartCooldownEffect(button, time);
    }

    /// <summary>
    /// 단검 갯수가 증가될 때 호출해 주세요
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