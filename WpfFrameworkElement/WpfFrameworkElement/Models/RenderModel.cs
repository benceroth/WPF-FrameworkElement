using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfFrameworkElement.Logics;

namespace WpfFrameworkElement.Models
{
    public abstract class RenderModel
    {
        public RenderModel()
        {
            this.MoveLogics = new List<MoveLogic>();
        }

        public Rect Rect = default(Rect);
        public Vector Speed = default(Vector);

        public Brush BackgroundBrush;
        public List<MoveLogic> MoveLogics;
    }
}
