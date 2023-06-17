using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBGM : MonoBehaviour
{
    int nRandom;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���� adioSource�� Play ���� �ƴ϶��
        if (GetComponent<AudioDirector>().audioSource.isPlaying == false)
        {
            RandomPlay(); //�ٽ� �������� ���� ���� �����Ų��.


        }

        // �������� 1~7�� ������ ��ȯ�Ͽ� 7���� BGM�� �������� �����Ű�� �Լ�
        void RandomPlay()
        {
            nRandom = Random.Range(1, 8); // 1~7������ ���� �߻�
                                          //switch case������ �������� bgm�� �����Ų��.
            switch (nRandom)
            {
                case 1:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_1"); 
                    break;
                case 2:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_2");
                    break;
                case 3:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_3");
                    break;
                case 4:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_4");
                    break;
                case 5:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_5");
                    break;
                case 6:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_6");
                    break;
                case 7:
                    GetComponent<AudioDirector>().SoundPlay("Sound/BGM/Track_7");
                    break;
            }
        }
    }
}