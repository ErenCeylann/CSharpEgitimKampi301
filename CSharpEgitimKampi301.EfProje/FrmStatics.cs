using CSharpEgitimKampi301.EfProje.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EfProje
{
    public partial class FrmStatics : Form
    {
        public FrmStatics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapasity.Text = db.Location.Sum(x => x.LocationCapasity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapasity.Text = db.Location.Average(x => x.LocationCapasity).ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x => x.LocationPrice).Value.ToString("F2") + "₺";
            lblLastCountryName.Text = db.Location.OrderByDescending(x => x.LocationID).Select(x => x.LocationCountry).FirstOrDefault();
            lblCapadocyaLOcationCapasity.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(x => x.LocationCapasity).FirstOrDefault().ToString();
            lblTurkiyeAvgCapasity.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapasity).ToString();
            lblRomeGuideName.Text = db.Location.Where(x => x.LocationCity == "Roma").Select(x => x.Guide.GuideName + " " + x.Guide.GuideSurname).FirstOrDefault();

            var maxCapasity = db.Location.Max(x => x.LocationCapasity);

            lblMaxCapasityLocation.Text = db.Location.Where(x => x.LocationCapasity == maxCapasity).Select(x => x.LocationCity).FirstOrDefault();

            var maxPrice = db.Location.Max(x => x.LocationPrice);

            lblMaxLocationPrice.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(x => x.LocationCity).FirstOrDefault();

            var GuideIdByNameAyseGul = db.Guide.Where(x => x.GuideName == "AyşeGül" & x.GuideSurname == "Çınar").Select(x => x.GuideID).FirstOrDefault();

            lblaysegulcinar.Text = db.Location.Where(x => x.GuideID == GuideIdByNameAyseGul).Count().ToString();
            

        }
    }
}
