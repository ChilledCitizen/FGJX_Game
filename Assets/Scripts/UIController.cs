using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{


    public Image signalStrengthBack, signalStrengthFront;
    public Text reqResource, timeTilResc, resAmount;
    public Button relayButton;
    public GameObject preMenu;
    public Image end;
    public Sprite spr1, spr2;
    public bool started = false;
    private float t;
    private int n = 0;
    public float timeToRead = 3;
    public Image nightPanel;
    private Color color;
    public Text str1, str2, str3, str4, str5, str6, str7;
    private SceneScript sceneScript;
    private GameControllerScript gameController;
    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType(typeof(GameControllerScript)) as GameControllerScript;
        sceneScript = FindObjectOfType(typeof(SceneScript)) as SceneScript;
        color = nightPanel.color;

    }

    void Update()
    {
        if (started && sceneScript.currentScene.buildIndex == sceneScript.menu)
        {
            t += Time.deltaTime;

            if (t > timeToRead)
            {
                n++;
                switch (n)
                {
                    case 1:
                        preMenu.SetActive(false);
                        EnableText(str1, true);
                        break;

                    case 2:
                        EnableText(str1, false);
                        EnableText(str2, true);
                        break;
                    case 3:
                        EnableText(str2, false);
                        EnableText(str3, true);
                        break;
                    case 4:
                        EnableText(str3, false);
                        EnableText(str4, true);
                        break;
                    case 5:
                        EnableText(str4, false);
                        EnableText(str5, true);
                        break;
                    case 6:
                        EnableText(str5, false);
                        EnableText(str6, true);
                        break;
                    case 7:
                        EnableText(str6, false);
                        EnableText(str7, true);
                        break;
                    default:
                        break;
                }

                if (n > 7)
                {
                    sceneScript.LoadScene(sceneScript.mainLevel);
                }
                t = 0;
            }
        }

        if (sceneScript.currentScene.buildIndex == sceneScript.winScreen)
        {
            t += Time.deltaTime;
            Debug.Log(t);

            if (t >= timeToRead && t < timeToRead * 2)
            {
                end.sprite = spr2;
            }
            if (t >= timeToRead * 2)
            {
                end.sprite = spr1;
                t = 0;
            }

        }
    }




    // Update is called once per frame


    public void UpdateSignalStrength(float strength)
    {
        signalStrengthFront.fillAmount = strength;
    }
    public void UpdateRequiredResource(int req)
    {
        reqResource.text = req + "\nfor new relaytower";
    }
    public void UpdateTimeTilResc(int time)
    {
        timeTilResc.text = "Days until rescue\n" + time;
    }
    public void UpdateResAmount(int amount)
    {
        resAmount.text = "Resources collected:\n" + amount;
    }
    public void MakeButtonInterActable(bool interaction)
    {
        relayButton.interactable = interaction;
    }

    public void EnableText(Text text, bool enable)
    {
        text.gameObject.SetActive(enable);
    }
    // public void UpdateNightPanel(float timeOfDay)
    // {
    // 	float dark = 0;
    // 	float maxDark = 0.75f;

    // 	if(timeOfDay < gameController.inGameTimeToRealTime/2)
    // 	{
    // 		dark = maxDark*(timeOfDay/(gameController.inGameTimeToRealTime));
    // 	}
    // 	else if(timeOfDay > gameController.inGameTimeToRealTime/2)
    // 	{
    // 		dark = maxDark*(-timeOfDay/(gameController.inGameTimeToRealTime));
    // 	}

    // 	color.a = dark;
    // 	nightPanel.color = color;
    // }
}
