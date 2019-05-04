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
            UpdateTextPosition();
            Reset();
        }
        //Method for handling when the cancel button is pushed by calling the Reset() function
        //which is also called on form load
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

        //Event handler when the calculate button ("beregn") is pushed
        private void buttonBeregn_Click(object sender, EventArgs e)
        {
            int rejerAntalSkiver = Convert.ToInt32(rejerSlicesTextBox.Text);
            rejerKalorierPrSkiveAlmTextBox.Text = $"{(double)RejerMedTun.KalorierAlm / (double)rejerAntalSkiver} kcal";
            rejerKalorierPrSkiveFamTextBox.Text = $"{(double)RejerMedTun.KalorierFam / (double)rejerAntalSkiver} kcal";

            int pepperoniAntalSkiver = Convert.ToInt32(pepperoniSlicesTextBox.Text);
            pepperoniKalorierPrSkiveAlmTextBox.Text = $"{(double)Pepperoni.KalorierAlm / (double)pepperoniAntalSkiver} kcal";
            pepperoniKalorierPrSkiveFamTextBox.Text = $"{(double)Pepperoni.KalorierFam / (double)pepperoniAntalSkiver} kcal";

            CalculateRejerPizza();
            CalculatePepperoniPizza();
            CalculateTotal();
        }

        //Event handler when the order button ("bestil") is pushed
        private void buttonBestil_Click(object sender, EventArgs e)
        {
            ++OrderNumber;
            bestillingsNrtextBox.Text = OrderNumber.ToString();
            DateTime time = DateTime.Now;
            DateTime time_4 = time.AddMinutes(4);
            forventetFaerdigTextBox.Text = time_4.ToString("HH:mm:ss");
            KvitteringMessage();
            Reset();
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

        //Method to calculate subtotal of "rejer med tun" pizza
        public void CalculateRejerPizza()
        {
            try
            {
                int rejerAntalAlm = Convert.ToInt32(rejerAlmTextBox.Text);
                int rejerAntalFam = Convert.ToInt32(rejerFamTextBox.Text);
                int rejerLoegAlm = loegCheckBox.Checked ? rejerAntalAlm : 0;
                int rejerRejerAlm = rejerCheckBox.Checked ? rejerAntalAlm : 0;
                int rejerTunAlm = tunCheckBox.Checked ? rejerAntalAlm : 0;
                int rejerLoegFam = loegCheckBox.Checked ? rejerAntalFam : 0;
                int rejerRejerFam = rejerCheckBox.Checked ? rejerAntalFam : 0;
                int rejerTunFam = tunCheckBox.Checked ? rejerAntalFam : 0;
                int rejerSubtotalAlm = rejerMedTunPizza.GetPriceAlm(rejerAntalAlm, rejerLoegAlm, rejerRejerAlm, rejerTunAlm);
                double rejerSubtotalFam = rejerMedTunPizza.GetPriceFam(rejerAntalFam, rejerLoegFam, rejerRejerFam, rejerTunFam);
                double rejerSubtotalSamlet = rejerSubtotalAlm + rejerSubtotalFam;
                subTotalRejer.Text = rejerSubtotalSamlet.ToString("C");
            }
            catch (FormatException ex) //when (ex is ArgumentNullException || ex is DivideByZeroException)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Method to calculate subtotal of pepperoni pizza
        public void CalculatePepperoniPizza()
        {
            int pepperoniAntalAlm = Convert.ToInt32(pepperoniAlmTextBox.Text);
            int pepperoniAntalFam = Convert.ToInt32(pepperoniFamTextBox.Text);
            int pepperoniPepAlm = pepperoniCheckBox.Checked ? pepperoniAntalAlm : 0;
            int pepperoniChamAlm = ChampignonCheckBox.Checked ? pepperoniAntalAlm : 0;
            int pepperoniOstAlm = ostCheckBox.Checked ? pepperoniAntalAlm : 0;
            int pepperoniPepFam = pepperoniCheckBox.Checked ? pepperoniAntalFam : 0;
            int pepperoniChamFam = ChampignonCheckBox.Checked ? pepperoniAntalFam : 0;
            int pepperoniOstFam = ostCheckBox.Checked ? pepperoniAntalFam : 0;
            int pepperoniSubtotalAlm = pepperoniPizza.GetPriceAlm(pepperoniAntalAlm, pepperoniPepAlm, pepperoniChamAlm, pepperoniOstAlm);
            double pepperoniSubtotalFam = pepperoniPizza.GetPriceFam(pepperoniAntalFam, pepperoniPepFam, pepperoniChamFam, pepperoniOstFam);
            double pepperoniSubtotalSamlet = pepperoniSubtotalAlm + pepperoniSubtotalFam;
            subTotalPep.Text = pepperoniSubtotalSamlet.ToString("C");
        }
        //Method to calculate the total value of the order
        public void CalculateTotal()
        {
            double temp = double.Parse(subTotalRejer.Text, System.Globalization.NumberStyles.Currency);
            double temp2 = double.Parse(subTotalPep.Text, System.Globalization.NumberStyles.Currency);
            totalTextBox.Text = (temp + temp2).ToString("C");
        }
        //Method that writes a reciept to a message box
        public void KvitteringMessage()
        {
            string ekstraLoeg = loegCheckBox.Checked ? $"+ ekstra {loegCheckBox.Text}" : "";
            string ekstraRejer = rejerCheckBox.Checked ? $"+ ekstra {rejerCheckBox.Text}" : "";
            string ekstraTun = tunCheckBox.Checked ? $"+ ekstra {tunCheckBox.Text}" : "";
            string ekstraPepperoni = pepperoniCheckBox.Checked ? $"+ ekstra {pepperoniCheckBox.Text}" : "";
            string ekstraCham = ChampignonCheckBox.Checked ? $"+ ekstra {ChampignonCheckBox.Text}" : "";
            string ekstraOst = ostCheckBox.Checked ? $"+ ekstra {ostCheckBox.Text}" : "";
            string rejAlm = rejerAlmTextBox.Enabled ? $"{rejerAlmTextBox.Text} alm pizza med rejer og tun" +
                $" {ekstraLoeg} {ekstraRejer} {ekstraTun}" : "";
            string rejFam = rejerFamTextBox.Enabled ? $"{rejerFamTextBox.Text} familie pizza med rejer og tun" +
                $"{ekstraLoeg} {ekstraRejer} {ekstraTun}" : "";
            string pepAlm = pepperoniAlmTextBox.Enabled ? $"{pepperoniAlmTextBox.Text} alm pizza med pepperoni" +
                $"{ekstraPepperoni} {ekstraCham} {ekstraOst}" : "";
            string pepFam = pepperoniFamTextBox.Enabled ? $"{pepperoniFamTextBox.Text} familie pizza med pepperoni" +
                $"{ekstraPepperoni} {ekstraCham} {ekstraOst}" : "";
            string message = $"\n{rejAlm}" +
                $"\n{rejFam}" +
                $"\n{pepAlm}" +
                $"\n{pepFam}" +
                $"\n\nTotal: {totalTextBox.Text}";
            string title = "Kvittering";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons);
        }
        //Code to align the title name center of the form
        private void UpdateTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }
    }
}
