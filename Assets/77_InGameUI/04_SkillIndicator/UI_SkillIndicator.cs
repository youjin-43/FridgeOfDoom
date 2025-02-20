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

        // 단검 갯수 카운트
        Transform daggerCounter = transform.GetChild(2).GetChild(3).transform;

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
                _daggerCounter[i].SetActive(false);
                return;
            }
        }
    }
    #endregion
}
