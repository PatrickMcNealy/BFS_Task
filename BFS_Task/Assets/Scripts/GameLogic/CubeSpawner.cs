using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : LogicSystem
{
    [SerializeField] GameObject RedCube;
    [SerializeField] GameObject BlueCube;

    [SerializeField] float minimumSpawnTimer;
    [SerializeField] float maximumSpawnTimer;

    [SerializeField] float leftBounds;
    [SerializeField] float rightBounds;
    [SerializeField] float spawnHeight;

    public List<GameObject> activeCubePool = new List<GameObject>();
    List<GameObject> inactiveCubePool = new List<GameObject>();

    override public void Init()
    {
        StartCoroutine(DelaySpawnObject(Random.Range(minimumSpawnTimer, maximumSpawnTimer)));
    }
    override public void FixedTick() { }

    IEnumerator DelaySpawnObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnCube();
        StartCoroutine(DelaySpawnObject(Random.Range(minimumSpawnTimer, maximumSpawnTimer)));
    }

    private void SpawnCube()
    {
        //Decides which cube randomly
        int cubeRand = Random.Range(0, 2);
        bool isRed = true;
        if (cubeRand == 0)
        {
            isRed = false;
        }

        //Picks correct cube.
        GameObject selectedCube;
        if (isRed)
        {
            selectedCube = RedCube;
        }
        else
        {
            selectedCube = BlueCube;
        }

        //generate position
        float posX = Random.Range(leftBounds, rightBounds);

        //create cube, add to cubePool.
        if (activeCubePool.Count < 10)
        {
            activeCubePool.Add(GameManager.Instantiate(selectedCube, new Vector3(posX, spawnHeight), Quaternion.identity));
        }
    }

    
}
