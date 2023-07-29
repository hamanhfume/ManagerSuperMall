using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Controllers.InvalidPhoneNumberException;

namespace SuperMallManagerMVC
{
    public partial class AddUpdateDiscountForm : Form
    {
        HomeForm _objectHomeForm;
        private Filter _filterObject;
        public AddUpdateDiscountForm()
        {
            InitializeComponent();
            CenterToParent();
            TypeDiscountInit();
            _filterObject = new Filter();
        }
        public AddUpdateDiscountForm(HomeForm objectHomeForm) : this()
        {
            _objectHomeForm = objectHomeForm;
        }

        public Discounts CreateDiscountNew(string nameAction)
        {
            try
            {
                string idDiscountCheck = textBoxIdDiscount.Text;
                int idDiscount = 0;
                if (String.IsNullOrEmpty(idDiscountCheck))
                {
                    labelStatusAutoIdAddNewDiscount.Text = "Id Discount IsEmpty! Using Id-Auto!";
                    idDiscount = 0;
                }
                else if (!_filterObject.IsIdDiscountValid(idDiscountCheck))
                {
                    labelStatusAutoIdAddNewDiscount.Text = "";
                    string content = $"Invalid Id Discount: {idDiscountCheck}\n" +
                                     $"Id Example Valid: Number Integer > 0!";
                    MessageBoxCommonWarning(content);
                    throw new InvalidIdDiscountExction("Invalid Id Discount!", idDiscountCheck);
                }
                else
                {
                    idDiscount = int.Parse(idDiscountCheck);
                    if (_filterObject.IsExistsIdDiscountValid(_objectHomeForm.ListDiscounts, idDiscount) && nameAction == "AddNewDiscount")
                    {
                        labelStatusAutoIdAddNewDiscount.Text = "Id Discount Exists! Using Id-Auto!";
                        idDiscount = 0;
                    }
                }

                string nameDiscount = textBoxNameDiscount.Text;
                if (String.IsNullOrEmpty(nameDiscount))
                {
                    string content = "Name Discount cannot IsEmpty!";
                    MessageBoxCommonInfomation(content);
                    throw new Exception(content);
                }

                DateTime timeDiscountStart = dateTimePickerStartTime.Value;
                DateTime timeDiscountEnd = dateTimePickerEndTime.Value;
                if (timeDiscountEnd <= timeDiscountStart)
                {
                    string content = "Discount end time cannot be less than or equal to discount start time!";
                    MessageBoxCommonWarning(content);
                    throw new Exception(content);
                }

                int indexTypeDiscount = comboBoxTypeDiscount.SelectedIndex;
                string typeDiscount = "";
                if (indexTypeDiscount >= 0)
                {
                    typeDiscount = comboBoxTypeDiscount.Items[indexTypeDiscount].ToString();
                }
                else if (String.IsNullOrEmpty(typeDiscount) || typeDiscount == "")
                {
                    string content = "Type Discount cannot IsEmpty!";
                    MessageBoxCommonWarning(content);
                    throw new Exception(content);
                }
                int valueDiscount = 0;
                int percentDiscount = 0;
                if (indexTypeDiscount == 1)
                {
                    valueDiscount = (int)numericUpDownValueDiscount.Value;
                }
                else if (indexTypeDiscount == 2)
                {
                    percentDiscount = (int)numericUpDownPercentdiscount.Value;
                }
                else if (indexTypeDiscount == 3)
                {
                    valueDiscount = (int)numericUpDownValueDiscount.Value;
                    percentDiscount = (int)numericUpDownPercentdiscount.Value;
                }

                if (indexTypeDiscount == 1 && valueDiscount == 0)
                {
                    string content = "Please enter a value for the Discount!";
                    MessageBoxCommonWarning(content);
                    throw new Exception(content);
                }
                else if (indexTypeDiscount == 2 && percentDiscount == 0)
                {
                    string content = "Please enter percent for the Discount!";
                    MessageBoxCommonWarning(content);
                    throw new Exception(content);
                }
                else if (indexTypeDiscount == 3 && (valueDiscount == 0 || percentDiscount == 0))
                {
                    string content = "Please enter a value and percent for the Discount!";
                    MessageBoxCommonWarning(content);
                    throw new Exception(content);
                }

                return new Discounts(idDiscount, nameDiscount, timeDiscountStart, timeDiscountEnd, typeDiscount, percentDiscount, valueDiscount);
            }
            catch (InvalidIdDiscountExction eId)
            {
                Console.WriteLine(eId.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }

        private void AddNewDiscountClickEventHandler(object sender, EventArgs e)
        {
            Discounts discount = new Discounts();
            discount = CreateDiscountNew("AddNewDiscount");
            if (discount != null)
            {
                _objectHomeForm.CreateItems<Discounts>(discount);
                labelStatusAddNewDiscount.Text = "Status: Add New Discount Successfully!";
            }
            else
            {
                labelStatusAddNewDiscount.Text = "Status: Add New Discount Failed!";
            }
        }


        public void UpdateDiscountInfomation(Discounts discount)
        {
            labelAddNewDiscount.Text = "Update Discount Infomation: ";
            textBoxIdDiscount.Text = discount.IdDiscount.ToString();
            textBoxIdDiscount.Enabled = false;
            
            textBoxNameDiscount.Text = discount.NameDiscount;

            dateTimePickerStartTime.Value = discount.StartTimeDiscount;
            dateTimePickerEndTime.Value = discount.EndTimeDiscount;

            string typeDiscount = discount.TypeDiscount;
            comboBoxTypeDiscount.Text = typeDiscount;
            if (typeDiscount.Equals("Does not apply Discount"))
            {
                numericUpDownValueDiscount.Value = 0;
                numericUpDownPercentdiscount.Value = 0;
            }else if (typeDiscount.Equals("Discount Direct Value"))
            {
                numericUpDownValueDiscount.Enabled = true;
                numericUpDownPercentdiscount.Enabled= false;
                numericUpDownValueDiscount.Value = (decimal)discount.PriceAmountDiscount;
            }else if (typeDiscount.Equals("Discount Percent Price Item"))
            {
                numericUpDownValueDiscount.Enabled = false;
                numericUpDownPercentdiscount.Enabled = true;
                numericUpDownPercentdiscount.Value = (decimal)discount.PercentDiscount;
            }else if (typeDiscount.Equals("Discount by Percent and Value"))
            {
                numericUpDownValueDiscount.Enabled = true;
                numericUpDownPercentdiscount.Enabled = true;
                numericUpDownValueDiscount.Value = (decimal)discount.PriceAmountDiscount;
                numericUpDownPercentdiscount.Value = (decimal)discount.PercentDiscount;
            }

            buttonAddNewDiscount.Text = "Update Discount";
            buttonAddNewDiscount.Image = Image.FromFile("../../Image/updated (1).png");
            this.buttonAddNewDiscount.Click -= new System.EventHandler(this.AddNewDiscountClickEventHandler);
            this.buttonAddNewDiscount.Click += new System.EventHandler(this.UpdateDiscountClickEventHandler);
        }


        private void UpdateDiscountClickEventHandler(object sender, EventArgs e)
        {
            Discounts discount = new Discounts();
            discount = CreateDiscountNew("UpdateDiscount");
            if (discount != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to save your Update Discount?", "Confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    labelStatusAddNewDiscount.Text = "Status: Successful Update!";
                    _objectHomeForm.UpdateItems(discount);
                    this.Close();
                }
            }
            else
            {
                labelStatusAddNewDiscount.Text = "Status: Failed Update!";
            }
        }











        public void MessageBoxCommonInfomation(string content)
        {
            MessageBox.Show(content, "Infomation: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MessageBoxCommonWarning(string content)
        {
            MessageBox.Show(content, "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult MessageBoxCommonQuestion(string content)
        {
            return MessageBox.Show(content, "Question: ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void CancelClickDiscountAddUpdateFomEventHandler(object sender, EventArgs e)
        {
            string content = "You want Cancel Add New Discount?";
            DialogResult result = MessageBoxCommonQuestion(content);
            if (result == DialogResult.Yes)
            {
                Dispose();
            }
        }
        private void TypeDiscountInit()
        {
            comboBoxTypeDiscount.SelectedIndex = -1;
            if (comboBoxTypeDiscount.SelectedIndex <= -1)
            {
                numericUpDownPercentdiscount.Enabled = false;
                numericUpDownValueDiscount.Enabled = false;
            }
        }
        private void TypeDiscountIndexChangeEventHandler(object sender, EventArgs e)
        {
            if (comboBoxTypeDiscount.SelectedIndex <= -1)
            {
                numericUpDownPercentdiscount.Enabled = false;
                numericUpDownValueDiscount.Enabled = false;
            }
            else if (comboBoxTypeDiscount.SelectedIndex >= 0 && comboBoxTypeDiscount.SelectedIndex == 0)
            {
                numericUpDownPercentdiscount.Enabled = false;
                numericUpDownValueDiscount.Enabled = false;
            }
            else if (comboBoxTypeDiscount.SelectedIndex >= 0 && comboBoxTypeDiscount.SelectedIndex == 1)
            {
                numericUpDownPercentdiscount.Enabled = false;
                numericUpDownValueDiscount.Enabled = true;
            }
            else if (comboBoxTypeDiscount.SelectedIndex >= 0 && comboBoxTypeDiscount.SelectedIndex == 2)
            {
                numericUpDownPercentdiscount.Enabled = true;
                numericUpDownValueDiscount.Enabled = false;
            }
            else if (comboBoxTypeDiscount.SelectedIndex >= 0 && comboBoxTypeDiscount.SelectedIndex == 3)
            {
                numericUpDownPercentdiscount.Enabled = true;
                numericUpDownValueDiscount.Enabled = true;
            }
        }
    }
}
