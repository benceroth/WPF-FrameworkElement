using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFrameworkElement.Models;

namespace WpfFrameworkElement.Logics
{
    public class GravityMoveLogic : MoveLogic
    {
        private const double G = 500;
        public override void Move(RenderModel model, long elapsedTime)
        {
            model.Speed.Y += G * elapsedTime / 1000;
        }
    }
}
