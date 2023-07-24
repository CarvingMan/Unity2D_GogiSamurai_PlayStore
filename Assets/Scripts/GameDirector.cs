using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameDirector : MonoBehaviour
{
    [SerializeField] public int maxHp = 3;              // �÷��̾��� �ִ� HP
    [SerializeField] public Image[] heartImages;        // �÷��̾��� HP�� ��Ÿ���� ��Ʈ �̹��� �迭
    [SerializeField] GameObject[] gIngredient_cnt;      // ��� ���� �ؽ�Ʈ�� ��Ÿ���� ���� ������Ʈ �迭
    [SerializeField] public GameObject Gameover_Panel;  // ���� ���� �г� ������Ʈ

    public Recipe recipe;                   // ������ ��ũ��Ʈ ����
    public Image recipeImage;               // ������ �̹��� ������Ʈ
    public Image[] ingredientImages;        // ��� �̹��� ������Ʈ �迭

    public Sprite[] recipeSprites;          // ������ ��������Ʈ �迭
    public Sprite[] ingredientSprites;      // ��� ��������Ʈ �迭


    static public int hp;   // �÷��̾��� ���� hp(static)


    // Start is called before the first frame update


    void Start()
    {
        Application.targetFrameRate = 60;       //����� ȯ���� ��� �������� 60���� ����
        QualitySettings.vSyncCount = 0;

        hp = maxHp;                             // HP�� �ִ� ��(3)���� ����
        Time.timeScale = 1;                     // �ð� �������� 1�� ���� (�Ϲ� �ӵ�)
                                                // Time.timeScale �޼��带 ����Ͽ� �ð��������� 1�� ����(�ð� �帧�� ���� �ӵ���)
                                                // Time.timeScale = 0(�ð� �帧�� ����)
        UpdateRecipeCnt();                      // UI���� ��� ���� ������Ʈ
        UpdateRecipeUI();                       // UI���� �����ǿ� ��� �̹��� ������Ʈ
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearthp();        // UI���� �÷��̾��� HP�� ��Ÿ���� ��Ʈ �̹��� ������Ʈ
        UpdateRecipeCnt();      // UI���� ��� ���� ������Ʈ
        UpdateRecipeUI();       // UI���� �����ǿ� ��� �̹��� ������Ʈ

        if (hp <= 0)            // hp�� 0�̶��
        {
            Invoke("ActivateGameover", 3f);     // 3�� �� ���� ���� �г��� Ȱ��ȭ
            Invoke("GameOverChange", 5f);       // 5�� �� ���� ���� ������ ��ȯ                                               
                                                // Invoke("Ư���Լ�", "xf") 
        }                                       // Ư�� �Լ��� x�� �Ŀ� �ҷ����� �Ѵ�.
    }

    public void UpdateRecipeCnt()
    {
        for (int i = 0; i < 4; i++)     // 0���� 3������ �ε����� ����Ͽ� �ݺ�
        {   
            try{
                // �ܿ� ������ ������ �����ͼ� UI�� ������Ʈ
                // Recipe.ShowLeftoverRecipe().Values.ToList()[i]�� ����Ͽ� �ܿ� ������ ������ �����´�.
                // gIngredient_cnt[i].GetComponent<Text>().text�� ����Ͽ�
                // gIngredient_cnt �迭���� ���� �ε����� �ش��ϴ� GameObject�� Text ������Ʈ�� �����´�.
                gIngredient_cnt[i].GetComponent<Text>().text = "x" + Recipe.ShowLeftoverRecipe().Values.ToList()[i];
            }
            catch
            {
                // ���� ���ܰ� �߻��Ѵٸ�(������ ���� ���), �ش� �ε����� �ش��ϴ� Text ������Ʈ�� text �Ӽ��� ����д�.
                gIngredient_cnt[i].GetComponent<Text>().text = "";
            }
       }
    }
    public void UpdateRecipeUI()
    {
        for (int i = 0; i < 4; i++)     // 0���� 3������ �ε����� ����Ͽ� �ݺ�
        {
            try
            {
                // ingredientImages[i].enabled = true;�� ����Ͽ� ingredientImages �迭����
                // ���� �ε����� �ش��ϴ� Image ������Ʈ�� Ȱ��ȭ ���¸� true�� ����
                // enabled�� Unity�� ������Ʈ�� ���� ������Ʈ�� Ȱ��ȭ ���θ� ��Ÿ���� �Ӽ�
                ingredientImages[i].enabled = true;

                // recipeSprites �迭���� �����ǽ�ũ��Ʈ�� ������ �ε��� ���� �ش��ϴ� ��������Ʈ�� ����
                recipeImage.sprite = recipeSprites[Recipe.RecipeIndex];

                // ��� �̹��� �迭���� �ܿ� �������� Ű(���)�� ������ �� Ű�� �ش��ϴ� ��� �̹��� ��������Ʈ ����
                ingredientImages[i].sprite = ingredientSprites[Recipe.ShowLeftoverRecipe().Keys.ToList()[i]];
            }
            catch
            {
                //���� ���ܰ� �߻��Ѵٸ� ingredientImages �迭���� ���� �ε����� �ش��ϴ� Image ������Ʈ�� Ȱ��ȭ ���¸� false�� ����
                ingredientImages[i].enabled = false;
            }
        }
    } 

    private void UpdateHearthp()
    {
        for (int i = 0; i < maxHp; i++)             //0���� maxHp(3)������ �ε����� ����Ͽ� �ݺ�
        {
            if (i < hp)                             // hp�� i���� ���� ���
            {
                heartImages[i].enabled = true;      // enabled = true�� ����Ͽ� hp�̹��� �迭�� UI�� ��Ÿ����.
            }
            else
            {
                heartImages[i].enabled = false;     // �װ� �ƴ϶�� hp �̹��� �迭 UI�� ��Ȱ��ȭ ��Ŵ
            }
        }
    }

    public void ActivateGameover()
    {
        Gameover_Panel.SetActive(true);             // SetActive�޼��带 Ȱ���Ͽ� �ش� Gameover�ǳ� ������Ʈ�� true(Ȱ��ȭ) ��Ų��.
    }

    public void GameOverChange()
    {
        SceneDirector.ChangeScene2();               // ���ӿ��� �� �� ������ ChangeScene2�Լ��� �����Ѵ�(finishScene ��ȯ)
    }
} 