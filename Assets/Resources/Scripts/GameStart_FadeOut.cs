using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameStart_FadeOut : MonoBehaviour
{
    // ���� ���� �޽����� �����ϱ� ���� Ÿ�̸� 
    [SerializeField] 
    private float GameStartMs_Timer = 0;

    public static bool isMessageWait;

    GameObject GameStartText;

    public TextMeshProUGUI testMs;

    void Start()
    {

        //GameStartText = GetComponent<Text>();
        // ���� ���۽� ī��Ʈ �ʱ�ȭ
        GameStartMs_Timer = 0;

        isMessageWait = true;
       


    }

    // Update is called once per frame
    void Update()
    {




        if (GameStartMs_Timer > 0.9f && GameStartMs_Timer <= 2f)
        {
            testMs.text = "READY";
        }
        else if (GameStartMs_Timer > 2f && GameStartMs_Timer <= 3f)
        {
            testMs.text = "GO!";
        }
        else if(GameStartMs_Timer >3f)
        {
            isMessageWait = false;
        }

        GameStartMs_Timer += Time.deltaTime;

    }


}
