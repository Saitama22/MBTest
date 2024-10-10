using MBTest.Exceptions;

namespace MBTest.Figures.Abstract {
	public abstract class BasePolygon : BaseFigure {
		private double[] _sides;
		protected double[] Sides {
			get => _sides;
			set {
				if (!IsValidFigure(value, out var errorMessage))
					throw new InvalidFigureException($"Невозможно создать {Name}: {errorMessage}");
				_sides = value;
			}
		}

		/// <summary>
		/// Количество сторон многоугольника
		/// </summary>
		protected abstract int SidesNumber { get; }

		public override double Perimeter => Enumerable.Sum(Sides);

		protected BasePolygon(double[] sides) {
			Sides = sides;
		}
		
		/// <summary>
		/// Проверка того, может ли существовать многоугольник с задаными сторонами
		/// </summary>
		protected virtual bool IsValidFigure(double[] sides, out string errorMessage) {
			errorMessage = string.Empty;

			if (sides.Length != SidesNumber)
				throw new InvalidFigureException($"Ошибка в количестве сторон у фигуры {Name}: {sides.Length}, ожидалось {SidesNumber}. Стороны: [{SidesToString(sides)}]");

			if (sides.Any(side => IsExtremalValue(side))) {
				errorMessage = $"Ошибка в значении длины стороны. Стороны: [{SidesToString(sides)}]";
				return false;
			}
			return true;
		}

		/// <summary>
		/// Стороны в стороковом выражении в формате "a, b, c"
		/// </summary>
		/// <param name="sides"></param>
		/// <returns></returns>
		protected string SidesToString(double[] sides) {
			return string.Join(", ", sides.Select(r => r.ToString()));
		}
	}
}
