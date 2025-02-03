using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum BodyParts {HEAD, TORSO, LEGS};
public class GameManager : MonoBehaviour
{

    public GameObject[] headObj;
    public GameObject[] torsoObj;
    public GameObject[] legsObj;
    public GameObject[] spawnPoints;

    public Sprite[] playerHeads;
    public Sprite[] playerTorsos;
    public Sprite[] playerLegs;

    public SpriteRenderer playerHead;
    public SpriteRenderer playerTorso;
    public SpriteRenderer playerLeg;


    public GameObject Player;
    private Transform spawnPos;
    public Animator doorAnim;
    public bool useJoystick;
    public Image joystic, handle;
    public Image arrowS;

    public Sprite headText, torsoText, legsText, endText;

    public Image textBox;

    //public TextMeshProUGUI text;
    //public BodyParts currentPart;
    public Image headH, torsoH, legsH;
    public Image headG, torsoG, legsG;
    public Image headF, torsoF, legsF;
    public GameObject endScreen;


    public bool head, torso, legs;

    private void Awake()
    {
        spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
        Player.transform.position = spawnPos.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizePart();
        ChangeControl();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeControl()
    {
        if (useJoystick)
        {
            joystic.enabled = true;
            handle.enabled = true;
            arrowS.enabled = false;

        }
        else
        {
            joystic.enabled = false;
            handle.enabled = false;
            arrowS.enabled = true;


        }
    }

    public void RandomizePart()
    {

        if (head && torso && legs)
        {
            //text.text = "Muito bem! \nVá ate o portal";
            textBox.sprite = endText;
            headH.enabled = false;
            torsoH.enabled = false;
            legsH.enabled = false;
            doorAnim.SetTrigger("end");
            return;

        }

        bool isValidPart = false;
        int x=0;
        do
        {
            x = Random.Range(1, 4);
            switch (x)
            {
                case 1:
                    if (!head)
                    {
                        isValidPart = true;
                        foreach(GameObject go in headObj)
                        {
                            go.SetActive(true);
                        }
                        foreach (GameObject go in torsoObj)
                        {
                            go.SetActive(false);
                        }
                        foreach (GameObject go in legsObj)
                        {
                            go.SetActive(false);
                        }
                        //text.text = "Monte seu monstro: \n-Pegue uma CABEÇA";
                        headH.enabled = true;
                        torsoH.enabled = false;
                        legsH.enabled = false;
                        textBox.sprite = headText;
                    }
                    break;
                case 2:
                    if (!torso)
                    {
                        isValidPart = true;
                        foreach (GameObject go in headObj)
                        {
                            go.SetActive(false);
                        }
                        foreach (GameObject go in torsoObj)
                        {
                            go.SetActive(true);
                        }
                        foreach (GameObject go in legsObj)
                        {
                            go.SetActive(false);
                        }
                        //text.text = "Monte seu monstro: \n-Pegue um TORSO";
                        headH.enabled = false;
                        torsoH.enabled = true;
                        legsH.enabled = false;
                        textBox.sprite = torsoText;
                    }

                    break;
                case 3:
                    if (!legs)
                    {
                        isValidPart = true;
                        foreach (GameObject go in headObj)
                        {
                            go.SetActive(false);
                        }
                        foreach (GameObject go in torsoObj)
                        {
                            go.SetActive(false);
                        }
                        foreach (GameObject go in legsObj)
                        {
                            go.SetActive(true);
                        }
                        //text.text = "Monte seu monstro: \n-Pegue uma PERNA";
                        headH.enabled = false;
                        torsoH.enabled = false;
                        legsH.enabled = true;
                        textBox.sprite = legsText;
                    }
                    break;
            }

        } while (!isValidPart);

        
    }

    public void ChangePart(int part)
    {
        switch (part)
        {
            case 0:
                head = !head;
                break;
            case 1:
                torso = !torso;
                break;
            case 2:
                legs = !legs;
                break;
                default:
                break;
        }
        RandomizePart();
    }


    public void EndGame()
    {
        headF.sprite = headG.sprite;
        torsoF.sprite = torsoG.sprite;
        legsF.sprite = legsG.sprite;
        endScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void flipControlSet()
    {
        useJoystick = !useJoystick;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
