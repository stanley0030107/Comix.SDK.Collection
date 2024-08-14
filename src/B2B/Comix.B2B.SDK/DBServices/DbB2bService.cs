using Comix.B2B.SDK.Entities;
using Comix.B2B.SDK.Interfaces;
using Comix.Core.Sqlsugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Comix.B2B.SDK.DBService
{
    /// <summary>
    /// 基于数据库实现的B2B服务
    /// </summary>
    public class DbB2bService : IB2bService
    {
        private readonly ISqlSugarClient _db;
        private SqlSugarRepository<MsEnterprise> MsEnterpriseRepo => new SqlSugarRepository<MsEnterprise>(_db);
        private SqlSugarRepository<ShopOrders> ShopOrdersRepo => new SqlSugarRepository<ShopOrders>(_db);

        public DbB2bService(ISqlSugarClient db)
        {
            _db = db;
        }

        public Task<MsEnterprise> GetByCodeAsync(string code)
        {
            return MsEnterpriseRepo.GetFirstAsync(o => o.EnterpriseCode == code);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="orderCode"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public Task<int> UpdateOrderStatusAsync(List<string> orderCode, int orderStatus)
        {
            return ShopOrdersRepo.AsUpdateable()
                .SetColumns(o => o.OrderStatus == orderStatus)
                .SetColumns(o => o.UpdatedDate == DateTime.Now)
                .Where(o => orderCode.Contains(o.OrderCode))
                .ExecuteCommandAsync();
        }

        /// <summary>
        /// 审批订单通过
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        public async Task<string> ApproveOrder(string orderCode)
        {
            SugarParameter[] spParameters = new SugarParameter[4];
            spParameters[0] = new SugarParameter("orderStatus", 1);
            spParameters[1] = new SugarParameter("orderCode", orderCode);
            spParameters[2] = new SugarParameter("shippingStatus", 0);
            spParameters[3] = new SugarParameter("errMessage", "", isOutput: true);
            
            await _db.Ado.UseStoredProcedure().ExecuteCommandAsync("spUpdateOrder", spParameters);
            var errorMessage = spParameters[4].Value.ToString();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }
            
            return null;
        }
    }
}
