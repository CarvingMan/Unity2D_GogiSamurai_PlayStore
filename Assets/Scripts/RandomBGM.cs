using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    GameStart_FadeOut gs;
    AudioSource audioSource;
    AudioDirector audioDirector;

    public AudioClip[] Music = new AudioClip[7]; // ����� BGM

    // Start is called before the first frame update
    void Start()
    {
        //gs = GetComponent<GameStart_FadeOut>();
        audioSource = GetComponent<AudioSource>();
        audioDirector = GetComponent<AudioDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == false && GameStart_FadeOut.isMessageWait == false)//gs.isMessageWait == false) //���� ����� �ҽ��� ����ٸ�
        {
            // �ٽ� �������� bgm�� ��� ��Ų��.
            audioSource.clip = Music[Random.Range(0, Music.Length)];
            audioSource.Play();
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true); //���Ұ�
        }
    }
}