using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    AudioSource audioSource;
    AudioDirector audioDirector;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioDirector = GetComponent<AudioDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == false) //���� ����� �ҽ��� ����ٸ�
        {
            audioDirector.RandomPlay(); // �ٽ� �������� bgm�� ��� ��Ų��.
        }

        if (GameDirector.hp <= 0)
        {
            audioDirector.SoundMute(true); //���Ұ�
        }
    }
}