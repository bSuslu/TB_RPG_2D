using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TB_RPG_2D.UI.Core
{
    public class UIEntityManager : MonoBehaviour
    {
        [field: SerializeField] public Camera Camera { get; private set; }
        [field: SerializeField] public Canvas Canvas { get; private set; }

        private List<UIEntity> _uiEntities;
        private void Awake()
        {
            _uiEntities = GetComponentsInChildren<UIEntity>(true).ToList();
            
            foreach (var uiEntity in _uiEntities)
            {
                uiEntity.Init();
            }
        }

        private void OnDestroy()
        {
            foreach (var uiEntity in _uiEntities)
            {
                uiEntity.Dispose();
            }
        }
    }
}