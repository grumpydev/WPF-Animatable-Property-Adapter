namespace AnimationTesting.Animation
{
    /// <summary>
    /// Represents a view model that will be attached to something
    /// who's angle will be animatable.
    /// </summary>
    public interface IAnimatableAngle
    {
        /// <summary>
        /// Gets the property adapter for the angle
        /// </summary>
        AnimatablePropertyAdapter<double> AngleAdapter { get; }
    }
}