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

namespace SuperMallManagerMVC
{
    public partial class AddUpdateCustomerForm : Form
    {
        private HomeForm _objectParent;
        private Filter FilterObject;
        public AddUpdateCustomerForm()
        {
            InitializeComponent();
            RecommendIdCustomerAddNew();
            EmailDefaultRecommand();
            CenterToParent();
            FilterObject = new Filter();
        }

        public AddUpdateCustomerForm(HomeForm objectParent) : this()
        {
            _objectParent = objectParent;
        }

        public Customers CreateCustomersNew()
        {
            try
            {
                string idCustomer = textBoxIdCustomer.Text;
                if (String.IsNullOrEmpty(idCustomer))
                {
                    string content = "CCCD cannot IsEmpty!";
                    MessageBoxCommonInfomation(content);
                    throw new InvalidCCCDCustomerException(content);
                }
                else if (!FilterObject.IsCCCDCustomerValid(idCustomer))
                {
                    string content = $"CCCD Invalid: {idCustomer}\n" +
                                     $"CCCD Example Valid: 001202035227!";
                    MessageBoxCommonWarning(content);
                    throw new InvalidCCCDCustomerException("CCCD InValid", idCustomer);
                }

                string fullName = textBoxFullNameCustomer.Text;
                if (String.IsNullOrEmpty(fullName))
                {
                    string content = "Full Name cannot IsEmpty";
                    MessageBoxCommonInfomation(content);
                    throw new InvalidFullNameCustommerException(content);
                }
                else if (!FilterObject.IsFullNameCustomerValid(fullName))
                {
                    string content = $"FullName Invalid: {fullName}\n" +
                                     $"FullName Example Valid: Hà Văn Mạnh!";
                    MessageBoxCommonWarning(content);
                    throw new InvalidFullNameCustommerException("FullName InValid", fullName);
                }

                DateTime birthDate = dateTimePickerBirthDateCustomer.Value;
                if (birthDate == null)
                {
                    throw new Exception("BirthDate not Null when create Customer");
                }

                string address = textBoxAddressCustomers.Text;
                if (String.IsNullOrEmpty(address))
                {
                    string content = "Address cannot IsEmpty!";
                    MessageBoxCommonInfomation(content);
                    throw new Exception("Address cannot IsEmpty!");
                }

                string phoneNumber = textBoxPhoneCustomers.Text.Trim();
                if (String.IsNullOrEmpty(phoneNumber))
                {
                    string content = "Phone Number cannot IsEmpty!";
                    MessageBoxCommonInfomation(content);
                    throw new InvalidPhoneNumberException(content);
                }
                else if (!FilterObject.IsPhoneCustomerValid(phoneNumber))
                {
                    string content = $"Phone Number Invalid: {phoneNumber}\n" +
                                    $"Phone Number Example Valid: 0987209593!";
                    MessageBoxCommonWarning(content);
                    throw new InvalidPhoneNumberException("Phone Number InValid", phoneNumber);
                }

                string email = textBoxEmailCustomers.Text;
                if (String.IsNullOrEmpty(email))
                {
                    string content = "Email cannot IsEmpty!";
                    MessageBoxCommonInfomation(content);
                    throw new InvalidPhoneNumberException(content);
                }
                else if (!FilterObject.IsEmailCustomerValid(email))
                {
                    string content = $"Email Invalid: {email}\n" +
                                    $"Email Example Valid: hamanhfu.me@gmail.com!";
                    MessageBoxCommonWarning(content);
                    throw new InvalidPhoneNumberException("Email InValid", email);
                }


                int pointCustomer = (int)numericUpDownPointCustomer.Value;

                string typeCustomer = "1";
                if (String.IsNullOrEmpty(typeCustomer))
                {
                    string content = "Type Customer cannot IsEmpty!";
                    MessageBoxCommonInfomation(content);
                    throw new InvalidPhoneNumberException(content);
                }
                else if (comboBoxTypeCustomers.SelectedIndex > -1)
                {
                    for (int i = 0; i < comboBoxTypeCustomers.Items.Count; i++)
                    {
                        if (comboBoxTypeCustomers.SelectedIndex == i)
                        {
                            typeCustomer = comboBoxTypeCustomers.Items[i].ToString();
                        }
                    }
                }
                else if (typeCustomer.Equals("1"))
                {
                    string content = "Type Customer cannot IsEmpty!";
                    MessageBoxCommonInfomation(content);
                    throw new InvalidPhoneNumberException(content);
                }
                dateTimePickerCreateTimeAccountCustomers.Value = DateTime.Now;
                DateTime timeCreateAccount = dateTimePickerCreateTimeAccountCustomers.Value;

                return new Customers(typeCustomer, pointCustomer, timeCreateAccount, email, idCustomer, fullName, birthDate, address, phoneNumber);
            }
            catch (InvalidCCCDCustomerException eCCCD)
            {
                Console.WriteLine(eCCCD.ToString());
            }
            catch (InvalidNameItemException eFullName)
            {
                Console.WriteLine(eFullName.ToString());
            }
            catch (InvalidPhoneNumberException ePhoneNumber)
            {
                Console.WriteLine(ePhoneNumber.ToString());
            }
            catch (InvalidEmailException eEmail)
            {
                Console.WriteLine(eEmail.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }


        private void AddNewCustomerClickEventHandler(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers = CreateCustomersNew();
            if (customers != null)
            {
                if (FilterObject.IsExistsCustomerValid(_objectParent.ListCustomers,customers.IdPerson))
                {
                    _objectParent.CreateItems<Customers>(customers);
                    labelStatusAddNewCustomer.Text = "Status: Add New Customer Successfully!";
                }
                else
                {
                    labelStatusAddNewCustomer.Text = "Status: Add New Customer Failed!";
                    string content = "Customer already exists because of the same idCustomer!";
                    MessageBoxCommonInfomation(content);
                }
            }
            else
            {
                labelStatusAddNewCustomer.Text = "Status: Add New Customer Failed!";
            }
        }


        public void UpdateCustomernfomation(Customers customers)
        {
            labelAddnewCustomerInfomation.Text = "Update Customer Infomation: ";
            textBoxIdCustomer.ForeColor = Color.Black;
            textBoxIdCustomer.Text = customers.IdPerson.ToString();
            textBoxIdCustomer.Enabled = false;

            string nameUpdate = customers.FullNamePerson.ToString();
            string[] dataName = nameUpdate.Split(' ');
            string data = "";
            for(int i = 0; i < dataName.Length; i++)
            {
                if (!String.IsNullOrEmpty(dataName[i]))
                {
                    data += dataName[i] + " ";
                }
            }
            data = data.TrimEnd(' ');
            textBoxFullNameCustomer.Text = data;

            dateTimePickerBirthDateCustomer.Value = customers.BirtDatePerson;
            textBoxAddressCustomers.Text = customers.Address;
            textBoxPhoneCustomers.Text = customers.PhoneNumber;
            textBoxEmailCustomers.Text = customers.EmailCustomer;
            textBoxEmailCustomers.ForeColor = Color.Black;
            numericUpDownPointCustomer.Value = (decimal)customers.PointCustomer;

            for(int i = 0; i < comboBoxTypeCustomers.Items.Count; i++)
            {
                if (customers.TypeCustomer.CompareTo(comboBoxTypeCustomers.Items[i].ToString()) == 0)
                {
                    comboBoxTypeCustomers.SelectedIndex = i;
                    break;
                }
            }
            dateTimePickerCreateTimeAccountCustomers.Value = customers.CreateTimeAccountCustomer;

            buttonAddNewUpdateCustomer.Text = "Update Customer";
            buttonAddNewUpdateCustomer.Image = Image.FromFile("../../Image/updated (1).png");
            this.buttonAddNewUpdateCustomer.Click -= new System.EventHandler(this.AddNewCustomerClickEventHandler);
            this.buttonAddNewUpdateCustomer.Click += new System.EventHandler(this.UpdateCustomerClickEventHandler);
        }

        private void UpdateCustomerClickEventHandler(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers = CreateCustomersNew();
            if (customers != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to save your Update Customers?", "Confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    labelStatusAddNewCustomer.Text = "Status: Successful Update!";
                    _objectParent.UpdateItems(customers);
                    this.Close();
                }
            }
            else
            {
                labelStatusAddNewCustomer.Text = "Status: Failed Update!";
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
        //Method: Gợi ý: -> Default init Recommend
        private void RecommendIdCustomerAddNew()
        {
            textBoxIdCustomer.Text = "CMND/CCCD....";
            textBoxIdCustomer.ForeColor = Color.Gray;
        }
        //Event: Gợi ý: -> Click -> Chuyển status Recommend
        private void IdCustomerForcusEnterRecommendEnterEventHandler(object sender, EventArgs e)
        {
            textBoxIdCustomer.Text = "";
            textBoxIdCustomer.ForeColor = Color.Black;
        }
        //Event: Gợi ý  -> Điều kiện sau khi chuyển status Recommend
        private void IdCustomerForcusLeaveRecommendEventHandler(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxIdCustomer.Text))
            {
                textBoxIdCustomer.Text = "CMND/CCCD....";
                textBoxIdCustomer.ForeColor = Color.Gray;
            }
            else
            {
                textBoxIdCustomer.ForeColor = Color.Black;
            }
        }
        // Method: Default email gợi ý mặc định
        private void EmailDefaultRecommand()
        {
            textBoxEmailCustomers.Text = "email....";
            textBoxEmailCustomers.ForeColor = Color.Gray;
        }
        // Event: Recommand Email
        private void EmailRecommendMoveEnterEventHandler(object sender, EventArgs e)
        {
            textBoxEmailCustomers.Text = "";
            textBoxEmailCustomers.ForeColor = Color.Black;
        }
        // Event: Recommand Email
        private void EmailRecommendLeaveEnterEventHandler(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxEmailCustomers.Text))
            {
                textBoxEmailCustomers.Text = "email....";
                textBoxEmailCustomers.ForeColor = Color.Gray;
            }
            else
            {
                textBoxEmailCustomers.ForeColor = Color.Black;
            }
        }

        private void CancelClickAddNewUpdateCustomerEventHandler(object sender, EventArgs e)
        {
            string content = "You want Cancel Add New Customer?";
            DialogResult result = MessageBoxCommonQuestion(content);
            if (result == DialogResult.Yes)
            {
                Dispose();
            }
        }
    }
}
