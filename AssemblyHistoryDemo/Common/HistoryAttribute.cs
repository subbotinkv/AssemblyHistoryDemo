namespace Common
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HistoryAttribute : Attribute
    {
        public HistoryAttribute(string dateTime, string author, string description)
        {
            DateTime = dateTime;
            Author = author;
            Description = description;
        }

        public string DateTime { get; }

        public string Author { get; }

        public string Description { get; }
    }
}