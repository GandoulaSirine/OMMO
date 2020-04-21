using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public int whosTurn = 0;
    public static bool coroutineAllowed = true;
    public static GameObject dice;

    // Use this for initialization
    private void Start()
    {
        dice = this.gameObject;
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
        print(coroutineAllowed);
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown =  randomDiceSide + 1;
        
            whosTurn=GameControl.MovePlayer(whosTurn);
        
        //gameObject.SetActive(false);
       
        //coroutineAllowed = true;
    }
}
