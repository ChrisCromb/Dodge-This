using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    SettingsData sD;

    public AudioSource[] musicArray;

    public AudioSource[] sfxArray;

    public AudioClip[] musicOptions;

    public GameObject backupSettingsData;
    void Awake()
    {
        sD = FindObjectOfType<SettingsData>();
        if(sD == null)
        {
            GameObject bSD = Instantiate(backupSettingsData);
            sD = bSD.GetComponent<SettingsData>();
        }

        foreach(AudioSource aS in musicArray)
        {
            aS.volume = sD.musicVol;
        }
        foreach (AudioSource aS in sfxArray)
        {
            aS.volume = sD.sfxVol;
        }
        if(sD.gameObject.GetComponent<LevelData>().selectedLevel == 9)
        {
            musicArray[0].clip = musicOptions[1];
            musicArray[0].Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
