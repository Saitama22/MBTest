using System.Runtime.Serialization;

namespace MBTest.Exceptions {
	public class InvalidFigureException : Exception {
		public InvalidFigureException() {
		}

		public InvalidFigureException(string? message) : base(message) {
		}

		public InvalidFigureException(string? message, Exception? innerException) : base(message, innerException) {
		}

		protected InvalidFigureException(SerializationInfo info, StreamingContext context) : base(info, context) {
		}
	}
}
