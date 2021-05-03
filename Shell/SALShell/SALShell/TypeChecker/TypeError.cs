namespace SALShell.TypeChecker
{
    class TypeError
    {
        public TypeError(int line, string message)
        {
            Line = line;
            Message = message;
        }

        public string Message { get; set; }

        public int Line { get; set; }
    }
}