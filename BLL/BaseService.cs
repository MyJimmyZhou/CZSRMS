﻿/**************************************************
 *项目名称：BLL
 *作者：周继良
 *单位：湖南省第一测绘院
 *CLR版本：4.0.30319.42000
 *创建时间：2017/7/31 17:14:52
 *更新时间：2017/7/31 17:14:52
 **************************************************
 * Copyright @ 周继良 2017. All rights reserved.
 **************************************************/

using BLL.Tools;
using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL
{
    public abstract class BaseService<T> : InterfaceBaseService<T> where T : class
    {
        protected InterfaceBaseRepository<T> CurrentRepository { get; set; }
        public BaseService(InterfaceBaseRepository<T> currentRepository)
        {
            CurrentRepository = currentRepository;
        }
        public T Add(T entity)
        {
            try
            {
                return CurrentRepository.Add(entity);
            }
            catch(Exception e)
            {
                Log.AddRecord(e);
                //在这里处理异常
                return null;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                return CurrentRepository.Update(entity);
            }
            catch(Exception e)
            {
                Log.AddRecord(e);
                return false;
            }
        }
        public bool UpdateMulti(List<T> list)
        {
            try
            {
                return CurrentRepository.UpdateMulti(list);
            }
            catch (Exception e)
            {
                Log.AddRecord(e);
                return false;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                return CurrentRepository.Delete(entity);
            }
            catch(Exception e)
            {
                Log.AddRecord(e);
                return false;
            }
        }
        public bool Delete(Expression<Func<T, bool>> whereLamdba)
        {
            try
            {
                T obj = Find(whereLamdba);
                return Delete(obj);
            }
            catch(Exception e)
            {
                Log.AddRecord(e);
                return false;
            }
        }
        /// <summary>
        /// 返回查询对象的默认值
        /// </summary>
        /// <param name="whereLamdba"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> whereLamdba)
        {
            try
            {
                return CurrentRepository.Find(whereLamdba);
            }
            catch(Exception e)
            {
                Log.AddRecord(e);
                return null;
            }
        }
        public List<T> FindAll(Expression<Func<T,bool>> where,string orderName,bool isArsc)
        {
            List<T> list = new List<T>();
            try
            {
                var info = CurrentRepository.FindList(where, orderName, false);
                foreach(T item in info)
                {
                    list.Add(item);
                }
                return list;
            }
            catch(Exception e)
            {
                Log.AddRecord(e);
                return list;
            }
        }
        public List<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            List<T> list = new List<T>();
            try
            {
                var info = CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, whereLamdba, orderName, isAsc);
                foreach (T item in info)
                {
                    list.Add(item);
                }
                return list;
            }
            catch (Exception e)
            {
                Log.AddRecord(e);
                totalRecord = 0;
                return list;
            }
        }
    }
}
