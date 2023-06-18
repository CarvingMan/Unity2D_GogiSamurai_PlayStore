using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator npcAnimator;
    AudioDirector audioDirector;

    void Start()
    {
        npcAnimator = GetComponent<Animator>();
        audioDirector = GetComponent<AudioDirector>();
    }

    public void Drawing()
    {
        npcAnimator.SetTrigger("drawing");
        
    }
    public void AudioMute(AudioSource audio, bool isOn)
    {
        audio.mute = !isOn; // ��� ���� ���� AudioSource�� ���Ұ� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        /*      audioSource.Play(); //���

                audioSource.Stop(); //����

                audioSource.Pause(); //�Ͻ�����

                audioSource.UnPause(); //�Ͻ����� ����

                audioSource.playOnAwake = true; //�� ���۽� �ٷ� ���

                audioSource.loop = true; //�ݺ� ���

                audioSource.mute = true; //���Ұ�

                audioSource.volume = 1.0f; //���� (0.0 ~ 1.0f)

                audioSource.PlayOneShot(audioClip, 1.0f); //Ư�� Ŭ�� �ѹ� �� ���

                audioSource.clip = audioClip; //����� Ŭ�� ��ü*/

    }
}