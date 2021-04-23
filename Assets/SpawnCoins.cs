using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCoins : MonoBehaviour
{
    public GameObject coin, bigCoin;
    public float respawnTime = 4f;
    private Vector3 screenBounds;
    bool gameStart = false;
    bool hasHappened = false;
    public Button restart;
    public Button restartPause;
    public Text coinCount;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        gameStart = false;
        hasHappened = false;

    }



    GameObject decide()
    {
        int z = (int)Random.Range(0,2.99999f);
        if (z == 0 || z == 1)
            return coin;
        else
            return bigCoin;

    }

    private void spawnObstacle()
    {
        GameObject lol = decide();
        GameObject a = Instantiate(lol) as GameObject;
        a.transform.position = new Vector3(Random.Range(-2,2), Random.Range(-2,2), 200);
    }

    IEnumerator wallWave()
    {
        while (true) //boolean ready to start
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s") || controlmanager.getJumpClicked() == true)
            gameStart = true;
        if (gameStart == true && hasHappened == false)
        {
            StartCoroutine(wallWave());
            hasHappened = true;
        }

    }

    void OnEnable()
    {

        restart.onClick.AddListener(MyFunction);//adds a listener for when you click the button
        restartPause.onClick.AddListener(MyFunction2);

    }

    void MyFunction2()
    {
        StopAllCoroutines();
        gameStart = false;
        hasHappened = false;
        DestroyAllOther();
    }



    void MyFunction()// your listener calls this function
    {
        StopAllCoroutines();
        gameStart = false;
        hasHappened = false;
        DestroyAllOther();
    }

    public void DestroyAllOther()
    {
        GameObject[] others = GameObject.FindGameObjectsWithTag("coin"); //Get array of 
                                                                             //all possible objects with a given tag.
        foreach (GameObject go in others)
        { //Get all of those objects so we can check them..
          //As long as the gameObject we're checking isn't ours..


            Destroy(go);

        }
    }
}
