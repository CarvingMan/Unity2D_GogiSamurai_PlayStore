using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    Effect effect;
    private bool hasAttacked = false;
    private float lastAttackTime = -1f;
    private float doubleAttackTimeWindow = 0.2f;

    public Vector2 boxSize;
    public Transform pos;
    public Animator animator;

    bool isPunched = false;
    public bool isDelay = false; //attack delay
    public Collider2D attackCollider;
    public static int AtackCount = 0;

    GameObject gEffect;
    ItemController item;
    Animator playerAnimator;
    GameObject recipeCollision;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = GetComponent<Animator>();
        recipeCollision = GameObject.Find("RecipeCollision");

        gEffect = GameObject.Find("Effect");
        

        attackCollider.enabled = false;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunched)
        {
            //gGenerator.GetComponent<Generator>().Destroyfruits();
            //recipeCollision.GetComponent<Recipe>().OnRecipeCollision();
            Attack();
        }

        else if (Input.GetKeyDown(KeyCode.LeftControl) && !hasAttacked)
        {
            //isPunched = true;
            //playerAnimator.SetTrigger("punch");

            //var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
            //foreach (Collider2D collider in colliders)
            //{
            //    if (collider.tag == "Target")
            //    {
            //        //gEffect.PunchBack(collider);

            //        gEffect.GetComponent<Effect>().PunchBack(collider);


            //    }
            //}
            //StartCoroutine(CountAttackDelay(0.4f));
            Pch();

        }else if (Input.GetKeyDown(KeyCode.A)){
            //
        }

        if (GameDirector.hp <= 0)
        {
            playerAnimator.SetTrigger("game_over");
            //Change to Gameover Scene
        }

    }

    public void Pch()
    {
        isPunched = true;
        playerAnimator.SetTrigger("punch");

        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Target")
            {
                Debug.Log("���� : " + collider.gameObject);
                //gEffect.PunchBack(collider);
                //gEffect.GetComponent<Effect>().PunchBack(collider.gameObject);
                //Effect.PunchBack(collider);

                Effect.Apply(collider.gameObject);

            }
        }
        StartCoroutine(CountAttackDelay(0.4f));
    }

    public void Attack()
    {

        float currentTime = Time.time;
        var colliders = Physics2D.OverlapBoxAll(pos.position, boxSize, 0).ToList();


        if (!isDelay)
        {

            playerAnimator.SetTrigger("attack");
            foreach (Collider2D collider in colliders)
            {

                if (collider.tag == "Target")
                {
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    //Debug.Log("Hp : " + collider.gameObject.GetComponent<ItemController>().itemHp);
                }
            }
            isDelay = true;
            lastAttackTime = currentTime;
            StartCoroutine(CountAttackDelay(0.4f));

        }
        else if ((currentTime - lastAttackTime) <= doubleAttackTimeWindow)
        {
            playerAnimator.SetTrigger("double_attack");
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Target")
                {
                    collider.gameObject.GetComponent<ItemController>().itemHp--;
                    //Debug.Log("Hp : " + collider.gameObject.GetComponent<ItemController>().itemHp);
                }
            }
            isDelay = true;
            StartCoroutine(CountAttackDelay(0.2f));
        }



    }

    IEnumerator CountAttackDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
        isPunched = false;
        hasAttacked = false;

    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Target")
        {

            Destroy(collider.gameObject);
            GameDirector.hp--;
            playerAnimator.SetTrigger("damaged");

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

}