//-----------------------------------------------------------------------
// <copyright file="TraceListnener.cs"
//            project="PauloMorgado.TestTools.VisualStudio"
//            solution="PMTestTools"
//            assembly="PauloMorgado.TestTools.VisualStudio"
//            company="Paulo Morgado">
//     Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <author>Paulo Morgado</author>
// <summary>A TraceListnener thatthrows an AssertFailedException exception when its Fail method is called.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.TestTools.VisualStudio.UnitTesting.Diagnostics
{
    /// <summary>
    /// A <see cref="T:System.Diagnostics.TraceListnener"/> that
    /// throws an <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException"/> exception
    /// when the <see cref="M:Fail"/> method is called.
    /// </summary>
    public class TraceListnener : global::System.Diagnostics.TraceListener
    {
        /// <summary>
        /// A default instance of the <see cref="T:TraceListnener"/> to prevent repeated instantiations.
        /// </summary>
        public static readonly TraceListnener Default = new TraceListnener();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TraceListnener"/> class.
        /// </summary>
        protected TraceListnener()
        {
            this.Name = "Testing Trace Listener";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TraceListnener"/> class.
        /// </summary>
        /// <param name="name">The name of the <see cref="T:TraceListener"/>.</param>
        protected TraceListnener(string name)
            : base(name)
        {
        }

        /// <summary>
        /// When overridden in a derived class, writes the specified message to the listener you create in the derived class.
        /// </summary>
        /// <param name="message">A message to write.</param>
        public override void Write(string message)
        {
        }

        /// <summary>
        /// When overridden in a derived class, writes a message to the listener you create in the derived class, followed by a line terminator.
        /// </summary>
        /// <param name="message">A message to write.</param>
        public override void WriteLine(string message)
        {
        }

        /// <summary>
        /// Emits an error message and a detailed error message to the listener you create when you implement the <see cref="T:System.Diagnostics.TraceListener"/> class.
        /// </summary>
        /// <param name="message">A message to emit.</param>
        /// <param name="detailMessage">A detailed message to emit.</param>
        public override void Fail(string message, string detailMessage)
        {
            var builder = new global::System.Text.StringBuilder();

            builder.Append(message);

            if (detailMessage != null)
            {
                builder.Append(" ");
                builder.Append(detailMessage);
            }

            throw new global::Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException(builder.ToString());
        }
    }
}
