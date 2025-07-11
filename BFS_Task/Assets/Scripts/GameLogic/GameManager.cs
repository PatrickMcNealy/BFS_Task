using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleCompany.BoxGame.GameLogic
{
    /// <summary>
    /// This class manages major game systems that must be kept track of and tick on regular intervals (every frame or less, depending.)
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] List<LogicSystem> logicSystems;

        private void Start()
        {
            foreach (var item in logicSystems)
            {
                item.Init();
            }
        }

        private void FixedUpdate()
        {
            foreach (var item in logicSystems)
            {
                item.FixedTick();
            }
        }
    }
}