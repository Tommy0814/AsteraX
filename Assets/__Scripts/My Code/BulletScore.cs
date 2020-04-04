using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScore : MonoBehaviour
{

    public ScoreSystem ScoreSystem;

    private int BIG_ASTEROID_SCORE = 100;
    private int MEDIUM_ASTEROID_SCORE = 200;
    private int SMALL_ASTEROID_SCORE = 400;


    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem = GameObject.Find("Score System").GetComponent<ScoreSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.localScale.x > 2.2 && collision.gameObject.transform.localScale.x < 2.3)
        {
            ScoreSystem.Score(BIG_ASTEROID_SCORE);
        }
        else if (collision.gameObject.transform.localScale.x > 1.45 && collision.gameObject.transform.localScale.x < 1.55)
        {
            ScoreSystem.Score(MEDIUM_ASTEROID_SCORE);
        }
        if (collision.gameObject.transform.localScale.x > 0.7 && collision.gameObject.transform.localScale.x < 0.8)
        {
            ScoreSystem.Score(SMALL_ASTEROID_SCORE);
        }
    }

}
