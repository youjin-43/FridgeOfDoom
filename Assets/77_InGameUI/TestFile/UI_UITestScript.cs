using UnityEngine;

public class UI_UITestScript : MonoBehaviour
{
    private void Start()
    {
        if (InGameUIManager.Instance.Minimap != null)
        {
            Debug.Log("미니맵 할당 완료");
        }
        if (InGameUIManager.Instance.Timer != null)
        {
            Debug.Log("타이머 할당 완료");
        }
        if (InGameUIManager.Instance.GameStatus != null)
        {
            Debug.Log("게임상태 할당 완료");
        }
        if (InGameUIManager.Instance.SkillIndicator != null)
        {
            Debug.Log("스킬창 할당 완료");
        }

        InGameUIManager.Instance.StartTimer(180f);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("좌클릭 스킬 발동");
            InGameUIManager.Instance.UseSkill(0, 2);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("우클릭 스킬 발동");
            InGameUIManager.Instance.UseSkill(1, 1f);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Shift 스킬 발동");
            InGameUIManager.Instance.UseSkill(KeyCode.LeftShift, 5);

            InGameUIManager.Instance.AddDagger(1);
        }
    }
}
