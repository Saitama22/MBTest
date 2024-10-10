using MBTest.Exceptions;
using MBTest.Figures;

namespace MBTestTests {
	public class CircleTests {
		public static List<double> InvalidRadiusTestCases = [ 0,-1,-2,-100,-0.0001, double.NaN, double.NegativeInfinity ];

		public static List<(Circle Circle, double PerimeterTest, double AreaTest, int RoundValue)> ValidCirclesTestCases = [
			new() {
				Circle = new Circle(1),
				PerimeterTest = 6.28,
				AreaTest = 3.14,
				RoundValue = 2
			},
			new() {
				Circle = new Circle(5),
				PerimeterTest = 31.42,
				AreaTest = 78.54,
				RoundValue = 2
			},
			new() {
				Circle = new(3.33),
				AreaTest = 34.84,
				PerimeterTest = 20.92,
				RoundValue = 2
			},
		];

		/// <summary>
		/// �������� ���������� ������
		/// </summary>
		[Test]
		public void TestInvalidCircles() {
			foreach (var radius in InvalidRadiusTestCases) {
				try {
					new Circle(radius);
					Assert.Fail("����� ������� ���������� � �������� ������ 0");
				}
				catch (InvalidFigureException) {
				}
			}
			foreach (var radius in InvalidRadiusTestCases) {
				try {
					var circle = new Circle(1);
					circle.Radius = radius;
					Assert.Fail("����� �������� ������ �� �������� ������ 0");
				}
				catch (InvalidFigureException) {
				}
			}
		}

		/// <summary>
		/// ������������� ����� �� �������
		/// </summary>
		[Test]
		public void TestPerimeterAreaFormula() {
			for (int i = 0; i < 100; i++) {
				Random random = new();
				var radius = random.NextDouble();
				var cirle = new Circle(radius);
				Assert.That(cirle.Perimeter, Is.EqualTo(radius * 2 * Math.PI), $"������ ��������� ���������� ������� ��� ������� {radius}");
				Assert.That(cirle.Area, Is.EqualTo(Math.Pow(radius, 2) * Math.PI), $"������ ������� ���������� ������� ��� ������� {radius}");
			}
		}

		/// <summary>
		/// ������������� �����
		/// </summary>
		[Test]
		public void TestPerimeterArea() {
			foreach (var validCirclesTest in ValidCirclesTestCases) {
				Assert.That(Math.Round(validCirclesTest.Circle.Perimeter, 2), Is.EqualTo(validCirclesTest.PerimeterTest), $"������ ��������� ���������� ������� ��� ������� {validCirclesTest.Circle.Radius}");
				Assert.That(Math.Round(validCirclesTest.Circle.Area, 2), Is.EqualTo(validCirclesTest.AreaTest), $"������ ������� ���������� ������� ��� ������� {validCirclesTest.Circle.Radius}");
			}
		}
	}
}