using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace Gravity
{
    /// <summary>
    /// Interaction logic for GravityWindow.xaml
    /// </summary>
    public partial class GravityWindow : Window
    {
        DispatcherTimer _run = new DispatcherTimer();
        public static float TimeDelta = 0.005f;
        List<Planet> _planets = new List<Planet>();

        public GravityWindow()
        {
            InitializeComponent();
            _run.Interval = TimeSpan.FromSeconds(TimeDelta);
            CreatePlanets();
            _run.Tick += TickHandler;
            _run.Start();
        }

        void CreatePlanets()
        {
            for (int i = 0; i < 20; i++)
            {
                CreatePlanet(new Vector2(.5, 0.5 + ((float)i/20f)), new Vector2(-4, 0), .001f);
            }
            CreatePlanet(new Vector2(.5, .5), Vector2.zero, 1f);
        }

        void CreatePlanet(Vector2 where, Vector2 v0, float mass)
        {
            var planet = new Planet(where, v0, mass, ScreenCanvas);
            _planets.Add(planet);
            ScreenCanvas.Children.Add(planet.Circle);
        }

        private void TickHandler(object sender, EventArgs eventArgs)
        {
            foreach (var selectedPlanet in _planets)
            {
                Vector2 force = Vector2.zero;
                foreach (var planet in _planets)
                {
                    if (planet != selectedPlanet)
                    {
                        force += (planet.Position - selectedPlanet.Position) * (planet.Mass * selectedPlanet.Mass) /
                                 Math.Pow((planet.Position - selectedPlanet.Position).Magnitude, 3);
                    }
                }
                selectedPlanet.Force = force;
                selectedPlanet.Tick(TimeDelta);
            }
        }
    }
}
