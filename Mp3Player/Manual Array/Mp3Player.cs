using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudio.Wave; //Import NAudio Library
using TMPro;
using System.IO;

public class Mp3Player : MonoBehaviour
{
    private AudioSource audioSource;
    private string mp3FilePath;
    string fileName;

    // For UI
    public TextMeshProUGUI list1;
    public TextMeshProUGUI list2;
    public TextMeshProUGUI list3;
    public TextMeshProUGUI list4;
    public TextMeshProUGUI list5;
    string fileName1 = "";
    string fileName2 = "";
    string fileName3 = "";
    string fileName4 = "";
    string fileName5 = "";

    //For Source Path
    string mp3Path1 = "";
    string mp3Path2 = "";
    string mp3Path3 = "";
    string mp3Path4 = "";
    string mp3Path5 = "";

    void Start()
    {
        string persistentDataPath = Application.persistentDataPath;
        string[] files = Directory.GetFiles(persistentDataPath);

        // gatau buat apa, takut butuh
        int pathCount = 0; 

        
        foreach (string file in files)
        {
            // For Source Path
            if (file.ToLower().EndsWith(".mp3"))
            {
                if (string.IsNullOrEmpty(fileName1))
                {
                    fileName1 = Path.GetFileName(file);
                }
                else if (string.IsNullOrEmpty(fileName2))
                {
                    fileName2 = Path.GetFileName(file);
                }
                else if (string.IsNullOrEmpty(fileName3))
                {
                    fileName3 = Path.GetFileName(file);
                }
                else if (string.IsNullOrEmpty(fileName4))
                {
                    fileName4 = Path.GetFileName(file);
                }
                else if (string.IsNullOrEmpty(fileName5))
                {
                    fileName5 = Path.GetFileName(file);
                }
                // dst
            }
            if (file.ToLower().EndsWith(".mp3"))
            {
                // For UI
                switch (pathCount)
                {
                    case 0:
                        mp3Path1 = file;
                        break;
                    case 1:
                        mp3Path2 = file;
                        break;
                    case 2:
                        mp3Path3 = file;
                        break;
                    case 3:
                        mp3Path4 = file;
                        break;
                    case 4:
                        mp3Path5 = file;
                        break;
                        //dst
                }
                pathCount++;
                if (pathCount >= 5)
                {
                    break;
                }
            }
        }

        // For UI
        list1.text = fileName1;
        list2.text = fileName2;
        list3.text = fileName3;
        list4.text = fileName4;
        list5.text = fileName5;

        audioSource = GetComponent <AudioSource>();

        //mp3FilePath = Application.persistentDataPath + "/record.mp3";
        
        //fileName = System.IO.Path.GetFileName(mp3FilePath);
        //pathUI.text = fileName;

    }

    string Playpath;

    public void PlayM1()
    {
        Debug.Log(mp3Path1);
        Playpath = mp3Path1;
        StartCoroutine(PlayMP3());
    }
    public void Play2()
    {
        Debug.Log(mp3Path2);
        Playpath = mp3Path2;
        StartCoroutine(PlayMP3());
    }
    public void Play3()
    {
        Debug.Log(mp3Path3);
        Playpath = mp3Path3;
        StartCoroutine(PlayMP3());
    }
    public void Play4()
    {
        Debug.Log(mp3Path4);
        Playpath = mp3Path4;
        StartCoroutine(PlayMP3());
    }
    public void Play5()
    {
        Debug.Log(mp3Path5);
        Playpath = mp3Path5;
        StartCoroutine(PlayMP3());
    }

    public void PlayMp3M()
    {
        StartCoroutine(PlayMP3());
    }
    public void StopAud()
    {
        audioSource.Stop();
    }

    IEnumerator PlayMP3()
    {    
        AndroidJavaObject player = new AndroidJavaObject("android.media.MediaPlayer");
        
        player.Call("setDataSource", Playpath); // Source Path

        player.Call("prepare");
        player.Call("start"); 
        yield return new WaitForSeconds((float)player.Call<int>("getDuration") / 1000);     
        player.Call("release");       
        OnPlaybackFinished();
    }

    void OnPlaybackFinished()
    {
        Debug.Log("MP3 playback finished.");
    }
}
