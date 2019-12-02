using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using WpfFrameworkElement.Models;

namespace WpfFrameworkElement
{
    public class RenderController : FrameworkElement
    {
        private const int refSleep = 16;
        private readonly Stopwatch stopwatch;
        private readonly ProcessFrameLogic processLogic;

        private readonly IEnumerable<RenderModel> models;
        public RenderController(IEnumerable<RenderModel> models)
        {
            this.models = models;
            this.stopwatch = new Stopwatch();
            this.processLogic = new ProcessFrameLogic(models);

            new Thread(this.FrameController)
            {
                IsBackground = true
            }.Start();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            foreach(var model in models)
            {
                drawingContext.DrawRectangle(model.BackgroundBrush, null, model.Rect);
            }
        }

        private void FrameController()
        {
            long diff = 0;
            int currentSleep = 0;

            while (true)
            {
                diff = this.stopwatch.ElapsedMilliseconds;
                this.Dispatcher.BeginInvoke((Action)(() => this.OneTick())).Wait();
                diff = this.stopwatch.ElapsedMilliseconds - diff;
                currentSleep = (refSleep - diff > 0) ? (int)(refSleep - diff) : 0;
                Thread.Sleep(currentSleep);
            }
        }

        private void OneTick()
        {
            this.processLogic.OneTick(refSleep);
            this.InvalidateVisual();
        }
    }
}
