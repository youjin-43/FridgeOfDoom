using System.Collections;
using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{
    private TextMeshProUGUI _timerText;

    void Awake()
    {
        _timerText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void StartTimer(float time)
    {
        StartCoroutine(SetTimer(time));
    }

    private IEnumerator SetTimer(float time)
    {
        float timer = time;

        while(timer > 0)
        {
            yield return null;

            timer -= Time.deltaTime;
            _timerText.text = $"{(int)(timer / 60)} : {(int)(timer % 60):D2}";
        }
    }
}
