using System.Collections;
using TMPro;
using UnityEngine;

public class Count_down : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_Text;
    [SerializeField]
    private int countdowntime = 3;
    
    float temp;

    private void OnEnable()
    {
        StartCoroutine(StartCountDown());
    }

    IEnumerator StartCountDown()
    {
        temp = countdowntime;
        Time.timeScale = 0;

        while(temp > 0)
        {
            temp = temp - Time.unscaledDeltaTime;
            m_Text.text = ((int)(temp + 1)).ToString();
            yield return null;
        }

        m_Text.text = "GO";
        temp = 0;

        while (temp < 1)
        {
            temp += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = 1.2f;
        Destroy(gameObject);
    }
}
