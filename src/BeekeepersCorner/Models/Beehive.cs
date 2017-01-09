using System;
using System.ComponentModel.DataAnnotations;

namespace BeekeepersCorner.Models
{
    public class Beehive
    {
        public int BeehiveID { get; set; }
        public int BeekeeperIDFK { get; set; }
        [Display(Name = "Hive Name")]
        public string HiveName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Installed")]
        public DateTime InstallDate { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Honey Production (lbs)")]
        public int HoneyProduction { get; set; }

        //public virtual Beekeeper Beekeeper { get; set; }
    }
}
