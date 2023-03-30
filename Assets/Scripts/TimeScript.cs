using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScript : MonoBehaviour
{

    public TextMeshProUGUI text;
    private string minutesString;
    private string hoursString;
    private string AMPM;
    private int hourInTwelve;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentDate = System.DateTime.Now;
        if (currentDate.Minute < 10)
        {
            minutesString = '0' + currentDate.Minute.ToString();
        }
        else
        {
            minutesString = currentDate.Minute.ToString();
        }
        hourInTwelve = currentDate.Hour;
        if (hourInTwelve >= 12)
        {
            hourInTwelve -= 12;
            hoursString = (hourInTwelve).ToString();
        }
        else
        {
            hoursString = hourInTwelve.ToString();
        }
        if (hourInTwelve < 6)
        {
            AMPM = "AM";
        }
        else
        {
            AMPM = "PM";
        }
        text.text = hoursString + ':' + minutesString + ' ' + AMPM; 
    }
}
