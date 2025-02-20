using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UI_SkillIndicator : MonoBehaviour
{
    // 스킬 쿨타임 이펙트
    private Image _skill_Shift_CooldownEffect;
    private Image _skill_LClick_CooldownEffect;
    private Image _skill_RClick_CooldownEffect;

    // 스킬 비활성화 이펙트(우클릭(단검 던지기) 전용)
    private Image _skillActivation;

    // 단검 갯수 카운터
    private List<GameObject> _daggerCounter = new List<GameObject>();

    void Awake()
    {
        // 쿨타임 이펙트
        _skill_Shift_CooldownEffect  = transform.GetChild(0).transform.GetChild(1).GetComponent<Image>();
        _skill_LClick_CooldownEffect = transform.GetChild(1).transform.GetChild(1).GetComponent<Image>();
        _skill_RClick_CooldownEffect = transform.GetChild(2).transform.GetChild(1).GetComponent<Image>();

        _skill_Shift_CooldownEffect.gameObject.SetActive(false);
        _skill_LClick_CooldownEffect.gameObject.SetActive(false);
        _skill_RClick_CooldownEffect.gameObject.SetActive(false);

        // 스킬 비활성화 이펙트(우클릭(단검 던지기) 전용)
        _skillActivation = transform.GetChild(2).GetChild(2).GetComponent<Image>();
        _skillActivation.gameObject.SetActive(false);

        // 단검 갯수 카운트
        Transform daggerCounter = transform.GetChild(2).GetChild(4).transform;

        for(int i = 0; i < 5; ++i)
        {
            _daggerCounter.Add(daggerCounter.GetChild(i).GetChild(0).gameObject);
        }
    }

    #region COOLDOWN
    public void StartCooldownEffect(KeyCode key, float cooldownTime)
    {
        StartCoroutine(CooldownEffect(_skill_Shift_CooldownEffect, cooldownTime));
    }

    public void StartCooldownEffect(int button, float cooldownTime)
    {
        // 좌클릭
        if (button == 0)
        {
            StartCoroutine(CooldownEffect(_skill_LClick_CooldownEffect, cooldownTime));
        }
        // 우클릭
        else if (button == 1)
        {
            DaggerCountOff();
            StartCoroutine(CooldownEffect(_skill_RClick_CooldownEffect, cooldownTime));
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
    #endregion

    #region DAGGERCOUNT
    public void DaggerCountOn(int count)
    {
        _skillActivation.gameObject.SetActive(false);

        int tmp = 0;

        foreach(GameObject counter in _daggerCounter)
        {
            if(tmp == count)
            {
                break;
            }

            if(counter.activeSelf == false)
            {
                counter.SetActive(true);
                ++tmp;
            }
        }
    }

    public void DaggerCountOff()
    {
        for(int i = 4; i >= 0; --i)
        {
            if(_daggerCounter[i].activeSelf == true)
            {
                // 마지막 단검까지 카운터를 Off한다는 뜻은
                // 전부 다 던졌다는 소리
                // 그렇다면 우클릭은 비활성화 이펙트 ON
                if(i == 0)
                {
                    _skillActivation.gameObject.SetActive(true);
                    //Color color = _skill_RClick_CooldownEffect.color;
                    //_skill_RClick_CooldownEffect.color = new Color(color.r, color.g, color.b, 0f);
                }

                _daggerCounter[i].SetActive(false);
                return;
            }
        }
    }
    #endregion
}
