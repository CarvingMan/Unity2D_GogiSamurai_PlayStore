using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField] public int maxHp = 5;
    [SerializeField] public Image[] heartImages;
    [SerializeField] public GameObject Gameover_Panel;
    [SerializeField] GameObject[] gIngredient_cnt;

    public Recipe recipe;
    public Image recipeImage;
    public Image[] ingredientImages;
    public Sprite[] recipeSprites;
    public Sprite[] ingredientSprites;


    static public int hp;
    public int[] indexArray = new int[Recipe.randomRecipe.Length];
    public int[] valueArray = new int[Recipe.randomRecipe.Length];
    // Start is called before the first frame update

    void Start()
    {
        hp = maxHp;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearthp();

        if (hp <= 0)
        {
            Invoke("ActivateGameover", 3f);
        }

        gIngredient_cnt[0].GetComponent<Text>().text = "X" + Recipe.randomRecipe[indexArray[0]].ToString("D1");
        gIngredient_cnt[1].GetComponent<Text>().text = "X" + Recipe.randomRecipe[indexArray[1]].ToString("D1");
        gIngredient_cnt[2].GetComponent<Text>().text = "X" + Recipe.randomRecipe[indexArray[2]].ToString("D1");
        gIngredient_cnt[3].GetComponent<Text>().text = "X" + Recipe.randomRecipe[indexArray[3]].ToString("D1");
    }

    public void UpdateUI(int[] indexArray)
    {
        // recipe img update
        int j = 0;
        int recipeIndex = Recipe.RecipeIndex;
        recipeImage.sprite = recipeSprites[recipeIndex];


        // ingredient img update
        for (int i = 0; i < indexArray.Length; i++)
        {
            if (Recipe.randomRecipe[i] > 0)
            {
                int index = indexArray[j];
                ingredientImages[j].sprite = ingredientSprites[index];
                j++;
                //ingredientImages[i].gameObject.SetActive(Recipe.randomRecipe[i] > 0);
            }
        }
    }

    public int[] GetIngredientIndex()
    {
        int j = 0;
        int previousIndex = 0;

        for (int i = 0; i < Recipe.randomRecipe.Length; i++)
        {
            if (Recipe.randomRecipe[i] > 0)
            {
                indexArray[j] = previousIndex;
                valueArray[j] = Recipe.randomRecipe[i];
                j++;
            }
            previousIndex++;
        }
        return indexArray;
    }





    private void UpdateHearthp()
    {
        for (int i = 0; i < maxHp; i++)
        {
            if (i < hp)
            {
                heartImages[i].enabled = true;
            }
            else
            {
                heartImages[i].enabled = false;
            }
        }
    }


    public void ActivateGameover()
    {
        Gameover_Panel.SetActive(true);
    }

    public void changeScene1()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void changeScene2()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void changeScene3()
    {
        SceneManager.LoadScene("TitleScene");
    }
}