using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfFrameworkElement.Logics;
using WpfFrameworkElement.Models;

namespace WpfFrameworkElement.Factories
{
    public class RenderModelFactory
    {
        private const int SquareSize = 3;
        private static readonly Random RNG = new Random();
        private double[] roomSize;

        public RenderModelFactory(ref double[] roomSize)
        {
            this.roomSize = roomSize;
        }

        public T CreateInstance<T>()
            where T : RenderModel, new()
        {
            T model = new T();
            model.BackgroundBrush = Brushes.Black;
            model.Rect.Size = new Size(SquareSize, SquareSize);

            model.MoveLogics.Add(new GravityMoveLogic());
            model.MoveLogics.Add(new RoomCrashMoveLogic(ref this.roomSize));

            return model;
        }

        public T CreateInstanceRandom<T>()
            where T : RenderModel, new()
        {
            T model = this.CreateInstance<T>();
            model.Rect = new Rect(RNG.Next(0, (int)this.roomSize[0]), RNG.Next(0, (int)this.roomSize[1]), SquareSize, SquareSize);
            model.Speed.X = RNG.Next(0, 500);
            model.Speed.Y = RNG.Next(0, 500);

            return model;
        }
    }
}
