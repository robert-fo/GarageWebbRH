﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageWebbRH.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using GarageWebbRH.DataAccessLayer;

namespace GarageWebbRH.Repository
{


    public class FordonsHandler
    {
        private ItemContext db = new ItemContext();

        public IEnumerable<SelectListItem> GetSelectListLedigaPlatser(int pNr = 0)
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the Industry enum
            var parkeradeFordon = from f in db.Fordon
                                  select f;

            int platsnr = 1;
            bool upptagenPlats;

            if (pNr != 0)
            {
                // Value and Text to the enum value and description.
                selectList.Add(new SelectListItem
                {
                    Value = Convert.ToString(pNr),
                    // GetIndustryName just returns the Display.Name value
                    // of the enum - check out the next chapter for the code of this function.
                    Text = Convert.ToString(pNr) /* GetFordonsName(enumValue) */
                });
            }

            for (int i = 1; i <= 100; i++)
            {
                upptagenPlats = false;

                foreach (var fordon in parkeradeFordon)
                {
                    if (fordon.PplatsNr == i)
                    {
                        upptagenPlats = true;
                    }
                }

                if (upptagenPlats == false)
                {
                    // Value and Text to the enum value and description.
                    selectList.Add(new SelectListItem
                    {
                        Value = Convert.ToString(platsnr),
                        // GetIndustryName just returns the Display.Name value
                        // of the enum - check out the next chapter for the code of this function.
                        Text = Convert.ToString(platsnr) /* GetFordonsName(enumValue) */
                    });
                }

                platsnr++;
            }

            return selectList;
        }

        public IEnumerable<SelectListItem> GetSelectListAgarNamn(int AId = 0)
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the Industry enum
            var Agare = from a in db.Agare
                        select a;


            foreach (var AItem in Agare)
            {
                if (AId == AItem.AgareId)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = AItem.AgareId.ToString(),
                        Text = AItem.Fnamn + " " + AItem.Enamn,
                        Selected = true
                    });
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = AItem.AgareId.ToString(),
                        Text = AItem.Fnamn + " " + AItem.Enamn
                    });
                }
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetSelectListFordonsTyper()
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the Industry enum
            var Fordonstyper = from ft in db.Fordonstyp
                        select ft;

            selectList.Add(new SelectListItem
            {
                Value = "ALLA",
                Text = "Alla"
            });

            foreach (var FTitem in Fordonstyper)
            {
                    selectList.Add(new SelectListItem
                    {
                        Value = FTitem.FtypId.ToString(),
                        Text = FTitem.Namn
                    });
            }
            return selectList;
        }

    }
}