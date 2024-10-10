using MBTest.Figures.Abstract;

namespace MBTestTests {
	class ValidFigureTestCaseModel {
		public BaseFigure Figure { get; set; }
		public double AreaTest { get; set; }
		public double PerimeterTest { get; set; }

		public int RoundValue { get; set; }
	}

	internal class FigureTest {

		[Test]
		public void DiffrentValidFiguresTest() {
			var figureTestCases = CircleTests.ValidCirclesTestCases.Select(test => new ValidFigureTestCaseModel() {
				Figure = test.Circle,
				AreaTest = test.AreaTest,
				PerimeterTest = test.PerimeterTest,
				RoundValue = test.RoundValue,
			}).ToList();

			figureTestCases.AddRange(TriangleTests.ValidTrianglesTestCases.Select(test => new ValidFigureTestCaseModel() {
				Figure = test.Triangle,
				AreaTest = test.AreaTest,
				PerimeterTest = test.PerimeterTest,
				RoundValue = test.RoundValue,
			}));

			foreach (var testcase in figureTestCases) {
				Assert.That(Math.Round(testcase.Figure.Area, testcase.RoundValue), Is.EqualTo(testcase.AreaTest), $"Неверный расчет площади для фигуры {testcase.Figure.Name}");
				Assert.That(Math.Round(testcase.Figure.Perimeter, testcase.RoundValue), Is.EqualTo(testcase.PerimeterTest), $"Неверный расчет периметра для фигуры {testcase.Figure.Name}");
			}
		}
	}
}
