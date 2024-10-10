using MBTest.Exceptions;
using MBTest.Figures.Abstract;

namespace MBTest.Figures {
	public class Triangle : BasePolygon {
		/// <summary>
		/// Расчет площади по формуле Герона
		/// </summary>
		public override double Area {
			get {
				double halfPerimeter = Perimeter / 2;
				return Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));
			}
		}

		protected override int SidesNumber => 3;

		public override string Name => "Треугольник";

		public double A {
			get => Sides[0];
			set {
				if (!IsValidFigure([value, B, C], out var error))
					throw new InvalidFigureException(error);
				Sides[0] = value;
			}
		}

		public double B {
			get => Sides[1];
			set {
				if (!IsValidFigure([A, value, C], out var error))
					throw new InvalidFigureException(error);
				Sides[1] = value;
			}
		}

		public double C {
			get => Sides[2];
			set {
				if (!IsValidFigure([A, B, value], out var error))
					throw new InvalidFigureException(error);
				Sides[2] = value;
			}
		}
		
		public Triangle(double A, double B, double C): base([A, B, C]) {
		}

		public Triangle(double[] sides): base(sides) {
		}

		public void SetSides(double a, double b, double c) {
			Sides = [a, b, c];
		}

		public void SetSides(double[] sides) {
			Sides = sides;
		}

		/// <summary>
		/// Проверка треугольника на прямоугольность
		/// </summary>
		/// <returns></returns>
		public bool IsRightTriangle() {
			var orderSides = Sides.OrderBy(side => side).ToArray();
			if (Math.Pow(orderSides[2], 2) == Math.Pow(orderSides[0], 2) + Math.Pow(orderSides[1], 2))
				return true;
			return false;
		}

		protected override bool IsValidFigure(double[] sides, out string errorMessage) {
			if (!base.IsValidFigure(sides, out errorMessage)) 
				return false;

			var orderSides = sides.OrderBy(side => side).ToArray();
			if (orderSides[2] > orderSides[0] + orderSides[1]) {
				errorMessage = $"Сторона треугольника не может быть больше двух других. Стороны: [{SidesToString(sides)}]";
				return false;
			}
			return true;
		}
	}
}
