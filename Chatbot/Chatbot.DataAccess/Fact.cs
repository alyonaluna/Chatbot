using System;

namespace Chatbot.DataAccess
{
    public class Fact
    {
        /// <summary>
        /// Идентификатор в БД
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Вопрос  
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Ответ
        /// </summary>
        public string Answer { get; set; }
    }
}
