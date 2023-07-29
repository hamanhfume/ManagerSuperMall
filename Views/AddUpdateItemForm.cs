using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMallManagerMVC
{
    public partial class AddUpdateItemForm : Form
    {
        public HomeForm ObjectHomeForm { get; set; }
        public AddUpdateItemForm()
        {
            InitializeComponent();
            CenterToParent();

        }

        public AddUpdateItemForm(HomeForm objectHomeForm) : this()
        {
            ObjectHomeForm = objectHomeForm;
            //Method: Add listDiscount.NameDiscount -> comboboxDiscount của AddNewItems -> Khi init
            ShowDiscount(ObjectHomeForm.ListDiscounts);
        }


        private Items CreateInfomationItems(string nameAction)
        {
            Filter filter = new Filter();
            string idItemsCheck = textBoxIAddNewIdItems.Text;
            int idItem = 0;
            string nameItemCheck = textBoxIAddNewNameItems.Text;
            string typeItemCheck = comboBoxTypeAddNewItem.Text;
            int quantityItem = (int)numericUpDownQuantityItemAddNewItem.Value;
            string brandItemCheck = textBoxIAddNewBrandItems.Text;
            DateTime realeaseDateItem = dateTimePickerReleaseDateAddNewItem.Value;
            long priceItem = (long)numericUpDownPriceItemAddNewItem.Value;

            Discounts discountsItem = null;

            try
            {
                if (String.IsNullOrEmpty(idItemsCheck))
                {
                    labelAddItemMagItemMes.Text = "Id Item IsEmpty! Using Id-Auto!";
                    idItem = 0;
                }
                else if (!filter.IsIdItemsValid(idItemsCheck))
                {
                    labelAddItemMagItemMes.Text = "";
                    string content = $"Invalid Id Items: {idItemsCheck}\n" +
                                     $"Id Example Valid: Number Integer > 0!";
                    MessageBoxWarningCommon(content);
                    throw new InvalidIdItemException("Invalid Id Item!", idItemsCheck);
                }
                else
                {
                    idItem = int.Parse(idItemsCheck);
                    if (filter.IsExistsIdItemsValid(ObjectHomeForm.ListItems, idItem) && nameAction == "AddNewItem")
                    {
                        labelAddItemMagItemMes.Text = "Id Item Exists! Using Id-Auto!";
                        idItem = 0;
                    }
                }

                if (String.IsNullOrEmpty(nameItemCheck))
                {
                    string content = "Item name cannot be blank!";
                    MessageBoxWarningCommon(content);
                    throw new InvalidNameItemException("Invalid Name Item!", nameItemCheck);
                }
                else if (!filter.IsNameItemsValid(nameItemCheck))
                {
                    string content = $"Name Item Invalid: {nameItemCheck}\n" +
                                     $"Name Example Valid: Mì Cay, Phở ... !";
                    MessageBoxWarningCommon(content);
                    throw new InvalidNameItemException("Invalid Name Item!", nameItemCheck);
                }

                if (String.IsNullOrEmpty(typeItemCheck))
                {
                    string content = "Please select the type for the Item!";
                    MessageBoxWarningCommon(content);
                    throw new Exception("Please select the type for the Item!");
                }

                if (quantityItem == 0)
                {
                    string content = "Please enter the quantity for the Item!";
                    MessageBoxWarningCommon(content);
                    throw new Exception("Please enter the quantity for the Item!");
                }

                if (String.IsNullOrEmpty(brandItemCheck))
                {
                    string content = "Item label cannot be Empty!";
                    MessageBoxWarningCommon(content);
                    throw new Exception("Item label cannot be Empty!");
                }

                if (priceItem == 0)
                {
                    string content = "Please enter the price for the Item!";
                    MessageBoxWarningCommon(content);
                    throw new Exception("Please enter the price for the Item!");
                }

                // Lấy ra discount trong danh sách discount ComboxBox.
                if (comboBoxDiscountAddNewItem.SelectedIndex > -1)
                {
                    discountsItem = ObjectHomeForm.ListDiscounts[comboBoxDiscountAddNewItem.SelectedIndex];
                }


                Items item = new Items(idItem, nameItemCheck, typeItemCheck, quantityItem, brandItemCheck, realeaseDateItem, priceItem, discountsItem);

                return item;

            }
            catch (InvalidIdItemException exId)
            {
                Console.WriteLine("Exception: " + exId.ToString());
                Console.WriteLine(exId.StackTrace);
            }
            catch (InvalidNameItemException exName)
            {
                Console.WriteLine("Exception: " + exName.ToString());
                Console.WriteLine(exName.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return null;
        }

        //Method đẩy dữ liệu vào bên trong comboBox của đối tượng Addnew Items
        // Object Home -> Send ListDiscount -> object child của base home -> nhận và thêm vào dataSource
        private void ShowDiscount(List<Discounts> listDiscount)
        {
            List<string> discounts = new List<string>();
            foreach (Discounts discount in listDiscount)
            {
                discounts.Add(discount.NameDiscount);
            }
            //Lấy ra danh sách Name của discount -> Đưa vào comboBox để sử dụng.
            comboBoxDiscountAddNewItem.DataSource = discounts;
            comboBoxDiscountAddNewItem.SelectedIndex = -1;
        }


        public void UpdateItemsInfomation(Items item)
        {
            labelAddNewItemsInfomation.Text = "Update Item Infomation: ";
            textBoxIAddNewIdItems.Text = $"{item.IdItem}";
            textBoxIAddNewIdItems.Enabled = false;
            textBoxIAddNewNameItems.Text = $"{item.FullNameItem}";
            textBoxIAddNewBrandItems.Text = $"{item.BrandItem}";
            numericUpDownQuantityItemAddNewItem.Value = (decimal)item.QuantityItem;
            numericUpDownPriceItemAddNewItem.Value = (decimal)item.PriceItem;
            dateTimePickerReleaseDateAddNewItem.Value = item.ReleaseDateItem;
            comboBoxTypeAddNewItem.Text = item.TypeItem;

            for (int i = 0; i < comboBoxDiscountAddNewItem.Items.Count; i++)
            {
                // Operator "toán tử hủy bỏ null" or "toán tử an toàn": ? -> Nếu null -> thì return null còn k sẽ là giá trị mà không crack
                if (item.DiscountItem?.NameDiscount.CompareTo(comboBoxDiscountAddNewItem.Items[i]) == 0)
                {
                    comboBoxDiscountAddNewItem.SelectedIndex = i;
                    break;
                }
            }

            buttonAddNewItemAddUpdateItem.Image = Image.FromFile("../../Image/updated (1).png");

            this.buttonAddNewItemAddUpdateItem.Click -= new System.EventHandler(this.ButtonClickAddNewItemsAddUpdateFormEvenHandler);
            this.buttonAddNewItemAddUpdateItem.Click += new System.EventHandler(this.ButtonClickUpdateItemsAddUpdateFormEvenHandler);

        }



        private void ButtonClickAddNewItemsAddUpdateFormEvenHandler(object sender, EventArgs e)
        {
            Items item = new Items();
            item = CreateInfomationItems("AddNewItem");
            if (item != null)
            {
                labelMesSuccesFullItemCreateNew.Text = "Status: Successful new Item!";
                ObjectHomeForm.CreateItems(item);
            }
            else
            {
                labelMesSuccesFullItemCreateNew.Text = "Status: Failed new Item!";
            }
        }

        private void ButtonClickUpdateItemsAddUpdateFormEvenHandler(object sender, EventArgs e)
        {
            Items item = new Items();
            item = CreateInfomationItems("UpdateItem");
            if (item != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to save your Update Items?", "Confirm:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    labelMesSuccesFullItemCreateNew.Text = "Status: Successful Update!";
                    ObjectHomeForm.UpdateItems(item);
                    this.Close();
                }
            }
            else
            {
                labelMesSuccesFullItemCreateNew.Text = "Status: Failed Update!";
            }
        }

        private void CancelClickAddNewItemsEventHandler(object sender, EventArgs e)
        {
            string title = "Notification:";
            string content = "Are you sure you want to cancel?";
            DialogResult resultCancel = MessageBoxQuestionCommon(content, title);
            if (DialogResult.Yes == resultCancel)
            {
                Dispose();
            }
        }
        private void MessageBoxWarningCommon(string content)
        {
            MessageBox.Show(content, "Warning: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private DialogResult MessageBoxQuestionCommon(string content, string title)
        {
            DialogResult result = MessageBox.Show(content, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }


    }
}
