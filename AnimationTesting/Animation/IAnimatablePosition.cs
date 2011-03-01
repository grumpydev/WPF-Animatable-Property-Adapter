namespace AnimationTesting.Animation
{
    /// <summary>
    /// Represents a view model that will be attached to something
    /// who's position will be animatable.
    /// </summary>
    public interface IAnimatablePosition
    {
        /// <summary>
        /// Gets the property adapter for the X position
        /// </summary>
        AnimatablePropertyAdapter<double> XAdapter { get; }

        /// <summary>
        /// Gets the property adapter for the Y position
        /// </summary>
        AnimatablePropertyAdapter<double> YAdapter { get; }
    }
}