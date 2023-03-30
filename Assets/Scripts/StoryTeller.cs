using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryTeller : MonoBehaviour
{
    public static StoryTeller instance = null;
    public List<string> phrases;
    public bool isConsoleSelected = false;
    private PrintingText text;
    private int currentPhrase = 0;
    public GameObject[] windows;
    private GameObject playerText;
    private TextMeshProUGUI trackName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if (GameObject.FindGameObjectWithTag("MainText") != null)
            text = GameObject.FindGameObjectWithTag("MainText").GetComponent<PrintingText>();
    }

    public void ActivateStory()
    {
        windows = gameManager.instance.windows;
        foreach (GameObject window in windows)
        {
            window.GetComponent<WindowsMoving>().CloseWindow();
        }
        text = GameObject.FindGameObjectWithTag("MainText").GetComponent<PrintingText>();
        text.SetFirstPhrase(phrases[currentPhrase]);
        StartCoroutine("FirstWindow");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isConsoleSelected)
            {
                currentPhrase++;
                if (phrases[currentPhrase] != "end")
                {
                    text.ChangeText(phrases[currentPhrase]);
                }
                else
                {
                    Application.Quit();
                }
                switch(currentPhrase)
                {
                    case 5: windows[2].GetComponent<WindowsMoving>().OpenWindow(); break;
                    case 7: windows[1].GetComponent<WindowsMoving>().OpenWindow(); break;
                    case 11: windows[3].GetComponent<WindowsMoving>().OpenWindow(); SoundManager.Singleton.SwitchTrack(); trackName.text = "sprkls.exe"; break;
                    case 16: windows[4].GetComponent<WindowsMoving>().OpenWindow(); break;
                    case 18: windows[1].GetComponent<WindowsMoving>().CloseWindow(); windows[5].GetComponent<WindowsMoving>().OpenWindow(); SoundManager.Singleton.SwitchTrack(); trackName.text = "Sleepy Gardens"; break;
                    case 25: windows[5].GetComponent<WindowsMoving>().CloseWindow(); windows[6].GetComponent<WindowsMoving>().OpenWindow(); SoundManager.Singleton.SwitchTrack(); trackName.text = "Train to the City"; break;
                    case 29: windows[6].GetComponent<WindowsMoving>().CloseWindow(); windows[7].GetComponent<WindowsMoving>().OpenWindow(); SoundManager.Singleton.SwitchTrack(); trackName.text = "Bar Songs"; break;
                    case 33: SoundManager.Singleton.SwitchTrack(); break;
                    case 37: SoundManager.Singleton.SwitchTrack(); trackName.text = "A Boy Who Gets Lost Sometimes"; break;
                    case 42: SoundManager.Singleton.SwitchTrack(); trackName.text = "Bar Songs"; break;
                    case 43: SoundManager.Singleton.SwitchTrack(); trackName.text = "Outrun"; break;
                    case 44: SoundManager.Singleton.SwitchTrack(); trackName.text = "Found and Lost"; break;
                    case 45: SoundManager.Singleton.SwitchTrack(); trackName.text = "Voices from the past"; break;
                    case 46: SoundManager.Singleton.SwitchTrack(); trackName.text = "Daydreaming"; break;
                    case 47: SoundManager.Singleton.SwitchTrack(); break;
                    case 49: SoundManager.Singleton.SwitchTrack(); break;
                    case 51: foreach (GameObject window in windows) { window.GetComponent<WindowsMoving>().CloseWindow(); } break;
                }
            }
        }
    }

    IEnumerator FirstWindow()
    {
        yield return new WaitForSeconds(3);
        windows[0].GetComponent<WindowsMoving>().OpenWindow();
        SoundManager.Singleton.SwitchTrack();
        playerText = GameObject.FindGameObjectWithTag("PlayerText");
        trackName = playerText.GetComponent<TextMeshProUGUI>();
        trackName.text = "Nightcoming";
    }
}
