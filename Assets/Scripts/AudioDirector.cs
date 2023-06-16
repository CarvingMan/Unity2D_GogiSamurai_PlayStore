using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour
{
    public static AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //����
    public static void PlaySound(string AudioURL)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
/*
audioSource.Play(); //���
audioSource.Stop(); //���� 
audioSource.Pause(); //�Ͻ�����
audioSource.UnPause(); //�Ͻ����� ����
audioSource.playOnAwake = true; //�� ���۽� �ٷ� ���
audioSource.loop = true; //�ݺ� ���
audioSource.mute = true; //���Ұ�
audioSource.volume = 1.0f; //���� (0.0 ~ 1.0f)
audioSource.PlayOneShot(audioClip, 1.0f); //Ư�� Ŭ�� �ѹ� �� ���
audioSource.clip = audioClip; //����� Ŭ�� ��ü
*/