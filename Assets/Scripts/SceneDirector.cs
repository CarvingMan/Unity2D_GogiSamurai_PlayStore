using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
    public Image FadePanel;                 // �ǳ� ������Ʈ
    public Text ScoreText;                  // ������ ǥ���ϴ� �ؽ�Ʈ UI
    public float time = 0f;    
    public float F_time = 1.5f;


    IEnumerator FadeIn()
    {
        time = 0f;
        Color alpha = FadePanel.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            FadePanel.color = alpha;
            yield return null;
        }
    }

    // ���̵�ƿ� ȿ���� �Բ� �ٸ� ������ ��ȯ�ϴ� �Լ�
    public IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        time = 0f;
        Color alpha = FadePanel.color;
        while (alpha.a < 1f)
        {   
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            FadePanel.color = alpha;
            yield return null;
        }

        // �� ��ȯ
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene1()
    {
        Recipe.Score = 0;                                               // Recipe ��ũ��Ʈ�� ������ �ʱ�ȭ�մϴ�.
        StartCoroutine(FadeOutAndLoadScene("GameScene"));               // ���̵� ȿ���� �Բ� "GameScene"���� ���� ��ȯ�մϴ�.
    }

    public static void ChangeScene2()
    {
        SceneManager.LoadScene("FinishScene");          // "FinishScene"���� ���� ��ȯ�մϴ�.
    }

    public void ChangeScene3()
    {
        Recipe.Score = 0;                                            // Recipe ��ũ��Ʈ�� ������ �ʱ�ȭ�մϴ�.
        StartCoroutine(FadeOutAndLoadScene("TitleScene"));           // ���̵� ȿ���� �Բ� "TitleScene"���� ���� ��ȯ�մϴ�.
    }


    void Start()
    {
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // ������ �� ���� �ؽ�Ʈ�� ������Ʈ�մϴ�.
        StartCoroutine(FadeIn());
    }

    void Update()
    {
    }
}