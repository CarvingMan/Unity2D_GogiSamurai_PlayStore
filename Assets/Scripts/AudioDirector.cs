using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDirector : MonoBehaviour
{
    public GameObject gPlayer;
    public GameObject gNPC;

    public AudioSource aPlayerSound;
    public AudioSource aNPCSound;
    //public AudioSource audioSource;

    private static bool isMuted = false;


    /*    public Slider volumeSlider;
        public Toggle audioToggle;*/

    // Start is called before the first frame update
    void Start()
    {
        gPlayer = GameObject.Find("Player");
        gNPC = GameObject.Find("NPC");

        aPlayerSound = gPlayer.GetComponent<AudioSource>();
        aNPCSound = gNPC.GetComponent<AudioSource>();
        //audioSource = GetComponent<AudioSource>();

        /*volumeSlider.onValueChanged.AddListener(OnVolumeChanged);*/
    }

    public void SoundPlay(string AudioURL)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        aPlayerSound.clip = audioClip;
        aPlayerSound.Play();
    }

    public void SoundNPC(string AudioURL)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        aNPCSound.clip = audioClip;
        aNPCSound.Play();
    }
    public void EffectSoundMute() // ���⼭ �ΰ��� ������Ʈ�� ������ ����µ� �ذ�å�� ������?
    {
        isMuted = !isMuted;
        aPlayerSound.mute = isMuted;
        aNPCSound.mute = isMuted;
    }

    /*public void OnVolumeChanged(float value)
    {
        audioSource.volume = value; // �����̴� ���� ���� AudioSource�� volume ����
    }*/


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
