namespace NHibernate.Data.Entities
{
    public class CustomResult
    {
        public CustomResult()
        {
            this.IsSucceeded = false;
            this.ErrorMessage = string.Empty;
            this.UserMessage = string.Empty;
        }

        public string ErrorMessage { get; set; }

        public bool IsSucceeded { get; set; }

        public string UserMessage { get; set; }

        public int ID { get; set; }

        public string Value { get; set; }

        public string Value1 { get; set; }

        public string Value2 { get; set; }

        public string MessageNo { get; set; }

        public string LogNo { get; set; }

        public string Duration { get; set; }
    }

    public class CustomResult<T> : CustomResult
    {
        public T TransactionResult { get; set; }
    }
}