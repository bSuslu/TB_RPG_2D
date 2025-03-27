using UnityEngine;

namespace TB_RPG_2D.Extensions
{
    public static class GameObjectExtensions {
        public static T OrNull<T> (this T obj) where T : Object => obj ? obj : null;
    }
}