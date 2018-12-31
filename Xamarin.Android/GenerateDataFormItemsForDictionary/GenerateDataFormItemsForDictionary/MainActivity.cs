using Android.App;
using Android.Widget;
using Android.OS;
using Syncfusion.Android.DataForm;
using System.Collections.Generic;
using System.ComponentModel;

namespace GenerateDataFormItemsForDictionary
{
    [Activity(Label = "GenerateDataFormItemsForDictionary", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static SfDataForm dataForm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            dataForm = new SfDataForm(this);

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("ID", 1);
            dictionary.Add("Name", "John");
            dataForm.ItemManager = new DataFormItemManagerExt(dataForm, dictionary);
            // Set our view from the "main" layout resource
            SetContentView(dataForm);
        }
    }
    public class DataFormItemManagerExt : DataFormItemManager
    {
        Dictionary<string, object> dataFormDictionary;
        public DataFormItemManagerExt(SfDataForm dataForm, Dictionary<string, object> dictionary) : base(dataForm)
        {
            dataFormDictionary = dictionary;
        }


        protected override List<DataFormItemBase> GenerateDataFormItems(PropertyDescriptorCollection itemProperties, List<DataFormItemBase> dataFormItems)
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

