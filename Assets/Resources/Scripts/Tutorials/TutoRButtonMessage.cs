using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoRButtonMessage : MonoBehaviour
{

    public TextMeshProUGUI tt = null;
    private enum TutorialState2 { ment1, ment2, ment3, ment4, ment5}
    private TutorialState2 currentState;
    [SerializeField] GameObject RButton;

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
                //RButton.SetActive(true);
                RButton.gameObject.SetActive(true);
                tt.text = "�̰��� ���� ��ư�Դϴ�!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment2; 
                }
                break;
            case TutorialState2.ment2:
                tt.text = "��ư�� ������ �����Ÿ� ���� �ִ� ��Ḧ �� �� �ֽ��ϴ�.";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0)) 
                {
                    currentState = TutorialState2.ment3; 
                }
                break;
            case TutorialState2.ment3:
                tt.text = "�߰� �丰 ������ ���� �� ���ִ� ������ �˴ϴ�!";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment4;
                }
                break;
            case TutorialState2.ment4:
                tt.text = "��! �����ǿ� ���� �ʰ� ��Ḧ ��� ������ ��� ���� �����Դϴ�!";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment5;
                }
                break;
            case TutorialState2.ment5:
                tt.text = "��ư�� ���� ������!";
                GameDirector.isTouch = true;
               
                Invoke("TouchControll", 0.5f);
                Invoke("delay", 3f);
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

    void delay()
    {
        TutoRButton.availableMove2 = true;
    }

}
