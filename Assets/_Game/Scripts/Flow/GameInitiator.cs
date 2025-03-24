using System.Collections.Generic;
using UnityEngine;

namespace TB_RPG_2D.Flow
{
    public class GameInitiator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _gameObjectsToInstantiate;
        
        private void Start()
        {
            foreach (var go in _gameObjectsToInstantiate)
            {
                Instantiate(go);
            }
        }
    }
}
