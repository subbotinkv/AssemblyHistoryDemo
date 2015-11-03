namespace Common
{
    using System;

    /// <summary>
    /// Атрибут для описания истории изменения.
    /// Можно указывать несколько атрибутов изменения для одного члена типа.
    /// Данный атрибут можно использовать для классов и методов - так указано в постановке задачи. Но не составит большого труда снять это ограничение.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HistoryAttribute : Attribute
    {
        public HistoryAttribute(string dateTime, string author, string description)
        {
            DateTime = DateTime.Parse(dateTime);
            Author = author;
            Description = description;
        }

        /// <summary>
        /// Дата внесения изменений.
        /// </summary>
        public DateTime DateTime { get; }

        /// <summary>
        /// Автор изменений.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Описание внесенных изменений.
        /// </summary>
        public string Description { get; }
    }
}