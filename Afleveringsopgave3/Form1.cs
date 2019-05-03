using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Afleveringsopgave3
{
    public partial class Form1 : Form
    {
        RejerMedTun rejerMedTunPizza = new RejerMedTun();
        Pepperoni pepperoniPizza = new Pepperoni();
        public int OrderNumber { get; set; }

        public Form1()
        {
            InitializeComponent();
            Reset();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //Methods for handling checkboxes that activates textboxes to specify number of pizzas
        private void rejerAlmCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            rejerAlmTextBox.Enabled = rejerAlmCheckbox.Checked ? true : false;
            label15.Visible = rejerAlmCheckbox.Checked ? true : false;
            rejerKalorierPrSkiveAlmTextBox.Visible = rejerAlmCheckbox.Checked ? true : false;
        }
        private void rejerFamCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            rejerFamTextBox.Enabled = rejerFamCheckbox.Checked ? true : false;
            label24.Visible = rejerFamCheckbox.Checked ? true : false;
            rejerKalorierPrSkiveFamTextBox.Visible = rejerFamCheckbox.Checked ? true : false;
        }
        private void pepperoniAlmCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            pepperoniAlmTextBox.Enabled = pepperoniAlmCheckbox.Checked ? true : false;
            label19.Visible = pepperoniAlmCheckbox.Checked ? true : false;
            pepperoniKalorierPrSkiveAlmTextBox.Visible = pepperoniAlmCheckbox.Checked ? true : false;
        }
        private void pepperoniFamCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            pepperoniFamTextBox.Enabled = pepperoniFamCheckbox.Checked ? true : false;
            label25.Visible = pepperoniFamCheckbox.Checked ? true : false;
            pepperoniKalorierPrSkiveFamTextBox.Visible = pepperoniFamCheckbox.Checked ? true : false;
        }

        private void buttonBeregn_Click(object sender, EventArgs e)
        {
            int rejerAntalSkiver = Convert.ToInt32(rejerSlicesTextBox.Text);
            rejerKalorierPrSkiveAlmTextBox.Text = $"{(double)RejerMedTun.KalorierAlm / (double)rejerAntalSkiver} kcal";
            rejerKalorierPrSkiveFamTextBox.Text = $"{(double)RejerMedTun.KalorierFam / (double)rejerAntalSkiver} kcal";

            int pepperoniAntalSkiver = Convert.ToInt32(pepperoniSlicesTextBox.Text);
            pepperoniKalorierPrSkiveAlmTextBox.Text = $"{(double)Pepperoni.KalorierAlm / (double)pepperoniAntalSkiver} kcal";
            pepperoniKalorierPrSkiveFamTextBox.Text = $"{(double)Pepperoni.KalorierFam / (double)pepperoniAntalSkiver} kcal";

            int rejerAntalAlm = Convert.ToInt32(rejerAlmTextBox.Text);
            int rejerAntalFam = Convert.ToInt32(rejerFamTextBox.Text);
            int pepperoniAntalAlm = Convert.ToInt32(pepperoniAlmTextBox.Text);
            int pepperoniAntalFam = Convert.ToInt32(pepperoniFamTextBox.Text);
            int rejerLoegAlm = loegCheckBox.Checked ? rejerAntalAlm : 0;
            int rejerRejerAlm = rejerCheckBox.Checked ? rejerAntalAlm : 0;
            int rejerTun = tunCheckBox.Checked ? rejerAntalAlm : 0;

            int rejerSubtotalAlm = rejerMedTunPizza.GetPriceAlm(rejerAntalAlm, rejerLoegAlm, rejerRejerAlm, rejerTun);
            subTotalRejer.Text = rejerSubtotalAlm.ToString("C");
        }

        //Event handler when the order button ("bestil") is pushed
        private void buttonBestil_Click(object sender, EventArgs e)
        {
            ++OrderNumber;
            bestillingsNrtextBox.Text = OrderNumber.ToString();
            DateTime time = DateTime.Now;
            DateTime time_4 = time.AddMinutes(4);
            forventetFaerdigTextBox.Text = time_4.ToString("HH:mm:ss");
        }

        //Method for re-setting fields on load and when "cancel" button is pressed
        public void Reset()
        {
            const int value = 0;
            foreach(CheckBox c in Controls.OfType<CheckBox>())
            {
                c.Checked = false;
            }
            rejerAlmTextBox.Enabled = false;
            rejerFamTextBox.Enabled = false;
            pepperoniAlmTextBox.Enabled = false;
            pepperoniFamTextBox.Enabled = false;
            rejerAlmTextBox.Text = "0";
            rejerFamTextBox.Text = "0";
            pepperoniAlmTextBox.Text = "0";
            pepperoniFamTextBox.Text = "0";
            label15.Visible = false;
            label24.Visible = false;
            label19.Visible = false;
            label25.Visible = false;
            rejerKalorierPrSkiveAlmTextBox.Visible = false;
            rejerKalorierPrSkiveFamTextBox.Visible = false;
            pepperoniKalorierPrSkiveAlmTextBox.Visible = false;
            pepperoniKalorierPrSkiveFamTextBox.Visible = false;
            bestillingsNrtextBox.Text = "";
            forventetFaerdigTextBox.Text = "";
            rejerSlicesTextBox.Text = "1";
            pepperoniSlicesTextBox.Text = "1";
            subTotalRejer.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            subTotalPep.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            totalTextBox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
        }
    }
}
