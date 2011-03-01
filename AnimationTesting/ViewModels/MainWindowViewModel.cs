namespace AnimationTesting.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    using AnimationTesting.Animation;

    public class MainWindowViewModel : INotifyPropertyChanged, IAnimatablePosition, IAnimatableAngle
    {
        private double x;
        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (this.x == value)
                {
                    return;
                }

                this.x = value;

                this.OnPropertyChanged("X");
            }
        }

        private double y;
        public double Y
        {
            get
            {
                return this.y;
            }

            set
            {
                if (this.y == value)
                {
                    return;
                }

                this.y = value;

                this.OnPropertyChanged("Y");
            }
        }

        private double angle;
        public double Angle
        {
            get
            {
                return this.angle;
            }

            set
            {
                if (this.angle == value)
                {
                    return;
                }

                this.angle = value;

                this.OnPropertyChanged("Angle");
            }
        }


        public ICommand UpdateValuesCommand { get; private set; }

        public MainWindowViewModel()
        {
            this.X = this.Y = 200;

            this.XAdapter = new AnimatablePropertyAdapter<double>(Canvas.LeftProperty);
            this.YAdapter = new AnimatablePropertyAdapter<double>(Canvas.TopProperty);
            this.AngleAdapter = new AnimatablePropertyAdapter<double>(RotateTransform.AngleProperty);

            this.UpdateValuesCommand = new BasicCommand(this.UpdateValues);
        }

        private void UpdateValues(object parameter)
        {
            if (this.XAdapter.IsBound)
            {
                this.X = this.XAdapter.GetValue();
            }

            if (this.YAdapter.IsBound)
            {
                this.Y = this.YAdapter.GetValue();
            }

            if (this.AngleAdapter.IsBound)
            {
                this.Angle = this.AngleAdapter.GetValue();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }

            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AnimatablePropertyAdapter<double> XAdapter { get; private set; }

        public AnimatablePropertyAdapter<double> YAdapter { get; private set; }

        public AnimatablePropertyAdapter<double> AngleAdapter { get; private set; }
    }
}
