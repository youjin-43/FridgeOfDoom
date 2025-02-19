using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_SkillIndicator : MonoBehaviour
{
    // Cooldown Effect Sprite
    private Image _skill_LClick_Image;
    private Image _skill_RClick_Image;
    private Image _skill_Space_Image;
    private Image _skill_Shift_Image;

    void Awake()
    {
        // Cooldown Effect
        _skill_LClick_Image = transform.GetChild(0).transform.GetChild(1).GetComponent<Image>();
        _skill_RClick_Image = transform.GetChild(1).transform.GetChild(1).GetComponent<Image>();
        _skill_Space_Image  = transform.GetChild(2).transform.GetChild(1).GetComponent<Image>();
        _skill_Shift_Image  = transform.GetChild(3).transform.GetChild(1).GetComponent<Image>();

        _skill_LClick_Image.gameObject.SetActive(false);
        _skill_RClick_Image.gameObject.SetActive(false);
        _skill_Space_Image.gameObject.SetActive(false);
        _skill_Shift_Image.gameObject.SetActive(false);
    }

    public void StartCooldownEffect(KeyCode key, float cooldownTime)
    {
        if(key == KeyCode.Space)
        {
            StartCoroutine(CooldownEffect(_skill_Space_Image, cooldownTime));
        }
        else if(key == KeyCode.LeftShift)
        {
            StartCoroutine(CooldownEffect(_skill_Shift_Image, cooldownTime));
        }
    }

    public void StartCooldownEffect(int button, float cooldownTime)
    {
        // 좌클릭
        if (button == 0)
        {
            StartCoroutine(CooldownEffect(_skill_LClick_Image, cooldownTime));
        }
        // 우클릭
        else if (button == 1)
        {
            StartCoroutine(CooldownEffect(_skill_RClick_Image, cooldownTime));
        }
    }

    private IEnumerator CooldownEffect(Image coolDownImage, float cooldownTime)
    {
        coolDownImage.gameObject.SetActive(true);
        coolDownImage.fillAmount = 1f;

        float elapsedTime = 0f;

        while(elapsedTime < cooldownTime)
        {
            elapsedTime += Time.deltaTime;
            coolDownImage.fillAmount = 1f - (elapsedTime / cooldownTime);
            yield return null;
        }

        coolDownImage.gameObject.SetActive(false);
    }
}
