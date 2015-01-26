using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogDataInterface
{
    interface User
    {
        #region public int Add(BlogData.Models.User model)+数据库增加
        /// <summary>
        /// 数据库增加
        /// </summary>
        /// <param name="model">要增加的实体对象</param>
        /// <returns></returns>
        int Add(BlogData.Models.User model);
        #endregion

        #region public int Del(T model)+根据id删除
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="model">包含主键实体对象</param>
        /// <returns></returns>
        int Del(BlogData.Models.User model);
        #endregion

        #region public int DelWhere(Expression<Func<BlogData.Models.User, bool>> where)+根据条件删除
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="where">删除条件Lambda表达式</param>
        /// <returns></returns>
        int DelWhere(Expression<Func<BlogData.Models.User, bool>> where);
        #endregion

        #region public int Modify(BlogData.Models.User model, params string[] proNames)+数据层修改
        /// <summary>
        /// 数据层修改
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的属性名称</param>
        /// <returns></returns>
        int Modify(BlogData.Models.User model, params string[] proNames);
        #endregion

        #region public List<BlogData.Models.User> Search(Expression<Func<BlogData.Models.User, bool>> whereLambda)+普通查询
        /// <summary>
        /// 普通查询
        /// </summary>
        /// <param name="whereLambda">查询条件Lambda表达式</param>
        /// <returns></returns>
        public List<BlogData.Models.User> Search(Expression<Func<BlogData.Models.User, bool>> whereLambda);
        #endregion

        #region public List<BlogData.Models.User> Search<TKey>(Expression<Func<BlogData.Models.User, bool>> whereLambda, Expression<Func<BlogData.Models.User, TKey>> orderLambda)+排序查询
        /// <summary>
        /// 排序查询
        /// </summary>
        /// <typeparam name="TKey">泛型类对象</typeparam>
        /// <param name="whereLambda">查询条件Lambda表达式</param>
        /// <param name="orderLambda">排序条件Lambda表达式</param>
        /// <returns></returns>
        public List<BlogData.Models.User> Search<TKey>(Expression<Func<BlogData.Models.User, bool>> whereLambda, Expression<Func<BlogData.Models.User, TKey>> orderLambda);
        #endregion

        #region public List<BlogData.Models.User Search<TKey>(Expression<Func<BlogData.Models.User, bool>> whereLambda, Expression<Func<BlogData.Models.User, TKey>> orderLambda, int pageIndex, int pageSize)+分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TKey">泛型类对象</typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        List<BlogData.Models.User> Search<TKey>(Expression<Func<BlogData.Models.User, bool>> whereLambda, Expression<Func<BlogData.Models.User, TKey>> orderLambda, int pageIndex, int pageSize);
        #endregion

        #region public long SearchCount()+查询元素总个数
        /// <summary>
        /// 查询元素总个数
        /// </summary>
        /// <returns></returns>
        long SearchCount(Expression<Func<BlogData.Models.User, bool>> whereLambad);
        #endregion
    }
}
