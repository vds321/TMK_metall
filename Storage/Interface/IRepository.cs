using System.Collections.Generic;
using System.Linq;

namespace Storage.Interface
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Получить коллекцию объектов
        /// </summary>
        IQueryable<T> Items { get; }

        #region Синхронные операции с репозиториями

        /// <summary>
        /// Получить объект по его идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Сохранить объект в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возвращает сохраненный объект</returns>
        T Add(T item);

        /// <summary>
        /// Сохранить коллекцию объектов в БД
        /// </summary>
        /// <param name="itemCollection"></param>
        /// <returns>Возвращает количество сохраненных объектов</returns>
        int AddRange(IEnumerable<T> itemCollection);

        /// <summary>
        /// Изменить объект в БД
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Удалить объект из БД
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);

        /// <summary>
        /// Прямой запрос в БД
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IQueryable<T> ExecuteSQL(string query);

        #endregion

    }
}