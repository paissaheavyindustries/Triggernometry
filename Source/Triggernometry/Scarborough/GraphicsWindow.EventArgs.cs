using System;

using Scarborough.Drawing;

namespace Scarborough.Windows
{
    /// <summary>
    /// Provides data for the DrawGraphics event.
    /// </summary>
    public class DrawGraphicsEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the Graphics surface.
        /// </summary>
        public Graphics Graphics { get; }

        private DrawGraphicsEventArgs()
        {
        }

        /// <summary>
        /// Initializes a new DrawGraphicsEventArgs with a Graphics surface.
        /// </summary>
        /// <param name="graphics"></param>
		public DrawGraphicsEventArgs(Graphics graphics)
        { 
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }
            Graphics = graphics;
        }
    }

    /// <summary>
    /// Provides data for the SetupGraphics event.
    /// </summary>
    public class SetupGraphicsEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the Graphics surface.
        /// </summary>
        public Graphics Graphics { get; }

        private SetupGraphicsEventArgs()
        {
        }

        /// <summary>
        /// Initializes a new SetupGraphicsEventArgs with a Graphics surface.
        /// </summary>
        /// <param name="graphics"></param>
        public SetupGraphicsEventArgs(Graphics graphics)
        { 
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }
            Graphics = graphics;
        }
    }

    /// <summary>
    /// Provides data for the DestroyGraphics event.
    /// </summary>
    public class DestroyGraphicsEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the Graphics surface.
        /// </summary>
        public Graphics Graphics { get; }

        private DestroyGraphicsEventArgs()
        {
        }

        /// <summary>
        /// Initializes a new DestroyGraphicsEventArgs with a Graphics surface.
        /// </summary>
        /// <param name="graphics"></param>
        public DestroyGraphicsEventArgs(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }
            Graphics = graphics;
        }
    }
}
