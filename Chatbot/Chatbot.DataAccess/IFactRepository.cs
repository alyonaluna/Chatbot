namespace Chatbot.DataAccess
{
    public interface IFactRepository
    {
        /// <summary>
        /// Добавить факт в базу знаний
        /// </summary>
        void Add(Fact fact);

        /// <summary>
        /// Получить ответ на вопрос
        /// </summary>
        Fact Get(string question);
    }
}
