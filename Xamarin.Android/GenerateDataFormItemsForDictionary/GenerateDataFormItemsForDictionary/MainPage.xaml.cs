#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GenerateDataFormItemsForDictionary
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            dataForm.DataObject = new object();
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("ID", 1);
            dictionary.Add("Name", "John");
            dataForm.ItemManager = new DataFormItemManagerExt(dataForm, dictionary);
        }
    }

    public class DataFormItemManagerExt : DataFormItemManager
    {
        Dictionary<string, object> dataFormDictionary;
        public DataFormItemManagerExt(SfDataForm dataForm, Dictionary<string, object> dictionary) : base(dataForm)
        {
            dataFormDictionary = dictionary;
        }

        protected override List<DataFormItemBase> GenerateDataFormItems(PropertyInfoCollection itemProperties, List<DataFormItemBase> dataFormItems)
        {
            var items = new List<DataFormItemBase>();
            foreach (var key in dataFormDictionary.Keys)
            {
                DataFormItem dataFormItem;
                if (key == "ID")
                    dataFormItem = new DataFormNumericItem() { Name = key, Editor = "Numeric", MaximumNumberDecimalDigits = 0 };
                else if (key == "Name")
                    dataFormItem = new DataFormTextItem() { Name = key, Editor = "Text" };
                else
                    dataFormItem = new DataFormTextItem() { Name = key, Editor = "Text" };

                items.Add(dataFormItem);
            }

            return items;
        }

        public override object GetValue(DataFormItem dataFormItem)
        {
            var value = dataFormDictionary[dataFormItem.Name];
            return value;
        }

        public override void SetValue(DataFormItem dataFormItem, object value)
        {
            dataFormDictionary[dataFormItem.Name] = value;
        }

    }
}
