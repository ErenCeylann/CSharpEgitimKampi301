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
    public partial class FrmLocationcs : Form
    {
        public FrmLocationcs()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db=new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocationcs_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideID
            }).ToList();    
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideID";
            cmbGuide.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.LocationCapasity =byte.Parse(nudCapasity.Value.ToString());
            location.LocationCity = txtCity.Text;
            location.LocationCountry = txtCountry.Text;
            location.LocationPrice = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideID =int.Parse( cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı");
        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedvalue = db.Location.Find(id);
            db.Location.Remove(deletedvalue);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var updatedvalue = db.Location.Find(id);
            updatedvalue.DayNight=txtDayNight.Text;
            updatedvalue.LocationPrice=decimal.Parse(txtPrice.Text);
            updatedvalue.LocationCity = txtCity.Text;
            updatedvalue.LocationCountry = txtCountry.Text;
            updatedvalue.LocationCapasity=byte.Parse( nudCapasity.Value.ToString());
            updatedvalue.GuideID=int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı");

        }
    }
}
