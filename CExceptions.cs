global using static Star_Simulation.CExceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Simulation
{
    internal partial class CExceptions
    {
        /// <summary>
        /// Throws an Error when a Value on a MyObjectGeneration (like MyStarGeneration) on Use is Missing.
        /// </summary>
        /// <remarks>
        /// Found this Possebility of Creating My Own when Trying to Find a Correct Exeption when a Value is Missing<br/><br/>
        /// 
        /// For A Exception to Work, i Apparently needs :base. idk why.
        /// </remarks>
        public class MyObjectGenerationValueException : Exception
        {
            /// <summary>
            /// Throws an Error when a Value on a MyObjectGeneration (like MyStarGeneration) on Use is Missing.
            /// </summary>
            public MyObjectGenerationValueException(string position = "Unknown")
                : base($"{position} Value is Missing.") { }
        }
        /// <summary>
        /// Throws an Error when a Value on a MyObject is invalid (Like for example min > max).
        /// </summary>
        /// <remarks>
        /// </remarks>
        public class MyObjectInvalidValueException : Exception
        {
            /// <summary>
            /// Throws an Error when a Value on a MyObject is invalid (Like for example min > max).
            /// </summary>
            public MyObjectInvalidValueException(string error)
                : base(error) { }
        }

        /// <summary>
        /// Throws an Error when a Value on a Resource (like Density) on Use is Missing.
        /// </summary>
        public class MyResourceMissingException : Exception
        {
            /// <summary>
            /// Throws an Error when a Value on a MyObjectGeneration (like MyStarGeneration) on Use is Missing.
            /// </summary>
            public MyResourceMissingException(string position)
                : base($"{position} Value is Missing.") { }
        }

        /// <summary>
        /// Throws an Error when a Value on a Resource (like Density) on Use is Missing.
        /// </summary>
        public class MyResourceInvalidValueException : Exception
        {
            /// <summary>
            /// Throws an Error when a Value on a Resource (like Density) on Use is Missing.
            /// </summary>
            public MyResourceInvalidValueException(string error)
                : base(error) { }
        }

        /// <summary>
        /// Throws an Error on a Resource List a Length Error (For Example, if the Value is Zero).
        /// </summary>
        public class MyResourceListLengthException : Exception
        {
            /// <summary>
            /// Throws an Error on a Resource List a Length Error.
            /// </summary>
            public MyResourceListLengthException(string error)
                : base(error) { }
        }

        /// <summary>
        /// THrows a Error When a Generation COnstant Value is not Valid (For Example, if Min is larger then Max)
        /// </summary>
        public class GenerationConstantValueException : Exception
        {
            /// <summary>
            /// THrows a Error When a Generation Constant Value is not Valid.
            /// </summary>
            public GenerationConstantValueException(string error)
                : base(error) { }
        }
    }
}
