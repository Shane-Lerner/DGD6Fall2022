using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public int stage = -1;
    public Vector3 respawn;
    public List<GameObject> levels;
    public List<GameObject> checkpoints;
    public List<GameObject> rings;
    public GameObject finalRing;
    public Material hardmode;

    public bool ngPlus = false;

    public bool setup = false;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.GM = this;
        /*foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        NextStage();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!setup)
        {
            foreach (GameObject level in levels)
            {
                level.SetActive(false);
            }
            NextStage();
            setup = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
            NextStage();
    }

    public void NextStage()
    {
        stage++;
        //Debug.Log("Stage: " + stage + "     Respawn: " + respawn);
        switch (stage)
        {
            case 0:
            {
                respawn = checkpoints[0].transform.position ;
                levels[0].SetActive(true);
                break;
            }
            case 1:
            {
                respawn = checkpoints[1].transform.position ;
                levels[0].SetActive(false);
                levels[1].SetActive(true);
                break;
            }
            case 2:
            {
                respawn = checkpoints[2].transform.position ;
                levels[1].SetActive(false);
                levels[2].SetActive(true);
                break;
            }
            case 3:
            {
                respawn = checkpoints[3].transform.position ;
                levels[2].SetActive(false);
                levels[3].SetActive(true);
                break;
            }
            case 4:
            {
                respawn = checkpoints[4].transform.position ;
                levels[3].SetActive(false);
                levels[4].SetActive(true);
                break;
            }
            case 5:
            {
                respawn = checkpoints[5].transform.position ;
                levels[4].SetActive(false);
                levels[5].SetActive(true);
                break;
            }
            case 6:
            {
                respawn = checkpoints[6].transform.position ;
                levels[5].SetActive(false);
                levels[6].SetActive(true);
                break;
            }
            case 7:
            {
                respawn = checkpoints[0].transform.position ;
                foreach (GameObject level in levels)
                {
                    level.SetActive(true);
                }
                foreach (GameObject ring in rings)
                {
                    ring.SetActive(false);
                }
                if (!ngPlus)
                {
                    BallScript.ball.GetComponent<MeshRenderer>().material = hardmode;
                    BallScript.ball.transform.position = respawn;
                    ngPlus = true;
                }
                break;
            }
            case 8:
            {
                ParticleSystem ps = BallScript.ball.GetComponent<ParticleSystem>();
                ps.Play();
                break;
            }
        }
    }
}
