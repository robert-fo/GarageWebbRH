using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageWebbRH.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GarageWebbRH.Repository
{
    public enum fordonsTyp
    {
        [Description("Bil")]
        Bil,
        [Description("Motorcyckel")]
        MC,
        [Description("Buss")]
        Buss,
        [Description("Lastbil")]
        Lastbil
    };

    public class FordonsHandler
    {
        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the Industry enum
            var enumValues = Enum.GetValues(typeof(fordonsTyp)) as fordonsTyp[];
            if (enumValues == null)
                return null;

            // Value and Text to the enum value and description.
            selectList.Add(new SelectListItem
            {
                Value = "Alla",
                // GetIndustryName just returns the Display.Name value
                // of the enum - check out the next chapter for the code of this function.
                Text = "Alla" /* GetFordonsName(enumValue) */
            });

            foreach (var enumValue in enumValues)
            {
                // Create a new SelectListItem element and set its 
                // Value and Text to the enum value and description.
                selectList.Add(new SelectListItem
                {
                    Value = enumValue.ToString(),
                    // GetIndustryName just returns the Display.Name value
                    // of the enum - check out the next chapter for the code of this function.
                    Text = enumValue.ToString() /* GetFordonsName(enumValue) */
                });
            }

            return selectList;
        }

        public string GetFordonsName(fordonsTyp value)
        {
            // Get the MemberInfo object for the supplied enum value
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length != 1)
                return null;

            // Get DisplayAttibute on the supplied enum value
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
            if (displayAttribute == null || displayAttribute.Length != 1)
                return null;

            return displayAttribute[0].Name;
        }
    }
}