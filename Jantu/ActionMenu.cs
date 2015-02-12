using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class ActionMenu : Window
    {
        private int _Width;
        private int _Height;
        private Vector2 _Pos;

        public ActionMenu(Vector2 pos, int width, int height) :
                base(pos, width, height)
        {
            _Width = width;
            _Height = height;
            _Pos = pos;
        }

        protected override void OnDraw()
        {
            return;
        }
    }
}
