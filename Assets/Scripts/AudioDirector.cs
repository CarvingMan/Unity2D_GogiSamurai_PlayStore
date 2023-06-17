using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDirector : MonoBehaviour
{
    AudioSource audioSource;
    public Slider volumeSlider;
    public Toggle audioToggle;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }
    //����
    public void PlaySound(string AudioURL)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(AudioURL);
        audioSource.clip = audioClip;
        audioSource.Play();
        audioToggle.onValueChanged.AddListener(OnToggleChanged); // ��� ���� ����� ������ OnToggleChanged ȣ��
    }
    public void OnVolumeChanged(float value)
    {
        audioSource.volume = value; // �����̴� ���� ���� AudioSource�� volume ����
    }

    public void OnToggleChanged(bool isOn)
    {
        audioSource.mute = !isOn; // ��� ���� ���� AudioSource�� ���Ұ� ���� ����
    }

    // Update is called once per frame
    void Update()
    {


/*        audioSource.Play(); //���

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
