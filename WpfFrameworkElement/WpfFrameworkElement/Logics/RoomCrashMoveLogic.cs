using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using WpfFrameworkElement.Models;

namespace WpfFrameworkElement.Logics
{
    public class RoomCrashMoveLogic : MoveLogic
    {
        private const int Factor = 10;
        private readonly double[] roomSize;
        public RoomCrashMoveLogic(ref double[] roomSize)
        {
            this.roomSize = roomSize;
        }

        public override void Move(RenderModel model, long elapsedTime)
        {
            if (0 >= model.Rect.Left)
            {
                model.Speed.X = Math.Abs(model.Speed.X);
                model.Rect.X = 0;
            }
            else if(this.roomSize[0] <= model.Rect.Right)
            {
                model.Speed.X = - Math.Abs(model.Speed.X);
                model.Rect.X = this.roomSize[0] - model.Rect.Width;
            }

            if(0 >= model.Rect.Top)
            {
                model.Speed.Y = Math.Abs(model.Speed.Y);
                model.Rect.Y = 0;
            }
            else if(this.roomSize[1] <= model.Rect.Bottom)
            {
                model.Speed.Y = - Math.Abs(model.Speed.Y);
                model.Rect.Y = this.roomSize[1] - model.Rect.Height;
            }
        }
    }
}
