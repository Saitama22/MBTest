using MBTest.Exceptions;
using MBTest.Figures.Abstract;

namespace MBTest.Figures {
	public class Circle : BaseFigure {
		private double _radius;
		public double Radius {
			get => _radius;
			set {
				if (IsExtremalValue(value))
					throw new InvalidFigureException($"Невозможно создать {Name} с радиусом {value}");
				_radius = value;
			}
		}

		public Circle(double radius) {
			Radius = radius;
		}

		public override double Area => Math.PI * Math.Pow(Radius, 2);

		public override double Perimeter => 2 * Math.PI * Radius;

		public override string Name => "Окружность";
	}
}
