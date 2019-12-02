using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfFrameworkElement.Factories;
using WpfFrameworkElement.Models;

namespace WpfFrameworkElement.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private const int BallCount = 5000;
        private double[] roomSize = new double[2];

        public MainViewModel()
        {
            this.Models = new HashSet<RenderModel>();
            this.RenderController = new RenderController(this.Models);
            this.GenerateCommand = new RelayCommand(() =>
            {
                var factory = new RenderModelFactory(ref this.roomSize);
                for(int i = 0; i < BallCount; i++)
                {
                    this.Models.Add(factory.CreateInstanceRandom<BallModel>());
                }
            });
        }

        public ICommand GenerateCommand { get; private set; }

        public HashSet<RenderModel> Models { get; set; }

        public RenderController RenderController { get; private set; }

        public double Width
        {
            get => this.roomSize[0];
            set => this.roomSize[0] = value;
        }

        public double Height
        {
            get => this.roomSize[1];
            set => this.roomSize[1] = value;
        }
    }
}
