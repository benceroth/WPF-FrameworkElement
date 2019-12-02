using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFrameworkElement.Models;

namespace WpfFrameworkElement
{
    public class ProcessFrameLogic
    {
        private readonly IEnumerable<RenderModel> models;
        public ProcessFrameLogic(IEnumerable<RenderModel> models)
        {
            this.models = models ?? throw new ArgumentNullException(nameof(models));
        }

        public void OneTick(int elapsedTime)
        {
            this.MoveTick(elapsedTime);
        }

        private void MoveTick(int elapsedTime)
        {
            Parallel.ForEach(models, model =>
            {
                foreach (var logic in model.MoveLogics)
                {
                    logic.Move(model, elapsedTime);
                }

                model.Rect.Location += model.Speed * elapsedTime / 1000;
            });
        }
    }
}
