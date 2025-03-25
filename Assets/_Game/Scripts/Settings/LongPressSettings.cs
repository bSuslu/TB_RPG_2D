using UnityEngine;

namespace TB_RPG_2D.Settings
{
    [CreateAssetMenu(fileName = "LongPressSettings", menuName = "Settings/LongPress")]
    public class LongPressSettings :ScriptableObject
    {
        [field: SerializeField] public float LongPressDuration { get; private set; }
    }
}