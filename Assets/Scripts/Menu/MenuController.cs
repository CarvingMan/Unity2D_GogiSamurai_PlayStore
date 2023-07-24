using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject Panel_menu = null;                // �޴� �г��� ��Ÿ���� ���� ������Ʈ
    public GameObject Toggle1 = null;                   // SFX ����� ��Ÿ���� ���� ������Ʈ
    public GameObject Toggle2 = null;                   // BGM ����� ��Ÿ���� ���� ������Ʈ
    public Image[] OnImage;                             // Ȱ��ȭ �̹��� �迭
    public Image[] OffImage;                            // ��Ȱ��ȭ �̹��� �迭

    private bool[] isMuted = new bool[2]; // SFX�� BGM�� ���Ұ� ���θ� �����ϴ� �迭

    public void Click_Menu()    // �޴� ��ư�� Ŭ������ ���
    {
        Time.timeScale = 0;                             // ���� �ð��� �Ͻ������� ����ϴ�.
        Panel_menu.SetActive(true);                     // �޴� �г��� Ȱ��ȭ�մϴ�.
    }

    public void Click_Continue() // �޴��г��� CONTINUE ��ư Ŭ������ ���
    {
        Time.timeScale = 1;                             // ���� �ð��� �ٽ� �����մϴ�.
        Panel_menu.SetActive(false);                    // �޴� �г��� ��Ȱ��ȭ�մϴ�.
    }

    public void Click_Exit() // �޴��г��� QUIT ��ư Ŭ������ ���
    {
        ChangeScene3();
    }

    public void ChangeScene3()
=======
    public GameObject Panel_menu = null;                // 메뉴 패널을 나타내는 게임 오브젝트
    public GameObject Toggle1 = null;                   // SFX 토글을 나타내는 게임 오브젝트
    public GameObject Toggle2 = null;                   // BGM 토글을 나타내는 게임 오브젝트
    public Image[] OnImage;                             // 활성화 이미지 배열
    public Image[] OffImage;                            // 비활성화 이미지 배열

    private bool isMuted1 = false;                      // SFX 토글의 음소거 여부
    private bool isMuted2 = false;                      // BGM 토글의 음소거 여부

    public void Click_Menu()    // 메뉴 버튼을 클릭했을 경우
    {
        Time.timeScale = 0;                             // 게임 시간을 일시적으로 멈춥니다.
        Panel_menu.SetActive(true);                     // 메뉴 패널을 활성화합니다.
    }

    public void Click_Continue() // 메뉴패널의 CONTINUE 버튼 클릭했을 경우
    {
        Time.timeScale = 1;                             // 게임 시간을 다시 시작합니다.
        Panel_menu.SetActive(false);                    // 메뉴 패널을 비활성화합니다.
    }

    public void Click_Exit() // 메뉴패널의 QUIT 버튼 클릭했을 경우
    {
        Scenechange();                                  // Scenechange 함수를 호출하여 타이틀 씬으로 전환합니다.
    }

    private void Scenechange() // 씬 전환 함수
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    {
        SceneManager.LoadScene("TitleScene");           // "TitleScene"을 로드하여 씬을 전환합니다.
    }

    void Start()
    {
<<<<<<< HEAD
        Panel_menu.SetActive(false);
        isMuted[0] = false; // SFX �ʱ� ���Ұ� ���� ����
        isMuted[1] = false; // BGM �ʱ� ���Ұ� ���� ����
        UpdateMuteImages();
    }

    public void ToggleMute(int index) // SFX�� BGM ����� �����ϴ� �ε����� �޽��ϴ�.
    {
        isMuted[index] = !isMuted[index]; // �ش� ����� ���Ұ� ���¸� ������ŵ�ϴ�.
        UpdateMuteImages();
=======
        Panel_menu.SetActive(false);                    // 메뉴 패널을 처음에는 비활성화합니다.
        UpdateMuteImages();                             // 음소거 이미지를 업데이트합니다.
    }

    public void ToggleMute1() // SFX토글의 음소거 클릭했을경우
    {
        isMuted1 = !isMuted1;                           // SFX 토글의 음소거 이미지를 반전시킵니다.
        UpdateMuteImages();                             // 음소거 이미지를 업데이트합니다.
    }

    public void ToggleMute2() // BGM토글의 음소거 클릭했을경우
    {
        isMuted2 = !isMuted2;                           // BGM 토글의 음소거 이미지를 반전시킵니다.
        UpdateMuteImages();                             // 음소거 이미지를 업데이트합니다.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    private void UpdateMuteImages() // 음소거 이미지 변경 함수
    {
<<<<<<< HEAD
        // SFX�� BGM ����� Ȱ��ȭ/��Ȱ��ȭ �̹����� �����մϴ�.
        for (int i = 0; i < 2; i++)
        {
            OnImage[i].gameObject.SetActive(!isMuted[i]);
            OffImage[i].gameObject.SetActive(isMuted[i]);
        }
=======
        OnImage[0].gameObject.SetActive(!isMuted1);     // SFX 토글의 활성화 이미지를 설정합니다.
        OffImage[0].gameObject.SetActive(isMuted1);     // SFX 토글의 비활성화 이미지를 설정합니다.
        OnImage[1].gameObject.SetActive(!isMuted2);     // BGM 토글의 활성화 이미지를 설정합니다.
        OffImage[1].gameObject.SetActive(isMuted2);     // BGM 토글의 비활성화 이미지를 설정합니다.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }
}