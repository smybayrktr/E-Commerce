﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //ReflectedType namespace ini alır. Bu kod E-Commerace.Business.IProductService.GetAll tarzı bişi döner
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //Metotların parametrelerini listeye çevirir
            var arguments = invocation.Arguments.ToList();
            //Burda key oluşturuluyor namespace metot adı ve parametreye göre.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //Bellekte key var mı bakılır
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //Metot yoksa çalışır
            invocation.Proceed();
            //Cache e eklenir.
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}