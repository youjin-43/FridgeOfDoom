using UnityEngine;

public class UI_UITestScript : MonoBehaviour
{
    private void Start()
    {
        if (InGameUIManager.Instance.Minimap != null)
        {
            Debug.Log("�̴ϸ� �Ҵ� �Ϸ�");
        }
        if (InGameUIManager.Instance.Timer != null)
        {
            Debug.Log("Ÿ�̸� �Ҵ� �Ϸ�");
        }
        if (InGameUIManager.Instance.GameStatus != null)
        {
            Debug.Log("���ӻ��� �Ҵ� �Ϸ�");
        }
        if (InGameUIManager.Instance.SkillIndicator != null)
        {
            Debug.Log("��ųâ �Ҵ� �Ϸ�");
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("��Ŭ�� ��ų �ߵ�");
            InGameUIManager.Instance.UseSkill(0, 2);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("��Ŭ�� ��ų �ߵ�");
            InGameUIManager.Instance.UseSkill(1, 3);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space ��ų �ߵ�");
            InGameUIManager.Instance.UseSkill(KeyCode.Space, 4);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Shift ��ų �ߵ�");
            //InGameUIManager.Instance.UseSkill(KeyCode.Space, 5);

            InGameUIManager.Instance.SkillIndicator.DaggerCountOn(1);
        }
    }
}
