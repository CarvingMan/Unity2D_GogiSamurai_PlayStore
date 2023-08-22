using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoATkRangeMessage : MonoBehaviour
{
    public TextMeshProUGUI tt = null;
    private enum TutorialState2 { ment1, ment2, ment3}
    private TutorialState2 currentState;

    void Start()
    {
        GameDirector.isTouch = false;
        currentState = TutorialState2.ment1;
    }


    void Update()
    {
        switch (currentState)
        {
            case TutorialState2.ment1:
                tt.text = "Ÿ�� ���� �Դϴ�.";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment2; 
                }
                break;
            case TutorialState2.ment2:
                tt.text = "�ش� �������� ��ᰡ ���ý� ���ų� ƨ�ܳ���� �մϴ�.";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0)) 
                {
                    currentState = TutorialState2.ment3; 
                }
                break;
            case TutorialState2.ment3:
                //tt.text = "Ÿ�̹��� ��߳� �� ��ῡ ���� �� ������ ���� �� �ּ���!";
                tt.text = "Ÿ�̹��� ��߳� �� ��ῡ ���� �� ������ ���� �� �ּ���!";
                GameDirector.isTouch = true;
                
                Invoke("TouchControll", 0.5f);
                break;
                         
            //default:
            //    tt.text = "Error";
            //    break;
        }
    }

    void TouchControll()
    {
        GameDirector.isTouch = false;
    }

}
