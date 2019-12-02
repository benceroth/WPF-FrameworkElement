using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFrameworkElement.Models;

namespace WpfFrameworkElement.Logics
{
    public abstract class MoveLogic
    {
        public abstract void Move(RenderModel model, long elapsedTime);
    }
}
