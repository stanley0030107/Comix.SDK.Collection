using System;
using System.Collections.Generic;
using System.Data;

namespace ComixSAP.Service.Common
{
    public class BusinessBase
    {
        /// <summary>
        /// 根据IQuery接口返回查询结果
        /// </summary>
        public virtual DataTable QueryByCondition(IQuery query)
        {
            return DataAccess.QueryDataSet(query);
        }

        /// <summary>
        /// 返回实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public List<T> SelectByCondition<T>(ComixSAP.Common.Utils.QueryCondition whereCondition) where T : EntityBase, new()
        {
            T ety = Activator.CreateInstance<T>();
            string sql = "SELECT * FROM {0} WHERE {1}";
            if (!whereCondition.ExistWhereString)
            {
                sql = "SELECT * FROM {0} {1}";
            }
            return DataAccess.Select<T>(string.Format(sql, ety.OringTableSchema.TableName, whereCondition.ToString()));
        }

        public List<T> SelectByCondition<T>(T entity) where T : EntityBase, new()
        {
            return DataAccess.Select<T>(entity);
        }

        /// <summary>
        /// 根据查询条件返回DataSet
        /// </summary>
        public DataSet QueryByCondition<T>(ComixSAP.Common.Utils.QueryCondition whereCondition) where T : EntityBase, new()
        {
            T ety = Activator.CreateInstance<T>();
            string sql = "SELECT * FROM {0} WHERE {1}";
            if (!whereCondition.ExistWhereString)
            {
                sql = "SELECT * FROM {0} {1}";
            }
            return DataAccess.Select(string.Format(sql, ety.OringTableSchema.TableName, whereCondition.ToString()), null);
        }

        /// <summary>
        /// 根据查询条件返回DataSet
        /// </summary>
        public T GetById<T>(string id) where T : EntityBase, new()
        {
            T ety = Activator.CreateInstance<T>();
            List<T> list = SelectByCondition<T>(ComixSAP.Common.Utils.QueryCondition.Create().Equals(ety.OringTableSchema.KeyColumnInfo[0].ColumnName, id));
            if (list.Count > 0)
                return list[0];
            return null;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Update(EntityBase entity)
        {
            DataAccess.Update(entity);
            return true;

        }

        /// <summary>
        /// 更新实体，事务操作
        /// </summary>
        public virtual bool Update(EntityBase entity, DataAccessBroker broker)
        {
            DataAccess.Update(entity, broker);
            return true;
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        public virtual bool Insert(EntityBase entity)
        {

            DataAccess.Insert(entity);
            return true;

        }

        /// <summary>
        /// 插入实体，事务操作
        /// </summary>
        public virtual bool Insert(EntityBase entity, DataAccessBroker broker)
        {
            DataAccess.Insert(entity, broker);
            return true;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        public virtual bool Delete(EntityBase entity)
        {
            return DataAccess.Delete(entity);
        }

        /// <summary>
        /// 删除实体，事务操作
        /// </summary>
        public virtual void Delete(EntityBase entity, DataAccessBroker broker)
        {
            DataAccess.Delete(entity, broker);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        public virtual void Delete<T>(List<string> listId, DataAccessBroker broker) where T : EntityBase, new()
        {
            List<T> list = new List<T>();
            foreach (string id in listId)
            {
                T t = new T();
                t[t.OringTableSchema.KeyColumnInfo[0].ColumnName] = id;
                list.Add(t);
            }
            DataAccess.Delete<T>(list, broker);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        public virtual bool Delete<T>(List<string> listId) where T : EntityBase, new()
        {
            using (DataAccessBroker broker = DataAccessFactory.Instance())
            {
                try
                {
                    broker.BeginTransaction();
                    Delete<T>(listId, broker);
                    broker.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    broker.RollBack();
                    Log(ex);
                    return false;
                }
            }
        }


        protected void Log(Exception ex)
        {
            try
            {
                //CDPService.LogErrorService.InsertLog(ex);
            }
            catch { }
        }

        #region 邮件抄送配置

        private string _emailSend;
        public string EmailSend
        {
            get
            {
                if (string.IsNullOrEmpty(_emailSend))
                {
                    _emailSend = Furion.App.Configuration["EmailSendConfig"];
                }

                return _emailSend;
            }
        }
        private string _emailCC;
        public string EmailCC
        {
            get
            {
                if (string.IsNullOrEmpty(_emailCC))
                {
                    _emailCC = Furion.App.Configuration["EmailCCConfig"];
                }

                return _emailCC;
            }
        }
        #endregion
    }
}
