namespace Domain.Service
{
    public static class ValidationService
    {
        private const string _MustBeAMinimumOfCharactersIn = "Must be a minimum of {0} characters in {1}.";
        private const string _MustBeAMaximumOfCharactersIn = "Must be a maximum of {0} characters in {1}.";
        private const string _TheStartValueCannotBeGreaterThanTheEndValue = "The {0} cannot be greater than the {1}.";
        private const string _MustBeAMinimumOfValueIn = "Must be a minimum of {0} value in {1}.";
        private const string _MustBeAMaximumOfValueIn = "Must be a maximum of {0} value in {1}.";
        private const string _TheStartDateCannotBeGreaterThanTheEndDate = "The {0} cannot be greater than the {1}.";
        private const string _MustBeADateIn = "Must be a date in {0}.";
        private const string _Field1AndField2CannotBeDuplicated = "{0} and {1} cannot be duplicated.";

        public static void SetDescription(string description, string field, int sizeMin, int sizeMax)
        {
            if ((string.IsNullOrEmpty(description) && sizeMin > 0) || description.Length < sizeMin)
                throw new Exception(string.Format(_MustBeAMinimumOfCharactersIn, sizeMin.ToString(), field.ToLower()));

            if (!string.IsNullOrEmpty(description) && description.Length > sizeMax)
                throw new Exception(string.Format(_MustBeAMaximumOfCharactersIn, sizeMax.ToString(), field.ToLower()));
        }

        public static void SetPeriodOfValue(decimal start, decimal end, string startField, string endField)
        {
            if (start > end)
                throw new Exception(string.Format(_TheStartValueCannotBeGreaterThanTheEndValue, startField.ToLower(), endField.ToLower()));
        }

        public static void SetValue(decimal value, string field, decimal valueMin, decimal valueMax)
        {
            if (value < valueMin)
                throw new Exception(string.Format(_MustBeAMinimumOfValueIn, valueMin.ToString(), field.ToLower()));

            if (value > valueMax)
                throw new Exception(string.Format(_MustBeAMaximumOfValueIn, valueMax.ToString(), field.ToLower()));
        }

        public static void SetValue(int value, string field, int valueMin, int valueMax)
        {
            if (value < valueMin)
                throw new Exception(string.Format(_MustBeAMinimumOfValueIn, valueMin.ToString(), field.ToLower()));

            if (value > valueMax)
                throw new Exception(string.Format(_MustBeAMaximumOfValueIn, valueMax.ToString(), field.ToLower()));
        }

        public static void SetPeriodOfDate(DateTime start, DateTime end, string startField, string endField)
        {
            SetDate(start, startField);
            SetDate(end, endField);

            if (start > end)
                throw new Exception(string.Format(_TheStartDateCannotBeGreaterThanTheEndDate, startField.ToLower(), endField.ToLower()));
        }

        public static void SetDate(DateTime date, string field)
        {
            if (date == DateTime.MinValue)
                throw new Exception(string.Format(_MustBeADateIn, field.ToLower()));
        }

        public static void SetDuplication(string value1, string value2, string field1, string field2)
        {
            if (value1 == value2)
            {
                throw new Exception(string.Format(_Field1AndField2CannotBeDuplicated, field1, field2));
            }
        }
    }
}
