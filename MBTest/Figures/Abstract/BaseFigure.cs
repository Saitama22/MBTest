namespace MBTest.Figures.Abstract {
	public abstract class BaseFigure
    {
        public abstract double Area { get; }

        public abstract double Perimeter { get; }

        public abstract string Name { get; }

        /// <summary>
        /// Проверка на валидность значения (больше 0 и является числом)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool IsExtremalValue(double value) { 
            if (value < 0 || value == 0 || value is double.NegativeInfinity || value is double.PositiveInfinity || value is double.NaN) {
				return true;
            }
            return false;
        }
    }
}
