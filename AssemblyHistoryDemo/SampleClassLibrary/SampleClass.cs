namespace SampleClassLibrary
{
    using Common;

    /// <summary>
    /// Тестовый класс для применения атрибута истории изменения.
    /// </summary>
    [History("2015.10.03", "Koc", "ClassChangesDescription")]
    [History("2015.11.03", "Diana", "ClassChangesDescription2")]
    public class SampleClass
    {
        /// <summary>
        /// Тестовый метод для применения атрибута истории изменения.
        /// </summary>
        [History("2015.10.03", "Koc", "MethodChangesDescription")]
        public void SampleMethod()
        {

        }

        /// <summary>
        /// Еще один тестовый метод для применения атрибута истории изменения.
        /// </summary>
        [History("2015.10.04", "Max", "MethodChangesDescription2")]
        public void SampleMethod2()
        {

        }
    }
}
