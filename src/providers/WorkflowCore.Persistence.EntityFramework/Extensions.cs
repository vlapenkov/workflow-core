using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WorkflowCore.Persistence.EntityFramework
{
    public static class Extensions
    {
        public static PropertyBuilder<T> SetJson<T>(this PropertyBuilder<T> propertyBuilder, JsonSerializerOptions jsonOptions = null)
             where T : class, new()
        {
            if (jsonOptions == null)
            {
                jsonOptions = new JsonSerializerOptions();
            }

            ValueConverter<T, string> converter = new ValueConverter<T, string>(
                v => JsonSerializer.Serialize(v, jsonOptions),
                v => JsonSerializer.Deserialize<T>(v, jsonOptions) ?? new T());
            ValueComparer<T> comparer = new ValueComparer<T>(
                (l, r) => JsonSerializer.Serialize(l, jsonOptions) == JsonSerializer.Serialize(r, jsonOptions),
                v => v == null ? 0 : JsonSerializer.Serialize(v, jsonOptions).GetHashCode(),
                v => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(v, jsonOptions), jsonOptions));
            propertyBuilder.HasConversion(converter);
            propertyBuilder.Metadata.SetValueConverter(converter);
            propertyBuilder.Metadata.SetValueComparer(comparer);
            propertyBuilder.HasColumnType("jsonb");

            return propertyBuilder;
        }
    }

}
