using UnityEngine;

namespace TB_RPG_2D.UI.Core
{
    public abstract class UIEntity : MonoBehaviour
    {
        protected UIEntityManager _uiEntityManager;

        public virtual void Init()
        {
            _uiEntityManager = GetComponentInParent<UIEntityManager>();
        }
        public virtual void Dispose(){}
    }
}