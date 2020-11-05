using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utilities.Mappings
{
    public class AutoMapperHelper
    {
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T>();
            });
            var mapper = configuration.CreateMapper();
            var result = mapper.Map<List<T>, List<T>>(list);
            return result;
        }
        public static T MapToSameType<T>(T obj)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T>();
            });
            var mapper = configuration.CreateMapper();
            var result = mapper.Map<T, T>(obj);
            return result;
        }
    }
}
