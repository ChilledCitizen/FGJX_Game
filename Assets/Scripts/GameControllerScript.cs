using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

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
    public float rescueTime;
    public float inGameTime;
    public List<GameObject> relayTowerList;
    public List<GameObject> gridPieces;
    private float strength;
    void Start()
    {

        sceneScript = FindObjectOfType(typeof(SceneScript)) as SceneScript;
        uiController = FindObjectOfType(typeof(UIController)) as UIController;


        // if(sceneScript.currentScene.buildIndex == sceneScript.mainLevel)
        // {

        //Generate grid
        for (int y = 0; y < gridSize; y++)
        {

            for (int x = 0; x < gridSize; x++)
            {
                //Debug.Log("AA");
                Vector3 pos = new Vector3(x * offSet, y * offSet, 1);
                Instantiate(gridTile, pos, Quaternion.identity);
                gridPieces.Add(gridTile);
            }
        }

        //Generating grass 420
        foreach (GameObject piece in gridPieces)
        {
            GameObject spawnableGrass;
            switch ((int)Random.Range(1, 5))
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
        }

        uiController.UpdateRequiredResource(requiredResourceAmount);
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
        Debug.Log("ResourceAmount: " + resourceAmount);
    }

    public void CountingOuPut()
    {
        if (relayTowerList.Count > 0)
        {


            foreach (GameObject tower in relayTowerList)
            {
                strength += tower.GetComponent<RelayTower>().outputStength / 100;
            }
            uiController.UpdateSignalStrength(strength);
            uiController.UpdateRequiredResource(requiredResourceAmount);
        }
    }
}
