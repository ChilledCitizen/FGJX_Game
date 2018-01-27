using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public float divisionMultiplier = 1;
    private int n;
    public int gridSize;
    public float grassOffSet;
    public float offSet;
    public GameObject gridTile, grass1, grass2, grass3, grass4, grass5;
    public SceneScript sceneScript;
    public UIController uiController;
    public int resourceAmount;
    public int requiredResourceAmount;
    public float resourceReqPow;
    public int maxResourceGet;
    public int minResourceGet;
    public int rescueTime = 999999;
    public float inGameTimeToRealTime = 10;
    public GameObject resourceObj;
    public List<GameObject> relayTowerList;
    public List<GameObject> gridPieces;
    public float strength;
    private float deltaTime;
    private int startRescTime;
    void Start()
    {

        sceneScript = FindObjectOfType(typeof(SceneScript)) as SceneScript;
        uiController = FindObjectOfType(typeof(UIController)) as UIController;
        startRescTime = rescueTime;

        // if(sceneScript.currentScene.buildIndex == sceneScript.mainLevel)
        // {

        //Generate grid
        if (sceneScript.currentScene.buildIndex == sceneScript.mainLevel)//Doenst work on phone, fix!!!
        {
            for (int y = 0; y < gridSize; y++)
            {
                n++;
                for (int x = 0; x < gridSize; x++)
                {
                    //Debug.Log("AA");
                    Vector3 pos = new Vector3(x * offSet, y * offSet, 1);
                    GameObject newGridTile = Instantiate(gridTile, pos, Quaternion.identity);
                    gridPieces.Add(newGridTile);
                }
            }


            Debug.Log(gridPieces.Count);
            //Generating grass 420
            foreach (GameObject piece in gridPieces)
            {
                GameObject spawnableGrass = grass1;


                for (int i = 0; i < Random.Range(1, 4); i++)
                {
                    switch ((int)Random.Range(1, 6))
                    {
                        case 1:
                            spawnableGrass = grass1;
                            break;
                        case 2:
                            spawnableGrass = grass2;
                            break;
                        case 3:
                            spawnableGrass = grass3;
                            break;
                        case 4:
                            spawnableGrass = grass4;
                            break;
                        case 5:
                            spawnableGrass = grass5;
                            break;

                        default:

                            break;
                    }
                    Debug.Log(piece.transform.position);

                    Instantiate(spawnableGrass, new Vector3(piece.transform.position.x + Random.Range(-5, 5), piece.transform.position.y + Random.Range(-5, 5), 0), Quaternion.identity);
                    if (i >= 2 && n % 5 == 0)
                    {
                        Instantiate(resourceObj, new Vector3(piece.transform.position.x + Random.Range(-5, 5), piece.transform.position.y + Random.Range(-5, 5), 0), Quaternion.identity);

                    }

                }
            }






        }
        if (uiController)
        {
            uiController.UpdateResAmount(resourceAmount);
            uiController.UpdateTimeTilResc(rescueTime);
            uiController.UpdateRequiredResource(requiredResourceAmount);
        }

        //}

    }




    public void OnPlayPress()
    {
        sceneScript.LoadScene(sceneScript.mainLevel);
    }

    public void OnQuitPress()
    {
        Application.Quit();
    }

    public void ResourceAmountUpdate()
    {
        resourceAmount += Random.Range(minResourceGet, maxResourceGet);
        uiController.UpdateResAmount(resourceAmount);
    }

    public void UpdateUIRes(int negAmount)
    {
        resourceAmount -= negAmount;
        uiController.UpdateResAmount(resourceAmount);

    }

    public void CountingOuPut()
    {
        if (relayTowerList.Count > 0)
        {


            foreach (GameObject tower in relayTowerList)
            {
                strength += tower.GetComponent<RelayTower>().outputStength;
            }
            TimeTilRescued(strength);
            uiController.UpdateSignalStrength(strength / (Mathf.Sqrt(rescueTime)));
            uiController.UpdateRequiredResource(requiredResourceAmount);
        }
    }

    public void TimeTilRescued(float signalStr)
    {
        if (rescueTime != 0)
        {
            rescueTime = (int)(rescueTime / (signalStr * divisionMultiplier));




            uiController.UpdateTimeTilResc(rescueTime);
        }

    }

    void Update()
    {
        // if (rescueTime < 1000)
        // {

        deltaTime += Time.deltaTime;
        if (deltaTime > inGameTimeToRealTime)
        {
            rescueTime--;
            uiController.UpdateTimeTilResc(rescueTime);
            deltaTime = 0;
        }


        if (rescueTime < 1 && sceneScript.currentScene.buildIndex == sceneScript.mainLevel)
        {
            sceneScript.LoadScene(sceneScript.winScreen);
        }



    }


}
