using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text counterText;

    public float seconds, minutes;

    void Start ()
    {
        counterText = GetComponent<Text>() as Text;
    }

    void Update () 
    {
        minutes = (int)(Time.time/60f);
        seconds = (int)(Time.time % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}