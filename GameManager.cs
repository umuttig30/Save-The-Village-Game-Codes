using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject P1;
    public GameObject P2;
    private int p1Life;
    private int p2Life;
    public int P1_maxLife;
    public int P2_maxLife;
    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject[] hearts;
    private bool isP1Died;
    private bool isP2Died;


    void Start()
    {
        p1Life = P1_maxLife;
        p2Life = P2_maxLife;

        isP1Died = isP2Died = false;
    }


    void Update()
    {
        if (isP1Died || isP2Died) return;

        if (p1Life <= 0) PlayerDie();

        if (p2Life <= 0) SpiderDie();
    }

    public void HurtP1()
    {
        p1Life -= 1;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (p1Life > i)
            {
                hearts[i].SetActive(true);

            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
    public void HurtP2()
    {
        p2Life -= 1;
    }
    void SpiderDie()
    {
        P2.GetComponent<Animator>().enabled = false;
        isP2Died = true;
        p1Wins.SetActive(true);
        AudioManager.instance.Play("WinFanfare");
    }
    void PlayerDie()
    {
        P1.GetComponent<Animator>().enabled = false;
        isP1Died = true;
        p2Wins.SetActive(true);
        AudioManager.instance.Play("WinFanfare");
    }
    public void AddHeart()
    {
        p1Life += 1;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (p1Life > i)
            {
                hearts[i].SetActive(true);
            }
        }
    }

}
