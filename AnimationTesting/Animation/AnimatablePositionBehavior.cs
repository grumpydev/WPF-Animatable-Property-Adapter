namespace AnimationTesting.Animation
{
    using System.Windows;
    using System.Windows.Interactivity;

    /// <summary>
    /// A behaviour for wiring up property adapters to a view model
    /// that implements IAnimatablePosition
    /// </summary>
    public class AnimatablePositionBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// Optional source object for attaching to the adapter in place of the AssocitatedObject
        /// </summary>
        public static readonly DependencyProperty SourceObjectProperty = DependencyProperty.Register("SourceObject", typeof(DependencyObject), typeof(AnimatablePositionBehavior), new UIPropertyMetadata(null));

        /// <summary>
        /// Optional source object for attaching to the adapter in place of the AssocitatedObject
        /// </summary>
        public DependencyObject SourceObject
        {
            // IMPORTANT: To maintain parity between setting a property in XAML and procedural code, do not touch the getter and setter inside this dependency property!
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

            var animatablePositionViewModel = this.AssociatedObject.DataContext as IAnimatablePosition;
            if (animatablePositionViewModel == null)
            {
                return;
            }

            animatablePositionViewModel.XAdapter.BoundObject = this.SourceObject ?? this.AssociatedObject;
            animatablePositionViewModel.YAdapter.BoundObject = this.SourceObject ?? this.AssociatedObject;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            var animatablePositionViewModel = this.AssociatedObject.DataContext as IAnimatablePosition;
            if (animatablePositionViewModel == null)
            {
                return;
            }

            animatablePositionViewModel.XAdapter.BoundObject = null;
            animatablePositionViewModel.YAdapter.BoundObject = null;
        }
    }
}
