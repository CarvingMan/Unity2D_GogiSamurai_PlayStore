using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
    {
        SceneManager.LoadScene("TitleScene");
    }

    void Start()
    {
        Panel_menu.SetActive(false);
        isMuted[0] = false; // SFX �ʱ� ���Ұ� ���� ����
        isMuted[1] = false; // BGM �ʱ� ���Ұ� ���� ����
        UpdateMuteImages();
    }

    public void ToggleMute(int index) // SFX�� BGM ����� �����ϴ� �ε����� �޽��ϴ�.
    {
        isMuted[index] = !isMuted[index]; // �ش� ����� ���Ұ� ���¸� ������ŵ�ϴ�.
        UpdateMuteImages();
    }

    private void UpdateMuteImages()
    {
        // SFX�� BGM ����� Ȱ��ȭ/��Ȱ��ȭ �̹����� �����մϴ�.
        for (int i = 0; i < 2; i++)
        {
            OnImage[i].gameObject.SetActive(!isMuted[i]);
            OffImage[i].gameObject.SetActive(isMuted[i]);
        }
    }
}