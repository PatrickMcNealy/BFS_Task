using ExampleCompany.BoxGame.GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleCompany.BoxGame.Box
{
    public class CubeSpawner : LogicSystem
    {
        [SerializeField] GameObject RedCube;
        [SerializeField] GameObject BlueCube;

        [SerializeField] float minimumSpawnTimer;
        [SerializeField] float maximumSpawnTimer;

        [SerializeField] float leftBounds;
        [SerializeField] float rightBounds;
        [SerializeField] float spawnHeight;

        public List<Box> activeBoxPool = new List<Box>();
        List<Box> inactiveBoxPool = new List<Box>();

        override public void Init()
        {
            StartCoroutine(DelaySpawnObject(Random.Range(minimumSpawnTimer, maximumSpawnTimer)));
        }
        override public void FixedTick() { }

        IEnumerator DelaySpawnObject(float delay)
        {
            yield return new WaitForSeconds(delay);
            SpawnBox();
            StartCoroutine(DelaySpawnObject(Random.Range(minimumSpawnTimer, maximumSpawnTimer)));
        }


        /// <summary>
        /// Create a box in the world.  This makes use an object pool and only instantiates new objects if there isn't one ready to be reused.
        /// </summary>
        private void SpawnBox()
        {
            if (activeBoxPool.Count >= 10)
            {
                //Limit of 10 boxes on screen.
                return;
            }

            //Decides which cube randomly
            int cubeRand = Random.Range(0, 2);
            Box.BOXCOLOR boxColor;
            if (cubeRand == 0)
            {
                boxColor = Box.BOXCOLOR.RED;
            }
            else
            {
                boxColor = Box.BOXCOLOR.BLUE;
            }


            //If there is a box of the correct color in the existing inactive pool, use that instead of initializing a new object.
            foreach (var item in inactiveBoxPool)
            {
                if (item.color == boxColor)
                {
                    ReInitBox(item);
                    return;
                }
            }

            //If there are no available boxes of the correct color, then initialize a new one here.
            GenerateNewBox(boxColor);
        }

        /// <summary>
        /// Mark box as inactive, ready to be recycled.
        /// </summary>
        public void DespawnBox(Box targetBox)
        {
            targetBox.transform.parent = null;
            targetBox.gameObject.SetActive(false);
            activeBoxPool.Remove(targetBox);
            inactiveBoxPool.Add(targetBox);
        }

        /// <summary>
        /// recycle a box waiting in the object pool to be reused.
        /// </summary>
        private void ReInitBox(Box targetBox)
        {
            float posX = Random.Range(leftBounds, rightBounds);
            targetBox.transform.position = new Vector3(posX, spawnHeight);
            targetBox.ResetBox();
            targetBox.gameObject.SetActive(true);
            inactiveBoxPool.Remove(targetBox);
            activeBoxPool.Add(targetBox);
        }

        /// <summary>
        /// Instantiate a new box.  Only use this if there are no reusable boxes available with the correct parameters.
        /// </summary>
        private void GenerateNewBox(Box.BOXCOLOR boxColor)
        {
            //Picks correct cube.
            GameObject selectedCube;
            if (boxColor == Box.BOXCOLOR.RED)
            {
                selectedCube = RedCube;
            }
            else
            {
                selectedCube = BlueCube;
            }

            //randomize position
            float posX = Random.Range(leftBounds, rightBounds);

            //create cube, add to cubePool.

            activeBoxPool.Add(GameManager.Instantiate(selectedCube, new Vector3(posX, spawnHeight), Quaternion.identity).GetComponent<Box>());

        }
    }
}
