using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ss222yw_Projekt.Model
{
    public class CarAd
    {
        public int CarAdID { get; set; }
        public int CarBrandID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }



        [Required(ErrorMessage = "Beskriv din annosn!")]
        [StringLength(500, ErrorMessage = "Beskrivning kan bestå av som mest 500 tecken.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Priset måste anges!")]
        [RegularExpression(@"^(\d*([.,](?=\d{3}))?\d+)+((?!\2)[.,]\d\d)?$", ErrorMessage = "Priset verkar inte vara Korrekt.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Rubriken måste anges.")]
        [StringLength(25, ErrorMessage = "Rubriken kan bestå av som mest 25 tecken.")]
        public string Header { get; set; }


        [Required(ErrorMessage = "Färgen måste anges.")]
        [StringLength(25, ErrorMessage = "Namnet på färgen kan bestå av som mest 25 tecken.")]
        public string CarColor { get; set; }

       
        [Required(ErrorMessage = "Årsmådellen måste anges.")]
        [StringLength(4, ErrorMessage = "Årsmodellen kan bestå av som mest 4 tecken.")]
        [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Årsmodellen verkar inte vara korrekt.")]
        public string ModelYear { get; set; }

        

        

       


        
    }
}