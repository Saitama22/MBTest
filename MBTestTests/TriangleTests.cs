using MBTest.Exceptions;
using MBTest.Figures;

namespace MBTestTests {
	internal class TriangleTests {
		public static List<double[]> InvalidTrianglesSidesTestCases = [
			[-1,1,1],
			[1,-1,1],
			[1,1,-1],
			[-1,-1,-1],

			[3,1,1],
			[1,3,1],
			[1,1,3],

			[],
			[1],
			[1,1],
			[1,1,1,1],

			[1,1,0],
			[1, double.NegativeInfinity, 1],
			[double.NaN, 1,1],
		];

		public static List<(Triangle Triangle, double AreaTest, double PerimeterTest, bool IsRightTest, int RoundValue)> ValidTrianglesTestCases = [
			new() {
				Triangle = new(1,1,1),
				AreaTest = 0.43,
				PerimeterTest = 3,
				IsRightTest = false,
				RoundValue = 2
			},
			new() {
				Triangle = new(1,2,3),
				AreaTest = 0,
				PerimeterTest = 6,
				IsRightTest = false,
				RoundValue = 2
			},
			new() {
				Triangle = new(3,4,5),
				AreaTest = 6,
				PerimeterTest = 12,
				IsRightTest = true,
				RoundValue = 2
			},
			new() {
				Triangle = new(0.0001,0.0002,0.0001),
				AreaTest = 0,
				PerimeterTest = 0.0004,
				IsRightTest = false,
				RoundValue = 8
			},
			new() {
				Triangle = new(1.1,2.5,3),
				AreaTest = 1.32	,
				PerimeterTest = 6.6,
				IsRightTest = false,
				RoundValue = 2
			},
		];

		/// <summary>
		/// Тесты со случайными значениями для проверки валидации
		/// </summary>
		[Test]
		public void TestValidationTriangles() {
			for (int i = 0; i < 1000; i++) {
				var random = new Random();
				var a = random.NextDouble() - 0.1;	
				var b = random.NextDouble() - 0.1;	
				var c = random.NextDouble() - 0.1;
				var isNegativeValue = (a < 0 || b < 0 || c < 0);
				var invalidSides = (a > b + c || b > a + c || c > a + b);

				try {
				 	var triangle = new Triangle(a, b, c);
					triangle.SetSides(0.24263740539632692, 0.8650223048604818, 0.8802235560926043);
					if (isNegativeValue)
						Assert.Fail($"Можно создать треугольник с сторонами меньше 0. Стороны {a}, {b}, {c}");
					if (invalidSides)
						Assert.Fail($"Можно создать треугольник с одной стороной больше двух других. Стороны {a}, {b}, {c}");
				}
				catch (InvalidFigureException ex) {
					if (!isNegativeValue && !invalidSides)
						Assert.Fail($"Невозможно создать треугольник со сторонами {a}, {b}, {c}. Ошибка: {ex.Message}");
				}			
			}
		}

		/// <summary>
		/// Отрицательные тесты
		/// </summary>
		[Test]
		public void TestInvalidTriangles() {
			foreach (var triangleSides in InvalidTrianglesSidesTestCases) {
				try {
					var triangle = new Triangle(triangleSides);
					Assert.Fail($"Можно создать треугольник: {triangle.A}, {triangle.B}, {triangle.C} ");
				}
				catch (InvalidFigureException) {
				}
			}

			try {
				var triangle = new Triangle(1, 1, 1);
				triangle.A = -1;
				Assert.Fail($"Можно создать треугольник: {triangle.A}, {triangle.B}, {triangle.C} ");
			}
			catch (InvalidFigureException) { }

			try {
				var triangle = new Triangle(1, 1, 1);
				triangle.B = -1;
				Assert.Fail($"Можно создать треугольник: {triangle.A}, {triangle.B}, {triangle.C} ");
			}
			catch (InvalidFigureException) { }

			try {
				var triangle = new Triangle(1, 1, 1);
				triangle.C = -1;
				Assert.Fail($"Можно создать треугольник: {triangle.A}, {triangle.B}, {triangle.C} ");
			}
			catch (InvalidFigureException) { }

			try {
				var triangle = new Triangle(1, 1, 1);
				triangle.A = 3;
				Assert.Fail($"Можно создать треугольник: {triangle.A}, {triangle.B}, {triangle.C} ");
			}
			catch (InvalidFigureException) { }

			try {
				var triangle = new Triangle(1, 1, 1);
				triangle.B = 3;
				Assert.Fail($"Можно создать треугольник: {triangle.A}, {triangle.B}, {triangle.C} ");
			}
			catch (InvalidFigureException) { }

			try {
				var triangle = new Triangle(1, 1, 1);
				triangle.C = 3;
				Assert.Fail($"Можно создать треугольник: {triangle.A}, {triangle.B}, {triangle.C} ");
			}
			catch (InvalidFigureException) { }
		}

		/// <summary>
		/// Положительные тесты
		/// </summary>
		[Test]
		public void TestValidTriangle() {
			foreach (var testTriangle in ValidTrianglesTestCases) {
				Assert.That(Math.Round(testTriangle.Triangle.Area, testTriangle.RoundValue), Is.EqualTo(testTriangle.AreaTest),
					$"Неверный расчет площади треугольника. Стороны {testTriangle.Triangle.A} {testTriangle.Triangle.B} {testTriangle.Triangle.C}");

				Assert.That(Math.Round(testTriangle.Triangle.Perimeter, testTriangle.RoundValue), Is.EqualTo(testTriangle.PerimeterTest),
					$"Неверный расчет периметра треугольника. Стороны {testTriangle.Triangle.A} {testTriangle.Triangle.B} {testTriangle.Triangle.C}");

				Assert.That(testTriangle.Triangle.Perimeter, Is.EqualTo(testTriangle.Triangle.A + testTriangle.Triangle.B + testTriangle.Triangle.C),
					$"Неверный расчет периметра треугольника. Стороны {testTriangle.Triangle.A} {testTriangle.Triangle.B} {testTriangle.Triangle.C}");

				Assert.That(testTriangle.Triangle.IsRightTriangle(), Is.EqualTo(testTriangle.IsRightTest),
					$"Неверная проверка на прямоугольность треугольника. Стороны {testTriangle.Triangle.A} {testTriangle.Triangle.B} {testTriangle.Triangle.C}");
			}
		}
	}
}
