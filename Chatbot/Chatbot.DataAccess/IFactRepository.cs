namespace Chatbot.DataAccess
{
    public interface IFactRepository
    {
        //Hello:)
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
