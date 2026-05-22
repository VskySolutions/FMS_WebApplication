using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using Humanizer;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Vsky.Data;

namespace Vsky.Api.Extensions
{
    public static class Extensions
    {
        public static string GetErrorMessages(this ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            var items = modelState.Values.Where(x => x.Errors.Count > 0).Select(x => x.Errors);

            foreach (var item1 in items)
            {
                foreach (var item2 in item1)
                {
                    errors.Add(item2.ErrorMessage);
                }
            }

            return string.Join(",", errors);
        }

        public static string GetErrorMessages(this IEnumerable<IdentityError> identityErrors)
        {
            var errors = new List<string>();

            foreach (var item in identityErrors)
            {
                errors.Add(item.Description);
            }

            return string.Join(",", errors);
        }

        public static IEnumerable<dynamic> DynamicListFromSql(this ApplicationDbContext db, string query, Dictionary<string, object> parameters = null)
        {
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                db.Database.OpenConnection();

                if (parameters != null)
                {
                    foreach (var p in parameters)
                    {
                        var dbParameter = command.CreateParameter();
                        dbParameter.ParameterName = p.Key;
                        dbParameter.Value = p.Value;
                        command.Parameters.Add(dbParameter);
                    }
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new ExpandoObject() as IDictionary<string, object>;

                        for (var fieldCount = 0; fieldCount < reader.FieldCount; fieldCount++)
                        {
                            row.Add(reader.GetName(fieldCount), reader[fieldCount]);
                        }

                        yield return row;
                    }
                }
            }
        }

        public static string RelativeFormat(this DateTime source, string languageCode = "en-US")
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - source.Ticks);
            var delta = ts.TotalSeconds;

            CultureInfo culture;

            try
            {
                culture = new CultureInfo(languageCode);
            }
            catch (CultureNotFoundException)
            {
                culture = new CultureInfo("en-US");
            }

            return TimeSpan.FromSeconds(delta).Humanize(precision: 1, culture: culture, maxUnit: TimeUnit.Year);
        }
    }
}