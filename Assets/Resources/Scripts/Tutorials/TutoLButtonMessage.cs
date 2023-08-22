using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutoLButtonMessage : MonoBehaviour
{

    GameObject fish;
    public TextMeshProUGUI tt = null;
    private enum TutorialState2 { ment1, ment2, ment3, ment4, ment5}
    private TutorialState2 currentState;
    [SerializeField] GameObject LButton;

    void Start()
    {
        fish = GameObject.Find("fish");
        GameDirector.isTouch = false;
        currentState = TutorialState2.ment1;
    }


    void Update()
    {
        Destroy(fish);
        switch (currentState)
        {
            case TutorialState2.ment1:
                LButton.gameObject.SetActive(true);
                tt.text = "��� ��ư�Դϴ�!";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment2; 
                }
                break;
            case TutorialState2.ment2:
                tt.text = "��ư�� ������ �����Ÿ� ���� �ִ� ��Ḧ ƨ�ܳ� �� �ֽ��ϴ�.";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0)) 
                {
                    currentState = TutorialState2.ment3; 
                }
                break;
            case TutorialState2.ment3:
                tt.text = "�����ǿ� ���� �ʴ� ���� ������ ƨ�ܳ���� �մϴ�!";
                //tt.text = "text2";
                if (Input.GetMouseButtonDown(0))
                {
                    currentState = TutorialState2.ment4;
                }
                break;
            case TutorialState2.ment4:
                tt.text = "���� ������ ������ ƨ�� �� �� ������, �����ǰ� �ϼ��� �Ǿ�� ������ �ö󰡹Ƿ� ������ �ּ���!";
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
