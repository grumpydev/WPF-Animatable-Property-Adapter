namespace AnimationTesting.Animation
{
    using System.Windows;
    using System.Windows.Interactivity;
    using System.Windows.Media;

    /// <summary>
    /// A behaviour for wiring up property adapters to a view model
    /// that implements IAnimatableAngle
    /// </summary>
    public class AnimatableAngleBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// Optional source object for attaching to the adapter in place of the AssocitatedObject
        /// </summary>
        public static readonly DependencyProperty SourceObjectProperty = DependencyProperty.Register("SourceObject", typeof(DependencyObject), typeof(AnimatableAngleBehavior), new UIPropertyMetadata(null));

        /// <summary>
        /// Optional source object for attaching to the adapter in place of the AssocitatedObject
        /// </summary>
        public DependencyObject SourceObject
        {
            get
            {
                return (DependencyObject)GetValue(SourceObjectProperty);
            }

            set
            {
                SetValue(SourceObjectProperty, value);
            }
        }
        
        protected override void OnAttached()
        {
            base.OnAttached();

            var animatableAngleViewModel = this.AssociatedObject.DataContext as IAnimatableAngle;
            if (animatableAngleViewModel == null)
            {
                return;
            }

            animatableAngleViewModel.AngleAdapter.BoundObject = this.SourceObject ?? this.AssociatedObject;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            var animatableAngleViewModel = this.AssociatedObject.DataContext as IAnimatableAngle;
            if (animatableAngleViewModel == null)
            {
                return;
            }

            animatableAngleViewModel.AngleAdapter.BoundObject = null;
        }
    }
}
