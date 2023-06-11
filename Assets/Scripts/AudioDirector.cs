using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDirector : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    //����
    public void PlaySound(string AudioURL)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound("Sound/throw1");
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
    }
}
