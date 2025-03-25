using System;

namespace TB_RPG_2D.UI.Controller
{
    public interface ILongPressDetector
    {
        public Action OnLongPressed { get; set; }
        public Action OnLongPressReleased { get; set; }
    }
}