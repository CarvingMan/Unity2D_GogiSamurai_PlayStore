using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneDirector : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    public Text ScoreText;  // 점수를 표시하는 텍스트 UI

    public void ChangeScene1()
    {
        Recipe.Score = 0;                       // Recipe 스크립트의 점수를 초기화합니다.
        SceneManager.LoadScene("GameScene");    // "GameScene"으로 씬을 전환합니다.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public static void ChangeScene2()
    {
<<<<<<< HEAD
        SceneManager.LoadScene("FinishScene");          // "FinishScene"���� ���� ��ȯ�մϴ�.
=======
        SceneManager.LoadScene("FinishScene");  // "FinishScene"으로 씬을 전환합니다.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    public void ChangeScene3()
    {
<<<<<<< HEAD
        Recipe.Score = 0;                                            // Recipe ��ũ��Ʈ�� ������ �ʱ�ȭ�մϴ�.
        StartCoroutine(FadeOutAndLoadScene("TitleScene"));           // ���̵� ȿ���� �Բ� "TitleScene"���� ���� ��ȯ�մϴ�.
=======
        Recipe.Score = 0;                       // Recipe 스크립트의 점수를 초기화합니다.
        SceneManager.LoadScene("TitleScene");   // "TitleScene"으로 씬을 전환합니다.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    void Start()
    {
<<<<<<< HEAD
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // ������ �� ���� �ؽ�Ʈ�� ������Ʈ�մϴ�.
        StartCoroutine(FadeIn());
=======
        ScoreText.text = "SCORE: " + Recipe.Score.ToString();  // 시작할 때 점수 텍스트를 업데이트합니다.
>>>>>>> 2614fe62da4a1ecd041231f023e85214d0fc979d
    }

    void Update()
    {
    }
}