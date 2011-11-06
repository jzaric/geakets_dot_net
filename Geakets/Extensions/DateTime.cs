using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System
{
    public static class DateTimeExtension
    {
        public static MvcHtmlString TimeAgoInWords(this DateTime dateTime)
        {
            TimeSpan span = DateTime.UtcNow - dateTime;
            long minutes = span.TotalMinutes < 1 ? 1 : (long)span.TotalMinutes;
            long hours = (long)span.TotalHours;
            long days = (long)span.Days;
            long months = (long)span.Days / 30;
            if (minutes < 60)
            {
                return new MvcHtmlString(string.Format("{0} {1} ago", minutes, pluralize("minute", minutes)));
            }
            else if (hours < 24)
            {
                return new MvcHtmlString(string.Format("{0} {1} ago", hours, pluralize("hour", hours)));
            }
            else if (days < 30)
            {
                return new MvcHtmlString(string.Format("{0} {1} ago", days, pluralize("day", days)));
            }
            else
            {
                return new MvcHtmlString(string.Format("{0} {1} ago", months, pluralize("month", months)));
            }
        }

        public static string pluralize(string word, long count)
        {
            if (count > 1)
            {
                if (word.EndsWith("e"))
                {
                    return word + "s";
                }
                else if (word.EndsWith("r"))
                {
                    return word + "s";
                }
                else if (word.EndsWith("y"))
                {
                    return word + "s";
                }
                else if (word.EndsWith("h"))
                {
                    return word + "s";
                }
            }
            return word;
        }
    }
}