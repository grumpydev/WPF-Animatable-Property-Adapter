namespace AnimationTesting.Animation
{
    using System;
    using System.Windows;

    /// <summary>
    /// Provides a mechanism for reading the current value of a dependency
    /// property from an item that is currently being animated by the WPF
    /// animation system.
    /// </summary>
    /// <typeparam name="T">Return type of the dependency property</typeparam>
    public class AnimatablePropertyAdapter<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnimatablePropertyAdapter{T}"/> class.
        /// </summary>
        /// <param name="property">The DependencyProperty the adapter will read.</param>
        public AnimatablePropertyAdapter(DependencyProperty property)
        {
            this.Property = property;
        }

        /// <summary>
        /// Weak reference to the bound object so we don't keep the view alive.
        /// </summary>
        private WeakReference weakBoundObject;

        /// <summary>
        /// Gets the DependencyProperty the adapter will read.
        /// </summary>
        public DependencyProperty Property { get; private set; }

        /// <summary>
        /// Gets or sets the bound object that the value will be read values from.
        /// </summary>
        public DependencyObject BoundObject
        {
            private get
            {
                return (DependencyObject)this.weakBoundObject.Target;
            }

            set
            {
                this.weakBoundObject = new WeakReference(value);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the adapter is bound or not.
        /// </summary>
        public bool IsBound
        {
            get
            {
                if (this.weakBoundObject == null)
                {
                    return false;
                }

                return this.weakBoundObject.Target != null;
            }
        }

        /// <summary>
        /// Gets the current value of the dependency property from the bound object.
        /// </summary>
        /// <returns>Current value</returns>
        /// <exception cref="InvalidOperationException">Adapter is unbound</exception>
        public T GetValue()
        {
            if (!this.IsBound)
            {
                throw new InvalidOperationException("Unable to GetValue() from an unbound adapter.");
            }

            var value = this.BoundObject.GetValue(this.Property);

            return (T)value;
        }
    }
}