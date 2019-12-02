// <copyright file="RenderLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WpfFrameworkElement
{
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

    /// <summary>
    /// Implements and controls UI rendering.
    /// </summary>
    public class RenderLogic : FrameworkElement
    {
        private const int RefSleep = 16;
        private readonly FrameLogic frameLogic;

        private readonly IEnumerable<RenderModel> models;

        private readonly Stopwatch stopwatch = new Stopwatch();

        private readonly HashSet<Rect> rects = new HashSet<Rect>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderLogic"/> class.
        /// </summary>
        /// <param name="models">Reference for all renderable models.</param>
        internal RenderLogic(IEnumerable<RenderModel> models)
        {
            this.models = models;
            this.frameLogic = new FrameLogic(models);

            new Thread(this.FrameController)
            {
                IsBackground = true,
            }.Start();
        }

        /// <inheritdoc />
        protected override void OnRender(DrawingContext drawingContext)
        {
            foreach (var model in this.models)
            {
                drawingContext.DrawRectangle(Brushes.Black, null, new Rect(model.X, model.Y, model.Width, model.Height));
            }
        }

        private void FrameController()
        {
            long diff = 0;
            long elapsed = 0;
            int currentSleep = 0;

            while (true)
            {
                diff = this.stopwatch.ElapsedMilliseconds;
                elapsed = currentSleep > 0 ? RefSleep : diff;

                this.Dispatcher.BeginInvoke((Action)(() => this.OneTick((int)elapsed))).Wait();

                diff = this.stopwatch.ElapsedMilliseconds - diff;
                currentSleep = (RefSleep - diff > 0) ? (int)(RefSleep - diff) : 0;
                Thread.Sleep(currentSleep);
            }
        }

        private void OneTick(int elapsed)
        {
            GC.TryStartNoGCRegion(1024 * 1024 * 15);
            this.frameLogic.Process(elapsed);
            this.InvalidateVisual();
            GC.EndNoGCRegion();
        }
    }
}
